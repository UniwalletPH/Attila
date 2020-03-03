using Attila.Application.Coordinator.Event.Queries;
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
        public PaymentStatusVM UpdatePaymentStatus { get; set; }
        public class UpdatePaymentStatusCommandHandler : IRequestHandler<UpdatePaymentStatusCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdatePaymentStatusCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdatePaymentStatusCommand request, CancellationToken cancellationToken)
            {
                var _updatedPackageStatus = dbContext.EventsPaymentStatus.Find(request.UpdatePaymentStatus.ID);
                _updatedPackageStatus.Amount = request.UpdatePaymentStatus.Amount;
                _updatedPackageStatus.Remarks = request.UpdatePaymentStatus.Remarks;
                _updatedPackageStatus.DateOfPayment = request.UpdatePaymentStatus.DateOfPayment;
                _updatedPackageStatus.ReferenceNumber = request.UpdatePaymentStatus.ReferenceNumber;
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
