using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PcBuildingSite.Data.Entities;
using PcBuildingSite.Models;


namespace Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        

        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }                
        public DbSet<Gpu> gpus { get; set; }
        public DbSet<CPU> cpus { get; set; }
        public DbSet<Motherboard> motherboards { get; set; }
        public DbSet<RAM> rams { get; set; }
        public DbSet<PcCase> cases { get; set; }
        public DbSet<PcStorage> storages { get; set; }
        public DbSet<PSU> psus { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<PcBuildingSite.Data.Entities.Computer> Computer { get; set; }
    }
}
