using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Data.Models.Component
{
	public class GpuDto
	{
		[Required]
		public string model { get; set; }
		[Required]
		public double frequency { get; set; }
		[Required]
		public double vramSpeed { get; set; }
		[Required]
		public int cores { get; set; }
		public int rtCores { get; set; }
		[Required]
		public int memoryQuantity { get; set; }
		[Required]
		public int tdp { get; set; }
		[Required]
		public bool SliCrossfireSupport { get; set; }
		[Required]
		public double price { get; set; }
	}
}
