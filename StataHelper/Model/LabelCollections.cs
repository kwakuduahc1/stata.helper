using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StataHelper.Model
{
    public class LabelCollections
    {
        [Key]
        public short LabelCollectionsID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LabelName { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string Description { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<Labels> Labels { get; set; }
    }
}
