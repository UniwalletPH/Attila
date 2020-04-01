namespace Attila.Domain.Entities.Tables
{
    public class EventEquipments
    {
        public int ID { get; set; }

        public int EquipmentDetailsID { get; set; }
        
        public Equipment EquipmentDetails { get; set; }

        public int EventDetailsID { get; set; }

        public Event EventDetails { get; set; }
    }
}
