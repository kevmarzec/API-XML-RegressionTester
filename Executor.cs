using Microsoft.CSharp;
using System.CodeDom.Compiler;
using ServerLib;
using System.Windows.Forms;
using System.Linq;
using System;
using System.Collections.Generic;

namespace TestBuilder
{
    public interface ITest
    {
        void Execute(IATIVisionDiagnostics Device);
    }

    public static class Executor
    {
        
        public static string ExecuteTest(Models.Test test, Models.Ecu ecu, TextBox textbox)
        {
            var app = new VisionProjectComponent();
            var path = ecu.ProjectFile;
            
            if(string.IsNullOrEmpty(path))
            {
                // Dynamically create a project from a blank project file - not currently supported!
                MessageBox.Show("No project file specified.  Dynamic projects not yet supported.");
                return null;
            }

            app.Open(path);
            if(!app.IsOpen)
            {
                MessageBox.Show($"Unable to open project file: {path}");
                return null;
            }

            app.Online = true;
            
            var deviceName = ecu.DeviceName;
            var device = app.FindDevice(deviceName) as IATIVisionDiagnostics;
            if(device == null)
            {
                MessageBox.Show($"Unable to find device: {deviceName}");
                return null;
            }

            // pass "Device" into the script
            var sourceHeader = @"
                using TestBuilder;
                using ServerLib;
                using System;

                class Test : ITest
                {
                    public void Execute(IATIVisionDiagnostics Device)
                    {
            ";

            sourceHeader += $"Device.ECU(\"{ecu.EcuName}\");\r\n";

            var sourceFooter = @"
                    }
                }
            ";
            
            var testScript = test.GetScript(ecu);            
            var source = $"{sourceHeader}{testScript}{sourceFooter}";
            
            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters();

            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("TestBuilder.exe");
            parameters.ReferencedAssemblies.Add("Interop.ServerLib.dll");
            parameters.GenerateExecutable = false;

            var results = provider.CompileAssemblyFromSource(parameters, source);
            if(results.Errors.Count > 0)
            {
                var sourceLines = source.Split('\n').Select(s => s.Trim()).ToList();
                textbox.Text += "\r\n" + string.Join("\r\n", results.Errors.Cast<CompilerError>().ToList().Select(error => 
                    (error.IsWarning ? "Warn :" : "Error:") + $"Line {error.Line-10}: {error.ErrorText} ({sourceLines[error.Line-1]})"));

                textbox.Text += $"\r\n\r\n{results.Errors.Count} error(s) found.\r\n";
            }
            else
            {
                textbox.Text += $"\r\n{string.Join("\r\n", results.Output.Cast<string>().ToList())}\r\n";
                textbox.Text += $"Test '{test.Name}' compiled successfully for {ecu.Name}.\r\n";

                var assembly = results?.CompiledAssembly;
                if(assembly == null)
                {
                    MessageBox.Show("Unexpected error: No assembly found");
                    return null;
                }

                // Run it!
                if (assembly.CreateInstance("Test") is ITest tester)
                {
                    tester.Execute(device);
                    var testResults = device.Execute();
                    textbox.Text += "\r\n" + testResults;

                    // Store the results
                    using(var db = new DataContext())
                    {
                        // Get verified result
                        var verifiedResult = db
                                                .TestResults
                                                .OrderByDescending(r => r.TestTime)
                                                .FirstOrDefault(r => r.EcuId == ecu.Id && r.TestId == test.Id && r.Verified == Models.ResultState.IsVerifiedResult);

                        var result = new Models.TestResult
                        {
                            EcuId = ecu.Id,
                            TestId = test.Id,
                            Output = testResults,
                            Script = testScript,
                            TestTime = DateTime.Now,
                            Version = app.Version,
                            Verified = verifiedResult == null 
                                            ? Models.ResultState.NoVerifiedResult 
                                            : (verifiedResult.Output == testResults 
                                                    ? Models.ResultState.Verified 
                                                    : Models.ResultState.FailedVerification)
                        };

                        db.TestResults.Add(result);
                        db.SaveChanges();

                        // Gather up the parameters that were used
                        var paramDictionary = new Dictionary<string, string>();
                        test.Parameters.ToList().ForEach(p => paramDictionary[p.Name] = p.Value);
                        ecu.Parameters.ToList().ForEach(p => paramDictionary[p.Name] = p.Value);
                                            
                        db
                            .TestResultParameters
                            .AddRange(
                                paramDictionary
                                    .Select(pair => new Models.TestResultParameter
                                        {
                                            Name = pair.Key,
                                            Value = pair.Value,
                                            TestResult = result
                                        })
                                    .ToList());

                        db.SaveChanges();
                    }
                }
            }

            app.Close();
            device = null;
            app = null;

            return string.Empty;
        }
    }
}
