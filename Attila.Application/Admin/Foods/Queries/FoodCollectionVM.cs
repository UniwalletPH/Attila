using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Admin.Foods.Queries
{
    public class FoodCollectionVM
    {
        public int ID { get; set; }

        public Food Food { get; set; }

        public int Quantity { get; set; }

    }
}
