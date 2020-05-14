using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Admin.Equipments.Queries
{
    public class EquipmentCollectionVM
    {
        public int ID { get; set; }
        public Equipment Equipment { get; set; }
        public int Quantity { get; set; }
        public decimal EstimatedPrice { get; set; }
        public decimal TotalEstimatedPrice { get; set; }
    }
}
