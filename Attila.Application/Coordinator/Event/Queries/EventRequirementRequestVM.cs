using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Attila.Application.Coordinator.Event.Queries
{
    public class EventRequirementRequestVM
    {
        public int ID { get; set; }
        [Required]
        public int EventDetailsID { get; set; }
        [Required]
        public int EquipmentDetailsID { get; set; }

        public Equipment EquipmentDetails { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
