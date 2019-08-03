using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StataHelper.Model
{
    public class Labels
    {
        [Key]
        public int LabelsID { get; set; }

        [Required]
        public byte Key { get; set; }

        [Required, StringLength(15, MinimumLength = 2)]
        public string Label { get; set; }

        public string Description { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<Varlabs> Varlabs { get; set; }
    }
}
