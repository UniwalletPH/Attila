using Attila.Application.Admin.Equipments.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class EquipmentRestockRequestDetailsCVM
    {
        public EquipmentRequestVM EquipmentRequest { get; set; }
        public List<EquipmentCollectionVM> EquipmentCollection { get; set; }
    }
}
