using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Attila.Domain.Entities.Tables;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;

namespace Attila.Infrastructure.Persistence
{
    public class AttilaDbContext : DbContext, IAttilaDbContext
    {
        public DbSet<EquipmentDetails> EquipmentsDetails { get; set; }

        public DbSet<EquipmentInventory> EquipmentsInventory { get; set; }

        public DbSet<EquipmentRestock> EquipmentsRestock { get; set; }

        public DbSet<EquipmentRestockRequest> EquipmentRestockRequests { get; set; }

        public DbSet<EventClient> EventClients { get; set; }

        public DbSet<EventDetails> EventsDetails { get; set; }

        public DbSet<EventEquipments> EventsEquipments { get; set; }

        public DbSet<EventEquipmentRequest> EventEquipmentRequest { get; set; }

        public DbSet<PackageDetails> EventsPackageDetails { get; set; }

        public DbSet<EventPaymentStatus> EventsPaymentStatus { get; set; }

        public DbSet<FoodDetails> FoodsDetails { get; set; }

        public DbSet<FoodInventory> FoodsInventory { get; set; }

        public DbSet<FoodRestock> FoodsRestock { get; set; }

        public DbSet<FoodRestockRequest> FoodRestockRequests { get; set; }

        public DbSet<EventAdditionalDurationRequest> EventAdditionalDurationRequests { get; set; }

        public DbSet<EventAdditionalEquipmentRequest> EventAdditionalEquipmentRequests { get; set; }

        public DbSet<User> Users { get; set; }


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
