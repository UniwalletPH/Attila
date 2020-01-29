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
    public class AddEventPackageCommand : IRequest<bool>
    {
        private readonly EventPackageDetails EventPackageDetails;
        public AddEventPackageCommand(EventPackageDetails eventPackageDetails)
        {
            this.EventPackageDetails = eventPackageDetails;
        }

        public class AddEventPackageCommandHandler : IRequestHandler<AddEventPackageCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddEventPackageCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddEventPackageCommand request, CancellationToken cancellationToken)
            {
                var _newPackage = new EventPackageDetails {
                    
                    Code = request.EventPackageDetails.Code,
                    Description = request.EventPackageDetails.Description,
                    Duration = request.EventPackageDetails.Duration,
                    NumberOfGuest = request.EventPackageDetails.NumberOfGuest,
                    Rate = request.EventPackageDetails.Rate,                

                };

                dbContext.EventsPackageDetails.Add(_newPackage);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
