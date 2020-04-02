using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Queries
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
                var _viewPaymentStatus = await dbContext.PaymentStatus.Select(a => new PaymentStatusVM 
                {
                    ID = a.ID,
                    EventDetailsID = a.EventID,
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
