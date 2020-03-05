using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Commands
{
    public class AddEventPackageCommand : IRequest<bool>
    {
        public EventPackageVM PackageDetails;

        public class AddEventPackageCommandHandler : IRequestHandler<AddEventPackageCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddEventPackageCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddEventPackageCommand request, CancellationToken cancellationToken)
            {
                var _newPackage = new PackageMenuDetails {
                    
                    Code = request.PackageDetails.Code,
                    Description = request.PackageDetails.Description,
                    Duration = request.PackageDetails.Duration,
                    RatePerHead = request.PackageDetails.Rate,
                    Name = request.PackageDetails.Name

                };

                dbContext.PackageMenuDetails.Add(_newPackage);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
