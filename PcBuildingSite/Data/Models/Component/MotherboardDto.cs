using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Data.Models.Component
{
    public class MotherboardDto
    {
        [Required]
        public string model { get; set; }
        [Required]       
        public string socket { get; set; }
        [Required]
        public string ramSlots { get; set; }
        [Required]
        public string formfactor { get; set; }
        [Required]
        public bool sliCrossfireSuport { get; set; }
        [Required]
        public string suportedGeneration { get; set; }
        [Required]
        public double price { get; set; }
    }
}
