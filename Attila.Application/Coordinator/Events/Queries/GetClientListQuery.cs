﻿using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Queries
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
                var _viewClientList = await dbContext.Clients.Select(a => new SearchClientVM 
                {
                    ID = a.ID,
                    Name = a.Name,
                    Address = a.Address,
                    Email = a.Email,
                    Contact = a.Contact

                }).ToListAsync();


                return _viewClientList;
            }
        }

    }
}
