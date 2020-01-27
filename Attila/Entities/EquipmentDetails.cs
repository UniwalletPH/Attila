using Attila.Domain.Entities.Enums;
using Attila.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities.Tables
{
    [Table("tbl_EquipmentDetails")]
    public class EquipmentDetails
    {
        public int ID { get; set; }
        public int Code { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public UnitType Unit { get; set; }
        public EquipmentType EquipmentType { get; set; }



    }
}
