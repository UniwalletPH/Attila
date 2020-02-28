using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
{
    public class GetPaymentStatusQuery : IRequest<IEnumerable<PaymentStatusVM>>
    {

        public class GetPaymentStatusQueryHandler : IRequestHandler<GetPaymentStatusQuery, IEnumerable<PaymentStatusVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetPaymentStatusQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<PaymentStatusVM>> Handle(GetPaymentStatusQuery request, CancellationToken cancellationToken)
            {
                var _viewPaymentStatus = await dbContext.EventsPaymentStatus.Select(a => new PaymentStatusVM 
                {
                    ID = a.ID,
                    EventDetails = a.EventDetails,
                    EventDetailsID = a.EventDetailsID,
                    Amount = a.Amount,
                    DateOfPayment = a.DateOfPayment,
                    ReferenceNumber = a.ReferenceNumber,
                    Remarks = a.Remarks
                    
                }).ToListAsync();
                
                return _viewPaymentStatus;
            }
        }
    }
}
