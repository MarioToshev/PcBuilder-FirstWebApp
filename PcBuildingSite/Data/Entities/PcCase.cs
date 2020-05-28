using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Data.Entities
{
    [Table ("PcCase")]
    public class PcCase
    {
        [Key]
        [Required]
        [ForeignKey("caseModel")]
        [Display(Name = "Model")]
        public string model { get; set; }
        [Required]
        [Display(Name = "Form factor")]
        public string formfactor { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double price { get; set; }
        

       
    }
}
