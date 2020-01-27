using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities.Tables
{
    [Table("tbl_EventDetails")]
    public class EventDetails
    {

        public int ID { get; set; }
        public string EventName { get; set; }
        public string Address { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public EventClient Client { get; set; }
        public User EventCoordinator { get; set; }
        public EventPackageDetails Package { get; set; }
        public string Remarks { get; set; }




    }
}
