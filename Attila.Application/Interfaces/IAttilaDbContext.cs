using Attila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Interfaces
{
    public interface IAttilaDbContext
    {

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<EquipmentInventory> EquipmentInventories { get; set; }

        public DbSet<EquipmentRestockRequest> EquipmentRestockRequests { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<FoodInventory> FoodInventories { get; set; }

        public DbSet<FoodRestockRequest> FoodRestockRequests { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<EventEquipment> EventEquipments { get; set; }

        public DbSet<EventPackage> EventPackages { get; set; }

        public DbSet<DishCategory> DishCategories { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<PaymentStatus> PaymentStatuses { get; set; }

        public DbSet<EventMenu> EventMenus { get; set; }

        public DbSet<EventAdditionalDurationRequest> EventAdditionalDurationRequests { get; set; }

        public DbSet<EventAdditionalEquipmentRequest> EventAdditionalEquipmentRequests { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }

        public DbSet<EventPackageDish> EventPackageDishes { get; set; }

        public DbSet<EventPackageEquipment> EventPackageEquipments { get; set; }

        public DbSet<Notifications> Notifications { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
