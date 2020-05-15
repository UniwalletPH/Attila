using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Foods.Queries
{
    public class GetFoodRequestDetailsQuery : IRequest<FoodRequestVM>
    {
        public int ID { get; set; }
        public class GetFoodRequestDetailsQueryHandler : IRequestHandler<GetFoodRequestDetailsQuery, FoodRequestVM>
        {
            private readonly IAttilaDbContext dbContext;
            public GetFoodRequestDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<FoodRequestVM> Handle(GetFoodRequestDetailsQuery request, CancellationToken cancellationToken)
            {
                var _qVal = dbContext.FoodRestockRequests
                    .Where(a => a.ID == request.ID)
                    .Include(a => a.InventoryManager)
                    .SingleOrDefault();

                var _requestDetails = new FoodRequestVM
                { 
                    ID = _qVal.ID,
                    DateTimeRequest = _qVal.DateTimeRequest,
                    InventoryManager = _qVal.InventoryManager,
                    Status = _qVal.Status,
                    Remarks = _qVal.Remarks
                };

                return _requestDetails;
            }
        }
    }
}
