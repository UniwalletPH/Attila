using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
{
    public class GetClientListQuery : IRequest<List<SearchClientVM>>
    {

        public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, List<SearchClientVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetClientListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<SearchClientVM>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
            {
                var _viewClientList = await dbContext.EventClients.ToListAsync();

                var _search = new List<SearchClientVM>();

                return _search;
            }
        }

    }
}
