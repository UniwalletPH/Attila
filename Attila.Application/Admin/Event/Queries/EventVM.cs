using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Admin.Event.Queries
{
    public class EventVM
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string EventName { get; set; }

        public EventType Type { get; set; }

        public Status EventStatus { get; set; }

        public string Address { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Remarks { get; set; }

        public User Coordinator { get; set; }

        public PackageMenuDetails  Package{ get; set; }

        public Client Client { get; set; }

        public List<EventAdditionalEquipmentRequest> AdditionalEquipment { get; set; }

        public EventAdditionalDurationRequest AdditionalDuration { get; set; }
    }
}
