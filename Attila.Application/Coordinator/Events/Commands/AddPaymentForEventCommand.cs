using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Events.Commands
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
                var _addPaymentForEventCommand = new PaymentStatus
                {
                    ID =request.MyEventPaymentStatus.ID,
                    EventID = request.MyEventPaymentStatus.EventDetailsID,
                    Amount = request.MyEventPaymentStatus.Amount,
                    DateOfPayment = DateTime.Now,
                    ReferenceNumber = request.MyEventPaymentStatus.ReferenceNumber,
                    Remarks = request.MyEventPaymentStatus.Remarks
                };

                dbContext.PaymentStatus.Add(_addPaymentForEventCommand);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
