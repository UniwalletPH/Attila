using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Queries
{
    public class ViewAllEventDetailsListQuery : IRequest<List<EventDetails>>
    {
        public ViewAllEventDetailsListQuery()
        {  }

        public class ViewAllEventDetailsListQueryHandler : IRequestHandler<ViewAllEventDetailsListQuery, List<EventDetails>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewAllEventDetailsListQueryHandler(IAttilaDbContext dbContext)
            {

                this.dbContext = dbContext;
            }

            public Task<List<EventDetails>> Handle(ViewAllEventDetailsListQuery request, CancellationToken cancellationToken)
            {
                var _listOfEvents = dbContext.EventsDetails.ToListAsync();

                return _listOfEvents;

            }
        }
    }
}
