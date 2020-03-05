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
    public class GetFoodDetailsQuery : IRequest<IEnumerable<FoodsDetailsVM>>
    {
        public class GetFoodDetailsQueryHandler : IRequestHandler<GetFoodDetailsQuery, IEnumerable<FoodsDetailsVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetFoodDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<FoodsDetailsVM>> Handle(GetFoodDetailsQuery request, CancellationToken cancellationToken)
            {
                var _foodDetailsList = await dbContext.FoodDetails.Select(a => new FoodsDetailsVM
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
