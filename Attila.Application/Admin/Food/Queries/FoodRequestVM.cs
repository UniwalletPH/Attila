using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Admin.Food.Queries
{
    public class FoodRequestVM
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public Domain.Entities.Food FoodDetails { get; set; }

        public Status Status { get; set; }

        public User User { get; set; }

    }
}
