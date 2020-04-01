﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Attila.Domain.Entities.Tables;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using System.Linq;

namespace Attila.Infrastructure.Persistence
{
    public class AttilaDbContext : DbContext, IAttilaDbContext
    {
        public DbSet<Equipment> EquipmentDetails { get; set; }

        public DbSet<EquipmentInventory> EquipmentInventories { get; set; }

        public DbSet<EquipmentRestockRequest> EquipmentRestockRequests { get; set; }

        public DbSet<Food> FoodDetails { get; set; }

        public DbSet<FoodInventory> FoodInventories { get; set; }

        public DbSet<FoodRestockRequest> FoodRestockRequests { get; set; }

        public DbSet<Delivery> DeliveryDetails { get; set; }

        public DbSet<Event> EventDetails { get; set; }

        public DbSet<Client> ClientDetails { get; set; }

        public DbSet<EventEquipments> EventEquipments { get; set; }

        public DbSet<PackageMenuDetails> PackageMenuDetails { get; set; }

        public DbSet<DishCategory> MenuCategories { get; set; }

        public DbSet<Dish> Menus { get; set; }

        public DbSet<PaymentStatus> PaymentStatus { get; set; }

        public DbSet<EventMenus> EventMenus { get; set; }

        public DbSet<EventAdditionalDurationRequest> EventAdditionalDurationRequests { get; set; }

        public DbSet<EventAdditionalEquipmentRequest> EventAdditionalEquipmentRequests { get; set; }

        public DbSet<Supplier> SupplierDetails { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }

        public DbSet<PackageDish> PackageMenus { get ; set; }

        public DbSet<PackageEquipments> PackageEquipments { get ; set ; }

        public DbSet<Notifications> Notifications { get; set ; }

        public AttilaDbContext(DbContextOptions<AttilaDbContext> dbContextOpt) : base(dbContextOpt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AttilaDbContext).Assembly);

            /// Set all decimal SQL DataType
            foreach (var _property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                _property.SetColumnType("DECIMAL(20,8)");
            }
        }

    }
}
