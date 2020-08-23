using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LcaWorld.Models
{
    public class CharacterisationFactor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MethodId { get; set; }

        [ForeignKey("MethodId")]
        public virtual Method Method { get; set; }

        [Required]
        public int ElementaryFlowId { get; set; }

        [ForeignKey("ElementaryFlowId")]
        public virtual ElementaryFlow ElementaryFlow { get; set; }

        [Required]
        public double Factor { get; set; }

    }
}
