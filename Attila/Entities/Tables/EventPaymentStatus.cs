using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities.Tables
{
    [Table("tbl_EventPaymentStatus")]
    public class EventPaymentStatus
    {
        public int ID { get; set; }
        public EventDetails Event { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfPayment { get; set; }
        public string ReferenceNumber { get; set; }
        public string Remarks { get; set; }



    }
}
