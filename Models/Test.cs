using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TestBuilder.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public override string ToString() => Name;

        public string Script { get; set; }

        public ICollection<TestParameter> Parameters { get; set; }

        public ICollection<TestResult> Results { get; set; }

        public string GetScript(Ecu ecu = null)
        {
            var script = Script;

            // First replace ECU parameters
            if(ecu != null)
            {
                ecu
                    .Parameters
                    .ToList()
                    .ForEach(parameter => script = script.Replace($"[[{parameter.Name}]]", parameter.Value));
            }

            // Then fall back to Test parameters
            Parameters
                .ToList()
                .ForEach(parameter => script = script.Replace($"[[{parameter.Name}]]", parameter.Value));
                        
            return script;
        }
        
        public void SetParameters(DataContext db, List<KeyValuePair<string, string>> parameters)
        {
            db.TestParameters.RemoveRange(Parameters);

            Parameters.Clear();
            parameters
                .Select(p => new Models.TestParameter 
                { 
                    TestId = Id, 
                    Name = p.Key, 
                    Value = p.Value,
                    Test = this
                })
                .ToList()
                .ForEach(p => Parameters.Add(p));
        }

        public static Test Find(DataContext db, int id)
        {
            return db
                    .Tests
                    .Include("Parameters")
                    .FirstOrDefault(t => t.Id == id);
        }

        public static List<Test> FindAll(DataContext db)
        {
            return db
                    .Tests
                    .Include("Parameters")
                    .OrderBy(t => t.Name)
                    .ToList();
        }
    }
}
