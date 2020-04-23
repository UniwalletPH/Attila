using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Shared.Queries
{
    public class GetInventoryManagerListQuery : IRequest<IEnumerable<UserVM>>
    {
        public class GetInventoryManagerListQueryHandler : IRequestHandler<GetInventoryManagerListQuery, IEnumerable<UserVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetInventoryManagerListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<UserVM>> Handle(GetInventoryManagerListQuery request, CancellationToken cancellationToken)
            {
                var _inventoryManagerList = await dbContext.Users.Select(a => new UserVM
                {
                    UID = a.UID,
                    Name = a.Name,
                    Position = a.Position,
                    ContactNumber = a.ContactNumber,
                    Role = a.Role

                }).ToListAsync();


                return _inventoryManagerList;

            }
        }
    }
}
