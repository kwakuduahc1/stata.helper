using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
