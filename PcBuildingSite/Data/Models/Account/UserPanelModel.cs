using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcBuildingSite.Data.Models.Account
{
    public class UserPanelModel
    {
        [Key]
        public string adminPassword { get; set; }
    }
}
