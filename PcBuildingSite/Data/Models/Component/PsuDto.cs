using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Data.Models.Component
{
    public class PsuDto
    {
        [Required]
        public string model { get; set; }
        [Required]
        public int powerEfficiency { get; set; }
        [Required]
        public double price { get; set; }
    }
}
