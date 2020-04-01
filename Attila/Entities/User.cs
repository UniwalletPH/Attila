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

        public ICollection<EquipmentInventory> EquipmentInventories { get; set; }

        public ICollection<EquipmentRestockRequest> EquipmentRestockRequests { get; set; }

        public ICollection<Event> Events { get; set; }

        public ICollection<FoodInventory> FoodInventories { get; set; }

        public ICollection<FoodRestockRequest> FoodRestockRequests { get; set; }

        public ICollection<Notifications> Notifications { get; set; }



    }
}
