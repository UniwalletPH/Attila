using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class User : BaseAuditedEntity
    {        
        public Guid UID { get; set; }

        public string Name { get; set; }

        public string Position{ get; set; }

        public string ContactNumber { get; set; }

        public string Email{ get; set; }

        public AccessRole Role { get; set; }


        [InverseProperty("User")]
        public UserLogin UserLogins { get; set; }

        public ICollection<EquipmentInventory> EquipmentInventories { get; private set; } = new HashSet<EquipmentInventory>();

        public ICollection<EquipmentRestockRequest> EquipmentRestockRequests { get; set; } = new HashSet<EquipmentRestockRequest>();

        public ICollection<Event> Events { get; private set; } = new HashSet<Event>();

        public ICollection<FoodInventory> FoodInventories { get; private set; } = new HashSet<FoodInventory>();

        public ICollection<FoodRestockRequest> FoodRestockRequests { get; private set; } = new HashSet<FoodRestockRequest>();

        public ICollection<Notifications> Notifications { get; private set; } = new HashSet<Notifications>();



    }
}
