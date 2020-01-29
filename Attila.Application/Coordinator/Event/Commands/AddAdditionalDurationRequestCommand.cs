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
    public class AddAdditionalDurationRequestCommand : IRequest<bool>
    {
        private readonly PackageAdditionalDurationRequest additionalPackage;
        public AddAdditionalDurationRequestCommand(PackageAdditionalDurationRequest _additionalPackage)
        {
            _additionalPackage = additionalPackage;
        }

        public class AddAdditionalDurationRequestCommandHandler : IRequestHandler<AddAdditionalDurationRequestCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddAdditionalDurationRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddAdditionalDurationRequestCommand request, CancellationToken cancellationToken)
            {
                var _additionalDuration = new PackageAdditionalDurationRequest
                {
                    EventDetailsID = request.additionalPackage.EventDetailsID,
                    Duration = request.additionalPackage.Duration,
                    Rate = request.additionalPackage.Rate
                };

                dbContext.PackageAdditionalDurationRequests.Add(_additionalDuration);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
