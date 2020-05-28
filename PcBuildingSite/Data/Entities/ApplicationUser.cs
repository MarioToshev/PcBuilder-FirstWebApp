using Microsoft.AspNetCore.Identity;
using PcBuildingSite.Data.Entities;
using System;
using System.Collections.Generic;

namespace Data
{
    public class ApplicationUser: IdentityUser<int>
    {
        
        public List<Computer> userComputer;
    }
}
