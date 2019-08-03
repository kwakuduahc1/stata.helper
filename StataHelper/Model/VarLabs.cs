using System.ComponentModel.DataAnnotations;

namespace StataHelper.Model
{
    public class Varlabs
    {
        [Key]
        public short VarlabsID { get; set; }

        [Required]
        public short VariablesID { get; set; }

        [Required]
        public short LabelsID { get; set; }

        public virtual Labels Labels { get; set; }

        public virtual Variables Variables { get; set; }
    }
}
