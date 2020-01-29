using Atilla.Domain.Entities.Enums;
using Atilla.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atilla.Domain.Entities.Tables
{
    [Table("tbl_EquipmentDetails")]
    public class EquipmentDetails
    {
        public int ID { get; set; }

        public string Code { get; set; } 

        public string Name { get; set; }

        public string Description { get; set; }

        public UnitType UnitType { get; set; }

        public EquipmentType EquipmentType { get; set; }

    }
}
