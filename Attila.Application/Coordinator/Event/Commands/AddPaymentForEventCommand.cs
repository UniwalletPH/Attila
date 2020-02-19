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
        //public EventPaymentStatus MyEventPaymentStatus { get; set; }
        public int ID { get; set; }

        public int EventDetailsID { get; set; }

        public EventDetails EventDetails { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateOfPayment { get; set; }

        public string ReferenceNumber { get; set; }

        public string Remarks { get; set; }

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
                    EventDetailsID = request.EventDetailsID,
                    Amount = request.Amount,
                    DateOfPayment = DateTime.Now,
                    ReferenceNumber = request.ReferenceNumber,
                    Remarks = request.Remarks
                };

                dbContext.EventsPaymentStatus.Add(_addPaymentForEventCommand);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
