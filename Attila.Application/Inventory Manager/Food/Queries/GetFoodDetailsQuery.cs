using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Food.Queries
{
    public class GetFoodDetailsQuery : IRequest<IEnumerable<FoodDetails>>
    {
        public class ViewFoodDetailsQueryHandler : IRequestHandler<GetFoodDetailsQuery, IEnumerable<FoodDetails>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewFoodDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<FoodDetails>> Handle(GetFoodDetailsQuery request, CancellationToken cancellationToken)
            {
                var _foodDetailsList = await dbContext.FoodsDetails.ToListAsync();

                return _foodDetailsList;
            }
        }
    }
}
