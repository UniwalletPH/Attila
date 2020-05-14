using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    public class FoodRequestCollection : BaseAuditedEntity
    {
        [ForeignKey("Food")]
        public int FoodID { get; set; }

        [ForeignKey("FoodRestockRequest")]
        public int FoodRestockRequestID { get; set; }

        public int Quantity { get; set; }
        public decimal EstimatedPrice { get; set; }

        public Food Food { get; set; }
        public FoodRestockRequest FoodRestockRequest { get; set; }
    }
}
