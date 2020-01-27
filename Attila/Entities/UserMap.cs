using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities.Tables
{
    [Table("tbl_UserMap")]
    public class UserMap
    {

        public User User { get; set; }
        public User Parent { get; set; }


    }
}
