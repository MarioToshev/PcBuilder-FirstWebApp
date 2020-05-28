using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Data.Models.Component
{
    public class RamDto
    {
        [Required]   
        public string model { get; set; }
        [Required]      
        public double frequency { get; set; }
        [Required]    
        public double memorysize { get; set; }
        [Required]     
        public double price { get; set; }
    }
}
