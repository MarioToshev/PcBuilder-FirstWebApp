using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Data.Entities
{
    [Table("PcStorage")]
    public class PcStorage
    {

        [Key]
        [Required]
        [ForeignKey("storageModel")]
        [Display(Name = "Model")]
        public string model { get; set; }
        [Required]
        [Display(Name = "SSD or HDD")]
        public string ssdOrHdd { get; set; }
        [Required]
        [Display(Name = "Memory size")]
        public string memeorySize { get; set; }
        [Required]
        [Display(Name = "Read Speed")]
        public string readSpeed { get; set; }
        [Required]
        [Display(Name = "Write Speed")]
        public string writeSpeed { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double price { get; set; }
       
    }
}
