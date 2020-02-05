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
    public class GetPaymentStatusQuery : IRequest<List<EventPaymentStatus>>
    {

        public class GetPaymentStatusQueryHandler : IRequestHandler<GetPaymentStatusQuery, List<EventPaymentStatus>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetPaymentStatusQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EventPaymentStatus>> Handle(GetPaymentStatusQuery request, CancellationToken cancellationToken)
            {
                var _viewPaymentStatus = await dbContext.EventsPaymentStatus.ToListAsync();
                
                return _viewPaymentStatus;
            }
        }
    }
}
