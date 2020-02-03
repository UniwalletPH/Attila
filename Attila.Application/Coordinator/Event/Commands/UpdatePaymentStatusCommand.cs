using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Event.Commands
{
    public class UpdatePaymentStatusCommand : IRequest<bool>
    {
        private readonly EventPaymentStatus status;
        public UpdatePaymentStatusCommand(EventPaymentStatus status)
        {
            this.status = status;
        }

        public class UpdatePaymentStatusCommandHandler : IRequestHandler<UpdatePaymentStatusCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdatePaymentStatusCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdatePaymentStatusCommand request, CancellationToken cancellationToken)
            {
                var _updatedPackageStatus = dbContext.EventsPaymentStatus.Find(request.status.ID);

                _updatedPackageStatus.Amount = request.status.Amount;
                _updatedPackageStatus.Remarks = request.status.Remarks;
                _updatedPackageStatus.DateOfPayment = request.status.DateOfPayment;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
