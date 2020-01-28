using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
{
    public class ViewEventListQuery : IRequest<List<EventDetails>>
    {
        public ViewEventListQuery()
        {

        }

        public class ViewEventListQueryHandler : IRequestHandler<ViewEventListQuery, List<EventDetails>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewEventListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<List<EventDetails>> Handle(ViewEventListQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

    }
}
