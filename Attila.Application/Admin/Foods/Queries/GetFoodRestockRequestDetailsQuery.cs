using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Foods.Queries
{
    public class GetFoodRestockRequestDetailsQuery : IRequest<List<FoodCollectionVM>>
    {
        public int RequestID { get; set; }

        public class GetFoodRequestDetailsQueryHandler : IRequestHandler<GetFoodRestockRequestDetailsQuery, List<FoodCollectionVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetFoodRequestDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<FoodCollectionVM>> Handle(GetFoodRestockRequestDetailsQuery request, CancellationToken cancellationToken)
            {
                var _request = dbContext.FoodRequestCollections
                    .Where(a => a.FoodRestockRequestID == request.RequestID)
                    .Include(a => a.Food).ToList();

                var _foodCollectionOfRequest = new List<FoodCollectionVM>();

                foreach (var item in _request)
                {
                    var foodReq = new FoodCollectionVM
                    {
                        ID = item.ID,
                        Food = item.Food,
                        Quantity = item.Quantity
                    };

                    _foodCollectionOfRequest.Add(foodReq);
                }

                return _foodCollectionOfRequest;
            }
        }
    }
}
