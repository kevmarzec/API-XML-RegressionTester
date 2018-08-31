namespace TestBuilder.Models
{
    public class TestParameter : Parameter
    {   
        public int? TestId { get; set; }

        public Test Test { get; set; }
    }
}
