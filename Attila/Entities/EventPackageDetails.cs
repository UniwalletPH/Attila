using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities.Tables
{
    [Table("tbl_EventPackageDetails")]
    public class EventPackageDetails
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int NumberOfGuest { get; set; }
        public decimal Rate { get; set; }
        public TimeSpan Duration{ get; set; }



    }
}
