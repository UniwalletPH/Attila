using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Event.Commands
{
    public class AddPaymentForEventCommand : IRequest<bool>
    {
        public PaymentStatusVM MyEventPaymentStatus { get; set; }

        public class AddPaymentForEventHandler : IRequestHandler<AddPaymentForEventCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public AddPaymentForEventHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddPaymentForEventCommand request, CancellationToken cancellationToken)
            {
                var _addPaymentForEventCommand = new EventPaymentStatus
                {
                    EventDetailsID = request.MyEventPaymentStatus.EventDetailsID,
                    Amount = request.MyEventPaymentStatus.Amount,
                    DateOfPayment = DateTime.Now,
                    ReferenceNumber = request.MyEventPaymentStatus.ReferenceNumber,
                    Remarks = request.MyEventPaymentStatus.Remarks
                };

                dbContext.EventsPaymentStatus.Add(_addPaymentForEventCommand);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
