using Atilla.Domain.Enums;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Atilla.Domain.Entities.Tables
{
    [Table("tbl_EventDetails")]
    public class EventDetails
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

        public int UserID { get; set; }

        public int EventTeamID { get; set; }

        public int  EventPackageDetailsID { get; set; }

        public int EventPaymentStatusID { get; set; }

        public int EventClientID { get; set; }

        public int EventEquipmentsID { get; set; }

        public int PackageAdditionalDurationRequestID { get; set; }

        public int PackageAdditionalEquipmentRequestID { get; set; }

    }
}
