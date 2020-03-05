using Attila.Domain.Enums;

namespace Attila.Domain.Entities
{
    public class EventAdditionalEquipmentRequest
    {
        public int ID { get; set; }

        public int EquipmentDetailsID { get; set; }

        public EquipmentDetails EquipmentDetails { get; set; }

        public int EventDetailsID { get; set; }

        public EventDetails EventDetails { get; set; }

        public Status Status { get; set; }

        public int Quantity { get; set; }

    }
}
