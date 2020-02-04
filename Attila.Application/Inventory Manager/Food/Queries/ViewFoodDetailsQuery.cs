using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Food.Queries
{
    public class ViewFoodDetailsQuery : IRequest<IEnumerable<FoodDetails>>
    {

        public ViewFoodDetailsQuery()
        {
        }

        public class ViewFoodDetailsQueryHandler : IRequestHandler<ViewFoodDetailsQuery, IEnumerable<FoodDetails>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewFoodDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<FoodDetails>> Handle(ViewFoodDetailsQuery request, CancellationToken cancellationToken)
            {
                var _foodDetailsList = await dbContext.FoodsDetails.ToListAsync();

                return _foodDetailsList;
            }
        }
    }
}
