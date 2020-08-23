using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LcaWorld.Models
{
    public class ProcessExchanges
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProcessId { get; set; }

        [ForeignKey("ProcessId")]
        public virtual Process Process { get; set; }

        [Required]
        public int ElementaryFlowId { get; set; }

        [ForeignKey("ElementaryFlowId")]
        public virtual ElementaryFlow ElementaryFlow { get; set; }

        [Required]
        public double Value { get; set; }

    }
}
