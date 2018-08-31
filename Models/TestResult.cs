using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestBuilder.Models
{
    public enum ResultState
    {
        NoVerifiedResult = 0,
        Verified = 1,
        FailedVerification = 2,
        IsVerifiedResult = 3
    }

    public class TestResult
    {
        [Key]
        public int Id { get; set; }
        
        public int? EcuId { get; set; }
        public Ecu Ecu { get; set; }

        public int? TestId { get; set; }
        public Test Test { get; set; }

        public string Version { get; set; }

        public DateTime TestTime { get; set; }

        public string Output { get; set; }

        public string Script { get; set; }

        public ResultState Verified { get; set; }

        public ICollection<TestResultParameter> Parameters { get; set; }
    }
}
