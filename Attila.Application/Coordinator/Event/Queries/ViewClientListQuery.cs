using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Event.Queries
{
    public class ViewClientListQuery : IRequest<List<EventClient>>
    {
        public ViewClientListQuery()
        {
        
        }

        public class ViewClientListQueryHandler : IRequestHandler<ViewClientListQuery, List<EventClient>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewClientListQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<List<EventClient>> Handle(ViewClientListQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

    }
}
