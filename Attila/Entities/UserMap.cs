using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Atilla.Domain.Entities.Tables
{
    [Table("tbl_UserMap")]
    public class UserMap
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int EventDetailsID { get; set; }

    }
}
