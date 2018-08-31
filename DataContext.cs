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
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_GROUP_OF_DTC, ""[[14-GroupHigh]]"", ""[[14-GroupMid]]"", ""[[14-GroupLow]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "14-GroupHigh", Value = "06" },
                        new Models.TestParameter { Name = "14-GroupMid", Value = "99" },
                        new Models.TestParameter { Name = "14-GroupLow", Value = "00" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x01 - UDS - # DTC by Status Mask", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_NUMBER_OF_DTC_BY_STATUS_MASK);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_STATUS_MASK, ""[[19-1-DTCStatusMask]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-1-DTCStatusMask", Value = "FF" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x02 - UDS - DTCs by Status Mask", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_DTC_BY_STATUS_MASK);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_STATUS_MASK, ""[[19-2-DTCStatusMask]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-2-DTCStatusMask", Value = "04" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x03 - UDS - DTC Snapshot Identification", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_DTC_SNAPSHOT_IDENTIFICATION);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x04 - UDS - DTC Snapshot Rec by DTC #", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_DTC_SNAPSHOT_RECORD_BY_DTC_NUMBER);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_MASK_RECORD, ""[[19-4-MaskRecordHigh]]"", ""[[19-4-MaskRecordMid]]"", ""[[19-4-MaskRecordLow]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_SNAPSHOT_RECORD_NUMBER, ""[[19-4-RecordNumber]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_SNAPSHOT_RECORD_LENGTH, ""[[19-4-RecordLength]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-4-MaskRecordHigh", Value = "06" },
                        new Models.TestParameter { Name = "19-4-MaskRecordMid", Value = "99" },
                        new Models.TestParameter { Name = "19-4-MaskRecordLow", Value = "00" },
                        new Models.TestParameter { Name = "19-4-RecordNumber", Value = "FF" },
                        new Models.TestParameter { Name = "19-4-RecordLength", Value = "0F" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x05 - UDS - DTC Stored Data by Rec #", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_DTC_STORED_DATA_BY_RECORD_NUMBER);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_STORED_DATA_RECORD_NUMBER, ""[[19-5-RecordNumber]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_STORED_DATA_RECORD_LENGTH, ""[[19-5-RecordLength]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-5-RecordNumber", Value = "CA" },
                        new Models.TestParameter { Name = "19-5-RecordLength", Value = "FF" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x06 - UDS - DTC Extended Data by DTC #", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_DTC_EXTENDED_DATA_RECORD_BY_DTC_NUMBER);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_MASK_RECORD, ""[[19-6-MaskRecordHigh]]"", ""[[19-6-MaskRecordMid]]"", ""[[19-6-MaskRecordLow]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_EXTENDED_DATA_RECORD_NUMBER, ""[[19-6-RecordNumber]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_EXTENDED_DATA_RECORD_LENGTH, ""[[19-6-RecordLength]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-4-MaskRecordHigh", Value = "06" },
                        new Models.TestParameter { Name = "19-4-MaskRecordMid", Value = "99" },
                        new Models.TestParameter { Name = "19-4-MaskRecordLow", Value = "00" },
                        new Models.TestParameter { Name = "19-6-RecordNumber", Value = "FF" },
                        new Models.TestParameter { Name = "19-6-RecordLength", Value = "00" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x07 - UDS - # DTC by Severity Mask", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_NUMBER_OF_DTC_BY_SEVERITY_MASK_RECORD);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_SEVERITY_MASK, ""[[19-7-SeverityMask]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_STATUS_MASK, ""[[19-7-StatusMask]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-7-SeverityMask", Value = "FF" },
                        new Models.TestParameter { Name = "19-7-StatusMask", Value = "04" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x08 - UDS - DTC by Severity Mask", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_DTC_BY_SEVERITY_MASK_RECORD);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_SEVERITY_MASK, ""[[19-8-SeverityMask]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_STATUS_MASK, ""[[19-8-StatusMask]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-8-SeverityMask", Value = "FF" },
                        new Models.TestParameter { Name = "19-8-StatusMask", Value = "04" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x09 - UDS - Severity Info of DTC", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_SEVERITY_INFORMATION_OF_DTC);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_MASK_RECORD, ""[[19-9-GroupHigh]]"", ""[[19-9-GroupMid]]"", ""[[19-9-GroupLow]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-9-GroupHigh", Value = "06" },
                        new Models.TestParameter { Name = "19-9-GroupMid", Value = "99" },
                        new Models.TestParameter { Name = "19-9-GroupLow", Value = "00" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x0A - UDS - Supported DTCs", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_SUPPORTED_DTC);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x0B - UDS - First Test Failed DTC", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_FIRST_TEST_FAILED_DTC);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x0C - UDS - First Confirmed DTC", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_FIRST_CONFIRMED_DTC);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x0D - UDS - Most Recent Test Failed DTC", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_MOST_RECENT_TEST_FAILED_DTC);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x0E - UDS - Most Recent Confirmed DTC", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_MOST_RECENT_CONFIRMED_DTC);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x0F - UDS - Mirror Memory DTC by Status Mask", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_MIRROR_MEMORY_DTC_BY_STATUS_MASK);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_STATUS_MASK, ""[[19-F-StatusMask]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-F-StatusMask", Value = "FF" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x10 - UDS - Extended Data Record by DTC #", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_MIRROR_MEMORY_DTC_EXTENDED_DATA_RECORD_BY_DTC_NUMBER);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_MASK_RECORD, ""[[19-10-MaskHigh]]"", ""[[19-10-MaskMid]]"", ""[[19-10-MaskLow]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_EXTENDED_DATA_RECORD_NUMBER, ""[[19-10-RecordNumber]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_EXTENDED_DATA_RECORD_LENGTH, ""[[19-10-RecordLength]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-10-MaskHigh", Value = "06" },
                        new Models.TestParameter { Name = "19-10-MaskMid", Value = "99" },
                        new Models.TestParameter { Name = "19-10-MaskLow", Value = "00" },
                        new Models.TestParameter { Name = "19-10-RecordNumber", Value = "FF" },
                        new Models.TestParameter { Name = "19-10-RecordLength", Value = "FF" },
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x11 - UDS - # Mirror Memory DTC by Status Mask", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_NUMBER_OF_MIRROR_MEMORY_DTC_BY_STATUS_MASK);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_STATUS_MASK, ""[[19-11-StatusMask]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-11-StatusMask", Value = "FF" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x12 - UDS - # Emissions DTC by Status Mask", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_NUMBER_OF_EMISSIONS_OBD_DTC_BY_STATUS_MASK);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_STATUS_MASK, ""[[19-12-StatusMask]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-12-StatusMask", Value = "FF" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x13 - UDS - Emissions DTC by Status Mask", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_EMISSIONS_OBD_DTC_BY_STATUS_MASK);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_STATUS_MASK, ""[[19-13-StatusMask]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-13-StatusMask", Value = "04" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x14 - UDS - Fault Detection Counter", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_DTC_FAULT_DETECTION_COUNTER);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x15 - UDS - Permanent Status DTCs", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_DTC_WITH_PERMANENT_STATUS);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x16 - UDS - Ext Data Record by Rec #", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_DTC_EXT_DATA_RECORD_BY_RECORD_NUMBER);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_EXTENDED_DATA_RECORD_NUMBER, ""[[19-16-RecordNumber]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_EXTENDED_DATA_RECORD_LENGTH, ""[[19-16-RecordLength]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-16-RecordNumber", Value = "68" },
                        new Models.TestParameter { Name = "19-16-RecordLength", Value = "80" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x17 - UDS - User Def Memory DTC by Status Mask", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_USER_DEF_MEMORY_DTC_BY_STATUS_MASK);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_STATUS_MASK, ""[[19-17-StatusMask]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_MEMORY_SELECTION, ""[[19-17-MemorySelection]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-17-StatusMask", Value = "04" },
                        new Models.TestParameter { Name = "19-17-MemorySelection", Value = "FF" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x18 - UDS - Snapshot Record by DTC #", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_USER_DEF_MEMORY_DTC_SNAPSHOT_RECORD_BY_DTC_NUMBER);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_MASK_RECORD, ""[[19-18-MaskHigh]]"", ""[[19-18-MaskMid]]"", ""[[19-18-MaskLow]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_MEMORY_SELECTION, ""[[19-18-MemorySelection]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_SNAPSHOT_RECORD_NUMBER, ""[[19-18-RecordNumber]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_SNAPSHOT_RECORD_LENGTH, ""[[19-18-RecordLength]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-18-MaskHigh", Value = "06" },
                        new Models.TestParameter { Name = "19-18-MaskMid", Value = "99" },
                        new Models.TestParameter { Name = "19-18-MaskLow", Value = "00" },
                        new Models.TestParameter { Name = "19-18-MemorySelection", Value = "FF" },
                        new Models.TestParameter { Name = "19-18-RecordNumber", Value = "FF" },
                        new Models.TestParameter { Name = "19-18-RecordLength", Value = "FF" },
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x19 - UDS - Ext Data Record by DTC #", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_USER_DEF_MEMORY_DTC_EXT_DATA_RECORD_BY_DTC_NUMBER);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_MASK_RECORD, ""[[19-19-MaskHigh]]"", ""[[19-19-MaskMid]]"", ""[[19-19-MaskLow]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_MEMORY_SELECTION, ""[[19-19-MemorySelection]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_EXTENDED_DATA_RECORD_NUMBER, ""[[19-19-RecordNumber]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_EXTENDED_DATA_RECORD_LENGTH, ""[[19-19-RecordLength]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-19-MaskHigh", Value = "06" },
                        new Models.TestParameter { Name = "19-19-MaskMid", Value = "99" },
                        new Models.TestParameter { Name = "19-19-MaskLow", Value = "00" },
                        new Models.TestParameter { Name = "19-19-MemorySelection", Value = "FF" },
                        new Models.TestParameter { Name = "19-19-RecordNumber", Value = "04" },
                        new Models.TestParameter { Name = "19-19-RecordLength", Value = "24" },
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x42 - UDS - WWH-OBD DTC by Mask Record", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_WWH_OBD_DTC_BY_MASK_RECORD);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_FUNCTIONAL_GROUP_IDENTIFIER, ""[[19-42-FunctionalGroup]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_STATUS_MASK, ""[[19-42-StatusMask]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DTC_SEVERITY_MASK, ""[[19-42-SeverityMask]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-42-FunctionalGroup", Value = "FF" },
                        new Models.TestParameter { Name = "19-42-StatusMask", Value = "04" },
                        new Models.TestParameter { Name = "19-42-SeverityMask", Value = "FF" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x19/0x55 - UDS - WWH-OBD DTC with Permanent Status", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DTC_INFORMATION,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_REPORT_WWH_OBD_DTC_WITH_PERMANENT_STATUS);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_FUNCTIONAL_GROUP_IDENTIFIER, ""[[19-55-FunctionalGroup]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "19-55-FunctionalGroup", Value = "83" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x22 - UDS - ReadDataByIdentifier", 
                    Script = @"Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_DATA_BY_IDENTIFIER);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DID, ""[[22-DID]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "22-DID", Value = "F810" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x23 - UDS - ReadMemoryByAddress", 
                    Script = @"Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_MEMORY_BY_ADDRESS);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_MEMORY_ADDRESS, ""[[22-MemoryAddress]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_MEMORY_SIZE, ""[[22-MemorySize]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_ADDRESS_AND_LENGTH_FORMAT_IDENTIFIER, ""[[22-FormatIdentifier]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "22-MemoryAddress", Value = "0A10" },
                        new Models.TestParameter { Name = "22-MemorySize", Value = "0010" },
                        new Models.TestParameter { Name = "22-FormatIdentifier", Value = "22" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x24 - UDS - ReadScalingDataByIdentifier", 
                    Script = @"Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_READ_SCALING_DATA_BY_IDENTIFIER);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DID, ""[[24-DID]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "24-DID", Value = "AD45" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x27/0x01 - UDS - SecurityAccess", 
                    Script = @"Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_SECURITY_ACCESS);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_SECURITY_ACCESS_TYPE, ""01"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DATA_RECORD, ""[[27-1-DataRecord]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "27-1-DataRecord", Value = "01" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x27/0x02 - UDS - SecurityAccess", 
                    Script = @"Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_SECURITY_ACCESS);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_SECURITY_ACCESS_TYPE, ""02"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_SECURITY_KEY, ""[[27-2-SecurityKey]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "27-2-SecurityKey", Value = "AABBCCDDEE" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x2C/0x01 - UDS - DynamicallyDefineDataIdentifier - By Identifier", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_DYNAMICALLY_DEFINE_DATA_IDENTIFIER, 
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_BY_IDENTIFIER);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DYNAMIC_DID, ""[[2C-1-DID]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DID, ""[[2C-1-DID1]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DID, ""[[2C-1-DID2]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DID, ""[[2C-1-DID3]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_POSITION_IN_SOURCE, ""[[2C-1-POSITION1]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_POSITION_IN_SOURCE, ""[[2C-1-POSITION2]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_POSITION_IN_SOURCE, ""[[2C-1-POSITION3]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_MEMORY_SIZE, ""[[2C-1-SIZE1]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_MEMORY_SIZE, ""[[2C-1-SIZE2]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_MEMORY_SIZE, ""[[2C-1-SIZE3]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "2C-1-DID", Value = "1010" },
                        new Models.TestParameter { Name = "2C-1-DID1", Value = "0101" },
                        new Models.TestParameter { Name = "2C-1-DID2", Value = "0102" },
                        new Models.TestParameter { Name = "2C-1-DID3", Value = "0103" },
                        new Models.TestParameter { Name = "2C-1-POSITION1", Value = "10" },
                        new Models.TestParameter { Name = "2C-1-POSITION2", Value = "20" },
                        new Models.TestParameter { Name = "2C-1-POSITION3", Value = "30" },
                        new Models.TestParameter { Name = "2C-1-SIZE1", Value = "1F" },
                        new Models.TestParameter { Name = "2C-1-SIZE2", Value = "2F" },
                        new Models.TestParameter { Name = "2C-1-SIZE3", Value = "3F" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x2C/0x02 - UDS - DyamicallyDefineDataIdentifier - By Address", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_DYNAMICALLY_DEFINE_DATA_IDENTIFIER, 
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_BY_ADDRESS);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DYNAMIC_DID, ""[[2C-2-DID]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_ADDRESS_AND_LENGTH_FORMAT_IDENTIFIER, ""[[2C-2-FormatIdentifier]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_MEMORY_ADDRESS, ""[[2C-2-MemoryAddress]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_MEMORY_SIZE, ""[[2C-2-MemorySize]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "2C-2-DID", Value = "0204" },
                        new Models.TestParameter { Name = "2C-2-FormatIdentifier", Value = "23" },
                        new Models.TestParameter { Name = "2C-2-MemoryAddress", Value = "121000" },
                        new Models.TestParameter { Name = "2C-2-MemorySize", Value = "0004" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x2C/0x03 - UDS - DyamicallyDefineDataIdentifier - Clear", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_DYNAMICALLY_DEFINE_DATA_IDENTIFIER, 
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_CLEAR);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DYNAMIC_DID, ""[[2C-3-DID]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "2C-3-DID", Value = "0204" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x2E - UDS - WriteDataByIdentifier", 
                    Script = @"Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_WRITE_DATA_BY_IDENTIFIER);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DID, ""[[2E-DID]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DATA_RECORD, ""[[2E-Data]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "2E-DID", Value = "00A0" },
                        new Models.TestParameter { Name = "2E-Data", Value = "101112131415161718" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x2F - UDS - InputOutputControlByIdentifier", 
                    Script = @"Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_INPUT_OUTPUT_CONTROL_BY_IDENTIFIER);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DID, ""[[2F-DID]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_CONTROL_OPTION_RECORD, ""[[2F-OptionRecord]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_CONTROL_ENABLE_MASK_RECORD, ""[[2F-MaskRecord]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "2F-DID", Value = "0102" },
                        new Models.TestParameter { Name = "2F-OptionRecord", Value = "12345678" },
                        new Models.TestParameter { Name = "2F-MaskRecord", Value = "FFFFFFFF" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x31/0x01 - UDS - RoutineControl - Start", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_ROUTINE_CONTROL,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_ROUTINE_START);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_RID, ""[[31-1-RID]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_CONTROL_OPTION_RECORD, ""[[31-1-OptionRecord]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "31-1-RID", Value = "0102" },
                        new Models.TestParameter { Name = "31-1-OptionRecord", Value = "1122" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x31/0x02 - UDS - RoutineControl - Stop", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_ROUTINE_CONTROL,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_ROUTINE_STOP);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_RID, ""[[31-2-RID]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_CONTROL_OPTION_RECORD, ""[[31-2-OptionRecord]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "31-2-RID", Value = "0102" },
                        new Models.TestParameter { Name = "31-2-OptionRecord", Value = "1122" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x31/0x03 - UDS - RoutineControl - Results", 
                    Script = @"Device.Service(
    VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_ROUTINE_CONTROL,
    VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_ROUTINE_RESULTS);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_RID, ""[[31-3-RID]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "31-3-RID", Value = "0102" },
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x3D - UDS - WriteMemoryByAddress", 
                    Script = @"device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_WRITE_MEMORY_BY_ADDRESS);
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_ADDRESS_AND_LENGTH_FORMAT_IDENTIFIER, ""[[3D-FormatIdentifier]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_MEMORY_ADDRESS, ""[[3D-MemoryAddress]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_MEMORY_SIZE, ""[[3D-MemorySize]]"");
Device.Parameter(VISION_DIAGNOSTICS_PARAMETER.VD_PARAMETER_DATA, ""[[3D-Data]]"");",
                    Parameters = new List<Models.TestParameter>
                    {
                        new Models.TestParameter { Name = "3D-FormatIdentifier", Value = "11" },
                        new Models.TestParameter { Name = "3D-MemoryAddress", Value = "08" },
                        new Models.TestParameter { Name = "3D-MemorySize", Value = "01" },
                        new Models.TestParameter { Name = "3D-Data", Value = "22" }
                    }
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x3E - UDS - Tester Present", 
                    Script = "Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_TESTER_PRESENT);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x85/0x01 - UDS - Control DTC Setting - On", 
                    Script = "Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_CONTROL_DTC_SETTING, VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_DTC_SETTING_ON);"
                });

            context.Tests.Add(
                new Models.Test 
                { 
                    Name = "0x85/0x02 - UDS - Control DTC Setting - Off", 
                    Script = "Device.Service(VISION_DIAGNOSTICS_SERVICE.VD_SERVICE_CONTROL_DTC_SETTING, VISION_DIAGNOSTICS_SUBFUNCTION.VD_SUB_DTC_SETTING_OFF);"
                });

            //////////////// ECUS /////////////
            
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
