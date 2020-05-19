using Attila.Domain.Entities;
using Attila.Domain;
using System;
using System.Collections.Generic;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class EventDetailsVM
    {
        public int ID { get; set; }

        public string Theme { get; set; }

        public string EventName { get; set; }

        public EventType Type { get; set; }

        public Status EventStatus { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Remarks { get; set; }

        public int UserID { get; set; }
         
        public int PackageDetailsID { get; set; }

        public int EventClientID { get; set; }

        public int NumberOfGuests { get; set; }

        public TimeSpan ProgramStart { get; set; }

        public TimeSpan EntryTime { get; set; }

        public TimeSpan ServingTime { get; set; }

        public ServingType ServingType { get; set; }

        public VenueType VenueType { get; set; }

        public LocationType LocationType { get; set; }

        public EventPackage Package { get; set; }

        public Client Client { get; set; }

        public decimal ToPay { get; set; }

        public User User { get; set; }

        public ICollection<EventMenuVM> EventMenu { get; set; }

        public List<AdditionalDishVM> AdditionalDish { get; set; }

        public List<AdditionalDurationRequestVM> AdditionalDuration { get; set; }

        public List<AdditionalEquipmentRequestListVM> AdditionalEquipment { get; set; }


    }
}
