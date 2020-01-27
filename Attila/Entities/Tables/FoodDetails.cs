using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities.Tables
{
    [Table("tbl_FoodDetails")]
    public class FoodDetails
    {

        public int ID { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string FoodType { get; set; }



    }
}
