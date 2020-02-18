using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Food.Queries;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Food.Queries
{
    public class GetFoodDetailsQuery : IRequest<IEnumerable<FoodDetailsVM>>
    {
        public class ViewFoodDetailsQueryHandler : IRequestHandler<GetFoodDetailsQuery, IEnumerable<FoodDetailsVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewFoodDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<FoodDetailsVM>> Handle(GetFoodDetailsQuery request, CancellationToken cancellationToken)
            {
                var _foodDetailsList = await dbContext.FoodsDetails.Select(a => new FoodDetailsVM 
                { 
                    ID = a.ID,
                    Code = a.Code,
                    Name = a.Name,
                    Specification = a.Specification,
                    Description = a.Description,
                    Unit = a.Unit,
                    FoodType = a.FoodType

                }).ToListAsync();

                return _foodDetailsList;
            }
        }
    }
}
