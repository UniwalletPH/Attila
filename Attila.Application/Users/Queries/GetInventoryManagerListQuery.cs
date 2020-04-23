using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Users.Queries
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
                List<UserVM> _inventoryManagerList = new List<UserVM>();

                var _getInventoryManagerList = dbContext.Users.Where(a => a.Role == AccessRole.InventoryManager);


                foreach (var item in _getInventoryManagerList)
                {
                    UserVM _inventoryManagerData = new UserVM
                    {
                        ID = item.ID,
                        UID = item.UID,
                        Name = item.Name,
                        Position = item.Position,
                        ContactNumber = item.ContactNumber,
                        Email = item.Email,
                        Role = item.Role

                    };
                    _inventoryManagerList.Add(_inventoryManagerData);
                }

                return _inventoryManagerList;

            }
        }
    }
}
