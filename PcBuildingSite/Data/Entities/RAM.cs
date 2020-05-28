using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Data.Entities
{
    [Table("Ram")]
    public class RAM
    {
        [Key]
        [ForeignKey("ramModel")]
        [Required]
        [Display(Name ="Model")]
        public string model { get; set; }
        [Required]
        [Display(Name = "Frequency")]
        public double frequency { get; set; }
        [Required]
        [Display(Name = "Memory Size")]
        public double memorysize { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double price { get; set; }
       
    }
}
