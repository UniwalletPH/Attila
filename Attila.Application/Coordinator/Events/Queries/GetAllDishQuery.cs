using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class GetAllDishQuery : IRequest<List<DishVM>>
    {
        public class GetAllDishQueryHandler : IRequestHandler<GetAllDishQuery, List<DishVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetAllDishQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<List<DishVM>> Handle(GetAllDishQuery request, CancellationToken cancellationToken)
            {
                var _qVal = await dbContext.Dishes
                    .Select(a => new DishVM
                    {
                        Name = a.Name,
                        Description = a.Description,
                        ID = a.ID
                    }).ToListAsync();

                return _qVal;
            }
        }
    }
}
