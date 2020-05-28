using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Data.Models.Component
{
    public class ComputerDto
    {
        public int id { get; set; }
        [Required]
        public string cpuModel { get; set; }
        [Required]
        public string gpuModel { get; set; }
        [Required]
        public string ramModel { get; set; }
        [Required]
        public string motherboardModel { get; set; }
        [Required]
        public string storageModel { get; set; }
        [Required]
        public string psuModel { get; set; }
        [Required]
        public string pcCaseModel { get; set; }
        [Required]
        public double price { get; set; }
    }
}
