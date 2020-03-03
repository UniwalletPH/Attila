using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;

namespace Attila.Application.Interfaces
{
    public interface IAttilaDbContext
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


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
