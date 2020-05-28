using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Data.Entities
{
    [Table ("Motherboard")]
    public class Motherboard
    {
        [Key]
        [Required]
        [ForeignKey("motherboardModel")]
        [Display(Name = "Model")]
        public string model { get; set; }
        [Required]
        [Display(Name = "Socket")]
        public string socket { get; set; }
        [Required]
        [Display(Name = "RAM slots count")]
        public string ramSlots { get; set; }
        [Required]
        [Display(Name = "Form factor")]
        public string formfactor { get; set; }
        [Required]
        [Display(Name = "Sli or Crossfire support")]
        public bool sliCrossfireSuport { get; set; }
        [Required]
        [Display(Name = "Supported Generation")]
        public string suportedGeneration { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double price { get; set; }
        
    }
}
