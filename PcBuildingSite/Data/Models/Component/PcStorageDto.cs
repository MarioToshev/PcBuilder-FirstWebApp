using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Data.Models.Component
{
    public class PcStorageDto
    {
        [Required]
        public string model { get; set; }
        [Required]
        public string ssdOrHdd { get; set; }
        [Required]
        public string memeorySize { get; set; }
        [Required]
        public string readSpeed { get; set; }
        [Required]
        public string writeSpeed { get; set; }
        [Required]
        public double price { get; set; }
    }
}
