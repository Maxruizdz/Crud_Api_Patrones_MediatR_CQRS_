using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataServices.Data
{
    public  class AppDbContext : DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }

        public virtual DbSet<Achievement> Achievements { get; set;}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Achievement>(options => { 
            
            options.HasOne(p=> p.Driver).WithMany(p=> p.achievements).HasForeignKey(p=>p.DriverId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_Achievements_Driver");
            
            
            
            });
        }
    }
}
