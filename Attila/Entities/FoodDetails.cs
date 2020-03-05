using Attila.Domain.Entities.Enums;
using Attila.Domain.Enums;

namespace Attila.Domain.Entities
{
    public class FoodDetails
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
