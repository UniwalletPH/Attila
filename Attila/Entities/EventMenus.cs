namespace Attila.Domain.Entities
{
    public class EventMenus
    {
        public int ID { get; set; }

        public int  MenuID {get; set;}

        public int EventDetailsID { get; set; }

        public EventDetails EventDetails { get; set; }
        
        public Menu Menu { get; set; }

    }
}
