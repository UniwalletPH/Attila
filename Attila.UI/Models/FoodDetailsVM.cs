using Attila.Domain.Entities.Enums;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class FoodDetailsVM
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Specification { get; set; }

        public string Description { get; set; }

        public UnitType Unit { get; set; }

        public FoodType FoodType { get; set; }
    }
}
