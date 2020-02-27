using Attila.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class EventDetailsVM
    {
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public EventType Type { get; set; }
        [Required]
        public Status EventStatus { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }

        public string Remarks { get; set; }

        public int UserID { get; set; }

        public int EventPackageDetailsID { get; set; }

        public int EventClientID { get; set; }


        public string Selected { get; set; }

        public List<SelectListItem> PackageList { get; set; }
    }
}
