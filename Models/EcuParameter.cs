namespace TestBuilder.Models
{
    public class EcuParameter : Parameter
    {   
        public int EcuId { get; set; }

        public Ecu Ecu { get; set; }
    }
}
