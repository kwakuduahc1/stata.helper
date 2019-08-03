using System.ComponentModel.DataAnnotations;

namespace StataHelper.Model
{
    public class Commands
    {
        [Key]
        public short CommandsID { get; set; }

        [StringLength(200, MinimumLength = 5)]
        [Required]
        public string Command { get; set; }

        [Required]
        public short ProjectsID { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual Projects Projects { get; set; }

    }
}
