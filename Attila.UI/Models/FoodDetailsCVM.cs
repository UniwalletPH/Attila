using Attila.Application.Inventory_Manager.Foods.Queries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Attila.UI.Models
{
    public class FoodDetailsCVM
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

        public IEnumerable<FoodDetailsVM> FoodDetailsVMs { get; set; }
    }
}
