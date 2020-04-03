using Attila.Domain.Entities.Base;
using System.Collections.Generic;

namespace Attila.Domain.Entities
{
    public class Equipment : BaseAuditedEntity
    {     
        public string Code { get; set; } 

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal RentalFee { get; set; }

        public UnitType UnitType { get; set; }

        public EquipmentType EquipmentType { get; set; }


        public ICollection<EventEquipment> EventEquipments { get; private set; } = new HashSet<EventEquipment>();
        public ICollection<EventPackageEquipment> EventPackageEquipments { get; private set; } = new HashSet<EventPackageEquipment>();
        public ICollection<EquipmentInventory> EquipmentInventories { get; private set; } = new HashSet<EquipmentInventory>();
        public ICollection<EventAdditionalEquipmentRequest> EventAdditionalEquipmentRequests { get; private set; } = new HashSet<EventAdditionalEquipmentRequest>();

    }
}
