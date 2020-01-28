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
    public class ViewPaymentStatusQuery : IRequest<EventPaymentStatus>
    {
        public ViewPaymentStatusQuery()
        { 
        
        }

        public class ViewPaymentStatusQueryHandler : IRequestHandler<ViewPaymentStatusQuery, EventPaymentStatus>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewPaymentStatusQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<EventPaymentStatus> Handle(ViewPaymentStatusQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
