﻿using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    public class FoodRestockRequest
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public int FoodDetailsID { get; set; }

        public FoodDetails FoodDetails { get; set; }

        public Status Status { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }
    }
}
