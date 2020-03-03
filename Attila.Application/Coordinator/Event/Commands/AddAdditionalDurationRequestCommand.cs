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
    public class AddAdditionalDurationRequestCommand : IRequest<bool>
    {
        public AdditionalDurationRequestListVM AdditionalPackage { get; set; }
        public class AddAdditionalDurationRequestCommandHandler : IRequestHandler<AddAdditionalDurationRequestCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddAdditionalDurationRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddAdditionalDurationRequestCommand request, CancellationToken cancellationToken)
            {
                if(request.AdditionalPackage.Duration != null && request.AdditionalPackage.Rate != 0 && request.AdditionalPackage.EventDetailsID != 0)
                {
                    var _additionalDuration = new PackageAdditionalDurationRequest
                    {
                        EventDetailsID = request.AdditionalPackage.EventDetailsID,
                        Duration = request.AdditionalPackage.Duration,
                        Rate = request.AdditionalPackage.Rate
                    };

                    dbContext.PackageAdditionalDurationRequests.Add(_additionalDuration);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }
    }
}
