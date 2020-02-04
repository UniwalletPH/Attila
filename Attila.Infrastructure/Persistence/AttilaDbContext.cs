using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Atilla.Domain.Entities.Tables;
using Atilla.Application.Interfaces;
using Atilla.Domain.Entities;
using Attila.Domain.Entities;

namespace Atilla.Infrastructure.Persistence
{
    public class AttilaDbContext : DbContext, IAttilaDbContext
    {
        public DbSet<EventEquipmentRequest> EventEquipmentRequest { get; set; }
        public DbSet<EquipmentDelivery> EquipmentsDelivery { get; set; }

        public DbSet<EquipmentDetails> EquipmentsDetails { get; set; }

        public DbSet<EquipmentInventory> EquipmentsInventory { get; set; }

        public DbSet<EquipmentRestockRequest> EquipmentRestockRequests { get; set; }

        public DbSet<EventClient> EventClients { get; set; }

        public DbSet<EventDetails> EventsDetails { get; set; }

        public DbSet<EventEquipments> EventsEquipments { get; set; }

        public DbSet<EventPackageDetails> EventsPackageDetails { get; set; }

        public DbSet<EventPaymentStatus> EventsPaymentStatus { get; set; }

        public DbSet<FoodDetails> FoodsDetails { get; set; }

        public DbSet<FoodInventory> FoodsInventory { get; set; }

        public DbSet<FoodRestock> FoodsRestock { get; set; }

        public DbSet<FoodRestockRequest> FoodRestockRequests { get; set; }

        public DbSet<PackageAdditionalDurationRequest> PackageAdditionalDurationRequests { get; set; }

        public DbSet<PackageAdditionalEquipmentRequest> PackageAdditionalEquipmentRequests { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserMap> UserMaps { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AttilaDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AttilaDbContext).Assembly);
        }

    }
}
