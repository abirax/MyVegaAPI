using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyVegaApi.Models;

namespace MyVegaApi.Persistence
{
    public class VegaDbContext:DbContext
    {
        public DbSet<Model> Models { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<VehicleFeatures> VehicleFeatures { get; set; } 


        public VegaDbContext(DbContextOptions<VegaDbContext> options)
          : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeatures>().HasKey(vf => new { vf.VehicleID, vf.FeatureID });
        }

    }
}
