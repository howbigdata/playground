using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LcaWorld.Models
{
    public class Compartment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Compartment Name")]
        [Required]
        public string Name { get; set; }
    }
}