using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LcaWorld.Models
{
    public class SubCompartment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "SubCompartment Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Compartment")]
        public int CompartmentId { get; set; }

        [ForeignKey("CompartmentId")]
        public virtual Compartment Compartment { get; set; }

    }
}