using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Queries
{
    public class GetPaymentStatusByEventIDQuery : IRequest<IEnumerable<PaymentStatusVM>>
    {
        public int EventID { get; set; }

        public class GetPaymentStatusQueryHandler : IRequestHandler<GetPaymentStatusByEventIDQuery, IEnumerable<PaymentStatusVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetPaymentStatusQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<PaymentStatusVM>> Handle(GetPaymentStatusByEventIDQuery request, CancellationToken cancellationToken)
            {
                var _paymentStatus = dbContext.PaymentStatuses.Where(a => a.EventID == request.EventID);



                var _listEvents = new List<PaymentStatusVM>();

                if (_paymentStatus != null)
                {

                    foreach(var item in _paymentStatus){


                        var payment = new PaymentStatusVM { 
                        Amount = item.Amount,
                        DateOfPayment = item.DateOfPayment,
                        EventDetailsID = item.EventID,
                        ReferenceNumber = item.ReferenceNumber,
                        Remarks = item.Remarks,
                        ID = item.ID
                        
                        };


                        _listEvents.Add(payment);
                        
                        }



                    return _listEvents;

                }
                else
                {
                    throw new Exception("Does not exist!");
                }

            }
        }
    }
}
