using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestBuilder.Models
{    
    public class Parameter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
