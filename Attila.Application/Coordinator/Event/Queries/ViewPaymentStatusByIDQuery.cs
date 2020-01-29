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
    public class ViewPaymentStatusByIDQuery : IRequest<EventPaymentStatus>
    {
        private readonly int PaymentID;
        public ViewPaymentStatusByIDQuery(int paymentID)
        {
            this.PaymentID = paymentID;
        }

        public class ViewPaymentStatusQueryHandler : IRequestHandler<ViewPaymentStatusByIDQuery, EventPaymentStatus>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewPaymentStatusQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EventPaymentStatus> Handle(ViewPaymentStatusByIDQuery request, CancellationToken cancellationToken)
            {
                var _paymentStatus = dbContext.EventsPaymentStatus.Find(request.PaymentID);

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
