using System.Collections.Generic;
using System.Data.Entity;

namespace TestBuilder
{
    public class DataContext : DbContext
    {
        public DbSet<Models.Test> Tests { get; set; }

        public DbSet<Models.Ecu> Ecus { get; set; }

        public DbSet<Models.TestParameter> TestParameters { get; set; }

        public DbSet<Models.EcuParameter> EcuParameters { get; set; }

        public DbSet<Models.TestResultParameter> TestResultParameters { get; set; }

        public DbSet<Models.TestResult> TestResults { get; set; }

        public DataContext() : base ("DataContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Models.TestParameter>()
                .HasRequired(test => test.Test)
                .WithMany(test => test.Parameters)
                .HasForeignKey(p => p.TestId);

            modelBuilder.Entity<Models.EcuParameter>()
                .HasRequired(ecu => ecu.Ecu)
                .WithMany(ecu => ecu.Parameters)
                .HasForeignKey(p => p.EcuId);

            modelBuilder.Entity<Models.TestResultParameter>()
                .HasRequired(result => result.TestResult)
                .WithMany(result => result.Parameters)
                .HasForeignKey(p => p.TestResultId);

            modelBuilder.Entity<Models.TestResult>()
                .HasOptional(result => result.Test)
                .WithMany(test => test.Results)
                .HasForeignKey(result => result.TestId);

            modelBuilder.Entity<Models.TestResult>()
                .HasOptional(result => result.Ecu)
                .WithMany(ecu => ecu.Results)
                .HasForeignKey(result => result.EcuId);
        }
    }

    class DbInitialiser : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x01 - OBDII - Powertrain Diagnostic Data", 
                    Script = @"Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_REQUEST_CURRENT_POWERTRAIN_DIAGNOSTIC_DATA);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_PID, ""00"");"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x02 - OBDII - Powertrain Freeze Frame Data", 
                    Script = @"Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_REQUEST_POWERTRAIN_FREEZE_FRAME_DATA);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_PID, ""00"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_FRAME, ""00"");"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x03 - OBDII - Emission Related DTCs", 
                    Script = "Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_REQUEST_EMISSION_RELATED_DIAGNOSTIC_TROUBLE_CODES);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x04 - OBDII - Clear Emission Related DTCs", 
                    Script = "Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_CLEAR_EMISSION_RELATED_DIAGNOSTIC_INFORMATION);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x06 - OBDII - On-Board Monitoring Test Results", 
                    Script = @"Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_REQUEST_ON_BOARD_MONITORING_TEST_RESULTS_FOR_SPECIFIC_MONITORED_SYSTEMS);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_OBDMID, ""00"");"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x07 - OBDII - Recent Emission-Related DTCs", 
                    Script = "Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_REQUEST_EMISSION_RELATED_DIAGNOSTIC_TROUBLE_CODES_DETECTED_DURING_CURRENT_OR_LAST_COMPLETED_DRIVING_CYCLE);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x08 - OBDII - Control of On-Board System", 
                    Script = @"Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_REQUEST_CONTROL_OF_ON_BOARD_SYSTEM_OR_TEST_OR_COMPONENT);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_TID, ""00"");"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x09 - OBDII - Vehicle Information", 
                    Script = @"Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_REQUEST_VEHICLE_INFORMATION);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_INFOTYPE, ""00"");"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x0A - OBDII - Permanent Emissions-Related DTCs", 
                    Script = "Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_REQUEST_EMISSION_RELATED_DIAGNOSTIC_TROUBLE_CODES_WITH_PERMANENT_STATUS);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x10 - UDS - Diagnostic Session Control / 0x01 Default Session", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_DIAGNOSTIC_SESSION_CONTROL, 
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_DEFAULT_SESSION);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x10 - UDS - Diagnostic Session Control / 0x02 Programming Session", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_DIAGNOSTIC_SESSION_CONTROL, 
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_PROGRAMMING_SESSION);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x10 - UDS - Diagnostic Session Control / 0x03 Extended Diagnostic Session", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_DIAGNOSTIC_SESSION_CONTROL, 
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_EXTENDED_DIAGNOSTIC_SESSION);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x10 - UDS - Diagnostic Session Control / 0x04 Safety System Diagnostic Session", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_DIAGNOSTIC_SESSION_CONTROL, 
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_SAFETY_SYSTEM_DIAGNOSTIC_SESSION);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x11 - UDS - ECU Reset / 0x01 Hard Reset", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_ECU_RESET,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_HARD_RESET);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x11 - UDS - ECU Reset / 0x02 Key Off On Reset", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_ECU_RESET,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_KEY_OFF_ON_RESET);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x11 - UDS - ECU Reset / 0x03 Soft Reset", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_ECU_RESET,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_SOFT_RESET);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x11 - UDS - ECU Reset / 0x04 Rapid Shut Down", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_ECU_RESET,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_ENABLE_RAPID_POWER_SHUT_DOWN);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x14 - UDS - Clear Diagnostic Information", 
                    Script = @"Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_CLEAR_DIAGNOSTIC_INFORMATION);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_GROUP_OF_DTC, ""[[GroupHigh]]"", ""[[GroupMid]]"", ""[[GroupLow]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "GroupHigh", Value = "06" },
                        new Models.TestParameter { Name = "GroupMid", Value = "99" },
                        new Models.TestParameter { Name = "GroupLow", Value = "00" }
                    }
                });

            context.Ecus.Add(
                new Models.Ecu
                {
                    Name = "ECU16",
                    DeviceName = "Diagnostics",
                    EcuName = "ECU16",
                    ProjectFile = "D:\\Shared\\VISION Demo\\Project1.vpj"
                });

            context.Ecus.Add(
                new Models.Ecu
                {
                    Name = "ECU24",
                    DeviceName = "Diagnostics",
                    EcuName = "ECU24",
                    ProjectFile = "D:\\Shared\\VISION Demo\\Project1.vpj"
                });

            base.Seed(context);
            context.SaveChanges();
        }
    }
}
