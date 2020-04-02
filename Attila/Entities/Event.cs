using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class Event : BaseAuditedEntity
    {
        [ForeignKey("EventPackage")]
        public int EventPackageID { get; set; }
        [ForeignKey("Client")]
        public int ClientID { get; set; }
        [ForeignKey("Coordinator")]
        public int CoordinatorID { get; set; }

        public string Theme { get; set; }
        public string EventName { get; set; }
        public EventType Type { get; set; }
        public Status EventStatus { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Remarks { get; set; }
        public int NumberOfGuests { get; set; }
        public TimeSpan ProgramStart { get; set; }
        public TimeSpan EntryTime { get; set; }
        public TimeSpan ServingTime { get; set; }
        public ServingType ServingType { get; set; }
        public VenueType VenueType { get; set; }
        public LocationType LocationType { get; set; }

        public User Coordinator { get; set; }
        public EventPackage EventPackage { get; set; }
        public Client Client { get; set; }
        public ICollection<EventEquipment> EventEquipments { get; private set; } = new HashSet<EventEquipment>();
        public ICollection<EventAdditionalDurationRequest> EventAdditionalDurationRequests { get; private set; } = new HashSet<EventAdditionalDurationRequest>();
        public ICollection<EventAdditionalEquipmentRequest> EventAdditionalEquipmentRequests { get; private set; } = new HashSet<EventAdditionalEquipmentRequest>();
        public ICollection<EventMenu> EventMenus { get; private set; } = new HashSet<EventMenu>();
        public ICollection<PaymentStatus> Payments { get; private set; } = new HashSet<PaymentStatus>();


    }
}
