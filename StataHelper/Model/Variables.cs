using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StataHelper.Model
{
    public class Variables
    {
        public short VariablesID { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 1)]
        public string Variable { get; set; }

        [Required]
        public short ProjectsID { get; set; }

        [StringLength(20, MinimumLength = 2)]
        public string Description { get; set; }

        [ConcurrencyCheck, Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual Projects Projects { get; set; }

        public virtual ICollection<Varlabs> Varlabs { get; set; }
    }
}
