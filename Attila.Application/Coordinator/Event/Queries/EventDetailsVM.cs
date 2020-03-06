using Attila.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Attila.Application.Coordinator.Event.Queries
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

        public DateTime ProgramStart { get; set; }

        public DateTime EntryTime { get; set; }

        public DateTime ServingTime { get; set; }

        public ServingType ServingType { get; set; }

    }
}
