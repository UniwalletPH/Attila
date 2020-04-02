using Attila.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Attila.Application.Coordinator.Events.Queries
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
