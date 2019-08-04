using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StataHelper.Model
{
    public class Labels
    {
        [Key]
        public int LabelsID { get; set; }

        [Required]
        public short LabelCollectionsID { get; set; }

        [Required]
        [Range(0, 20)]
        public byte Key { get; set; }

        [Required, StringLength(15, MinimumLength = 2)]
        public string Label { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual LabelCollections LabelCollections { get; set; }

        public virtual ICollection<Varlabs> Varlabs { get; set; }
    }
}
