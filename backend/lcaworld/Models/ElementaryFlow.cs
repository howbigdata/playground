using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LcaWorld.Models
{
    public class ElementaryFlow
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  String Name { get; set; }

        [Display(Name = "Compartment")]
        public int CompartmentId { get; set; }

        [ForeignKey("CompartmentId")]
        public virtual Compartment Compartment { get; set; }

        [Display(Name = "SubCompartment")]
        public int SubCompartmentId { get; set; }

        [ForeignKey("SubCompartmentId")]
        public virtual SubCompartment SubCompartment { get; set; }

        [Display(Name = "Unit")]
        public int UnitId { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }
    }
}
