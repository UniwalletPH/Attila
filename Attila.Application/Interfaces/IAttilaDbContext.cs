using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;

namespace Attila.Application.Interfaces
{
    public interface IAttilaDbContext
    {

        public DbSet<EquipmentDetails> EquipmentDetails { get; set; }

        public DbSet<EquipmentInventory> EquipmentInventories { get; set; }

        public DbSet<EquipmentRestockRequest> EquipmentRestockRequests { get; set; }

        public DbSet<FoodDetails> FoodDetails { get; set; }

        public DbSet<FoodInventory> FoodInventories { get; set; }

        public DbSet<FoodRestockRequest> FoodRestockRequests { get; set; }

        public DbSet<DeliveryDetails> DeliveryDetails { get; set; }

        public DbSet<EventDetails> EventDetails { get; set; }

        public DbSet<ClientDetails> ClientDetails { get; set; }

        public DbSet<EventEquipments> EventEquipments { get; set; }

        public DbSet<PackageMenuDetails> PackageMenuDetails { get; set; }

        public DbSet<MenuCategory> MenuCategories { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<PaymentStatus> PaymentStatus { get; set; }

        public DbSet<EventMenus> EventMenus { get; set; }

        public DbSet<EventAdditionalDurationRequest> EventAdditionalDurationRequests { get; set; }

        public DbSet<EventAdditionalEquipmentRequest> EventAdditionalEquipmentRequests { get; set; }

        public DbSet<SupplierDetails> SupplierDetails { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }

        public DbSet<PackageMenus> PackageMenus { get; set; }

        public DbSet<PackageEquipments> PackageEquipments { get; set; }

        public DbSet<Notifications> Notifications { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
