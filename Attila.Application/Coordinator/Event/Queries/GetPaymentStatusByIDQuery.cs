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
    public class GetPaymentStatusByIDQuery : IRequest<EventPaymentStatus>
    {

        public int PaymentId { get; set; }

        public class GetPaymentStatusQueryHandler : IRequestHandler<GetPaymentStatusByIDQuery, EventPaymentStatus>
        {
            private readonly IAttilaDbContext dbContext;
            public GetPaymentStatusQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EventPaymentStatus> Handle(GetPaymentStatusByIDQuery request, CancellationToken cancellationToken)
            {
                var _paymentStatus = dbContext.EventsPaymentStatus.Find(request.PaymentId);

                if (_paymentStatus != null)
                {
                    return _paymentStatus;
                }
                else
                {
                    throw new Exception("Does not exist!");
                }

            }
        }
    }
}
