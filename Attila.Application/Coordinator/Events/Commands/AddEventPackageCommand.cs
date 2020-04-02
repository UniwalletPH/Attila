using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Commands
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
                var _newPackage = new EventPackage {
                    
                    Code = request.PackageDetails.Code,
                    Description = request.PackageDetails.Description,
                    RatePerHead = request.PackageDetails.RatePerHead,
                    Name = request.PackageDetails.Name

                };

                dbContext.EventPackages.Add(_newPackage);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
