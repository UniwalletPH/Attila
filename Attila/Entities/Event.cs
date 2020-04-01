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
        public int ClientID { get; set; }


     

        public string Theme { get; set; }

        public string EventName { get; set; }

        public EventType Type { get; set; }

        public Status EventStatus { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Remarks { get; set; }

        public int CoordinatorID { get; set; }

        public User Coordinator { get; set; }



        public int NumberOfGuests { get; set; }

        public TimeSpan ProgramStart { get; set; }

        public TimeSpan EntryTime { get; set; }

        public TimeSpan ServingTime { get; set; }

        public ServingType ServingType { get; set; }

        public VenueType VenueType { get; set; }

        public LocationType LocationType { get; set; } 

        public ICollection<PaymentStatus> Payments { get; set; }




        public EventPackage EventPackage { get; set; }

        public Client Client { get; set; }

    }
}
