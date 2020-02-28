using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
{
    public class GetClientListQuery : IRequest<IEnumerable<SearchClientVM>>
    {

        public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, IEnumerable<SearchClientVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetClientListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<SearchClientVM>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
            {
                var _viewClientList = await dbContext.EventClients.Select(a => new SearchClientVM 
                {
                    ID = a.ID,
                    Lastname = a.Lastname, 
                    Firstname = a.Firstname,
                    Address = a.Address,
                    Email = a.Email,
                    Contact = a.Contact

                }).ToListAsync();


                return _viewClientList;
            }
        }

    }
}
