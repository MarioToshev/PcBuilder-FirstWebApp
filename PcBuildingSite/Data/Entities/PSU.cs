using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Data.Entities
{
    [Table("Psu")]
    public class PSU
    {
        [Key]
        [Required]
        [ForeignKey("psuModel")]
        [Display(Name ="Model")]
        public string model { get; set; }
        [Required]
        [Display(Name = "Power Efficiency")]
        public int powerEfficiency { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double  price { get; set; }
    }
}
