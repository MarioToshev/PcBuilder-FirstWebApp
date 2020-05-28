using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Data.Entities
{
    [Table("Computer")]
    public class Computer
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="CPU")]
        public string cpuModel { get; set; }
        [Required]
        [Display(Name = "GPU")]
        public string gpuModel { get; set; }
        [Required]
        [Display(Name = "RAM")]
        public string ramModel { get; set; }
        [Required]
        [Display(Name = "Motherboard")]
        public string motherboardModel { get; set; }
        [Required]
        [Display(Name = "Storage")]
        public string storageModel { get; set; }
        [Required]
        [Display(Name = "PSU")]
        public string psuModel { get; set; }
        [Required]
        [Display(Name = "Case")]
        public string pcCaseModel { get; set; }
        [Required]
        [Display(Name = "Price in USD$")]
        public double price { get; set; }
    }
}
