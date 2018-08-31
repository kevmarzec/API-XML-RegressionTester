
namespace TestBuilder.Models
{
    public class TestResultParameter : Parameter
    {   
        public int? TestResultId { get; set; }

        public TestResult TestResult { get; set; }
    }
}
