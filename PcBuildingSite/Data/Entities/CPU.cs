using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Data.Entities
{
	[Table("CPU")]
    public class CPU
    {
		[Key]
		[Required]
		[ForeignKey("cpuModel")]
		[Display(Name = "Model")]
		public string model { get; set; }
		[Required]
		[Display(Name = "Socket")]
		public string socket { get; set; }
		[Required]
		[Display(Name = "Frequency(Mhz)")]
		public double frequency { get; set; }
		[Required]
		[Display(Name = "Cores")]
		public int cores { get; set; }
		[Required]
		[Display(Name = "Threads")]
		public int threads { get; set; }
		[Required]
		[Display(Name = "TDP(W)")]
		public int tdp { get; set; }
		[Required]
		[Display(Name = "Brand")]
		public string cpuBrand { get; set; }
		[Required]
		[Display(Name = "Generation")]
		public string generation { get; set; }
		[Required]
		[Display(Name = "Price(USD)")]
		public double price { get; set; }
		
	}
}
