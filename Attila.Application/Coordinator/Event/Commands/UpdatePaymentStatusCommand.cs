using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Commands
{
    public class UpdatePaymentStatusCommand : IRequest<bool>
    {
        //public EventPaymentStatus UpdatePaymentStatus { get; set; }
        public int ID { get; set; }

        public int EventDetailsID { get; set; }

        public EventDetails EventDetails { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateOfPayment { get; set; }

        public string ReferenceNumber { get; set; }

        public string Remarks { get; set; }

        public class UpdatePaymentStatusCommandHandler : IRequestHandler<UpdatePaymentStatusCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdatePaymentStatusCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdatePaymentStatusCommand request, CancellationToken cancellationToken)
            {
                var _updatedPackageStatus = dbContext.EventsPaymentStatus.Find(request.ID);
                _updatedPackageStatus.Amount = request.Amount;
                _updatedPackageStatus.Remarks = request.Remarks;
                _updatedPackageStatus.DateOfPayment = request.DateOfPayment;
                _updatedPackageStatus.ReferenceNumber = request.ReferenceNumber;
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
