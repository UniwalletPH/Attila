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
    public class ViewClientListQuery : IRequest<List<EventClient>>
    {

        public class ViewClientListQueryHandler : IRequestHandler<ViewClientListQuery, List<EventClient>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewClientListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventClient>> Handle(ViewClientListQuery request, CancellationToken cancellationToken)
            {
                var _viewClientList = await dbContext.EventClients.ToListAsync();

                return _viewClientList;
            }
        }

    }
}
