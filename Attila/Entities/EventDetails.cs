using Attila.Domain.Enums;
using System;

namespace Attila.Domain.Entities
{
    public class EventDetails
    {
        public PackageMenuDetails? PackageDetails { get; set; }
        public ClientDetails? EventClient { get; set; }
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

        public User User { get; set; }

        public int PackageDetailsID { get; set; }

        public int EventClientID { get; set; }

        public int NumberOfGuests { get; set; }

        public TimeSpan ProgramStart { get; set; }

        public TimeSpan EntryTime { get; set; }

        public TimeSpan ServingTime { get; set; }

        public ServingType ServingType { get; set; }

        public VenueType VenueType { get; set; }

        public LocationType LocationType { get; set; }

    }
}
