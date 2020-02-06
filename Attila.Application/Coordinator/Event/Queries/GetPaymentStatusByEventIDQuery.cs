using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
{
    public class GetPaymentStatusByEventIDQuery : IRequest<EventPaymentStatus>
    {

        public int EventID { get; set; }

        public class GetPaymentStatusQueryHandler : IRequestHandler<GetPaymentStatusByEventIDQuery, EventPaymentStatus>
        {
            private readonly IAttilaDbContext dbContext;
            public GetPaymentStatusQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EventPaymentStatus> Handle(GetPaymentStatusByEventIDQuery request, CancellationToken cancellationToken)
            {
                var _paymentStatus = dbContext.EventsPaymentStatus.Where(a => a.EventDetailsID == request.EventID);

                if (_paymentStatus != null)
                {
                    return _paymentStatus.SingleOrDefault();
                }
                else
                {
                    throw new Exception("Does not exist!");
                }

            }
        }
    }
}
