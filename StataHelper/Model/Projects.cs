using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StataHelper.Model
{
    public class Projects
    {
        [Key]
        public short ProjectsID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Project { get; set; }

        [StringLength(150, MinimumLength = 10)]
        public string Description { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<Variables> Variables { get; set; }
    }
}
