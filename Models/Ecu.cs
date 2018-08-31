using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TestBuilder.Models
{
    public class Ecu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public override string ToString() => Name;

        public string ProjectFile { get; set; }

        public string DeviceName { get; set; }

        public string EcuName { get; set; }

        public string RequestId { get; set; }

        public string ResponseId { get; set; }

        public bool IsExtended { get; set; }

        public string DataFile { get; set; }

        public ICollection<EcuParameter> Parameters { get; set; }

        public ICollection<TestResult> Results { get; set; }

        public void SetParameters(DataContext db, List<KeyValuePair<string, string>> parameters)
        {
            db.EcuParameters.RemoveRange(Parameters);

            Parameters.Clear();
            parameters
                .Select(p => new EcuParameter 
                { 
                    EcuId = Id, 
                    Name = p.Key, 
                    Value = p.Value,
                    Ecu = this
                })
                .ToList()
                .ForEach(p => Parameters.Add(p));
        }

        public static Ecu Find(DataContext db, int id)
        {
            return db
                    .Ecus
                    .Include("Parameters")
                    .FirstOrDefault(t => t.Id == id);
        }

        public static List<Ecu> FindAll(DataContext db)
        {
            return db
                    .Ecus
                    .Include("Parameters")
                    .OrderBy(ecu => ecu.Name)
                    .ToList();
        }
    }
}
