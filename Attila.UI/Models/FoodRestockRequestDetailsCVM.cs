using Attila.Application.Admin.Foods.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class FoodRestockRequestDetailsCVM
    {
       
        public FoodRequestVM FoodRequest { get; set; }

        public List<FoodCollectionVM> FoodCollection { get; set; }
    }
}
