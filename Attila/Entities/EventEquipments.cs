namespace Attila.Domain.Entities.Tables
{
    public class EventEquipments
    {
        public int ID { get; set; }

        public int EquipmentDetailsID { get; set; }
        
        public EquipmentDetails EquipmentDetails { get; set; }

        public int EventDetailsID { get; set; }

        public EventDetails EventDetails { get; set; }
    }
}
