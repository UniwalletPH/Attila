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
    public class GetFoodRequestDetailsQuery : IRequest<FoodRequestVM>
    {
        public int RequestID { get; set; }

        public class GetFoodRequestDetailsQueryHandler : IRequestHandler<GetFoodRequestDetailsQuery, FoodRequestVM>
        {
            private readonly IAttilaDbContext dbContext;

            public GetFoodRequestDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<FoodRequestVM> Handle(GetFoodRequestDetailsQuery request, CancellationToken cancellationToken)
            {
                var _request = dbContext.FoodRestockRequests
                    .Where(a => a.ID == request.RequestID)
                    .Include(a => a.Food)
                    .Include(a => a.InventoryManager).SingleOrDefault();

                var _foodRequest = new FoodRequestVM
                {               
                    ID = _request.ID,
                    FoodDetails = _request.Food,
                    Quantity = _request.Quantity,
                    DateTimeRequest = _request.DateTimeRequest,
                    Status = _request.Status,
                    User = _request.InventoryManager

                };

                return _foodRequest;
            }
        }
    }
}
