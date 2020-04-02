using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Commands
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
                var _updatedPackageStatus = dbContext.PaymentStatuses.Find(request.UpdatePaymentStatus.ID);
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
