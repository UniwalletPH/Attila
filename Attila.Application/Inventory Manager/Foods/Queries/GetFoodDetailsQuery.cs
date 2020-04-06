using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Queries
{
    public class GetFoodDetailsQuery : IRequest<IEnumerable<FoodDetailsVM>>
    {
        public class GetFoodDetailsQueryHandler : IRequestHandler<GetFoodDetailsQuery, IEnumerable<FoodDetailsVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetFoodDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<FoodDetailsVM>> Handle(GetFoodDetailsQuery request, CancellationToken cancellationToken)
            {
                var _foodDetailsList = await dbContext.Foods.Select(a => new FoodDetailsVM
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
