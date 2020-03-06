using Attila.Application.Inventory_Manager.Food.Queries;
using Attila.Domain.Entities.Enums;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class FoodDetailsVM
    {
        public int ID { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Specification { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public UnitType Unit { get; set; }

        [Required]
        public FoodType FoodType { get; set; }

        [Required]
        public string SearchedKeyword { get; set; }

        public IEnumerable<FoodsDetailsVM> FoodDetailsVMs { get; set; }
    }
}
