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
    public class GetEventListQuery : IRequest<List<EventDetails>>
    {

        public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, List<EventDetails>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetEventListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventDetails>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
            {
                var _viewEventList = await dbContext.EventsDetails.ToListAsync();

                return _viewEventList;
            }
        }

    }
}
