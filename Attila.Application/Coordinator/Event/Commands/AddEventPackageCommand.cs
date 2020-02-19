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
    public class AddEventPackageCommand : IRequest<bool>
    {
        //public EventPackageDetails PackageDetails;
        public int ID { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int NumberOfGuest { get; set; }

        public decimal Rate { get; set; }

        public TimeSpan Duration { get; set; }

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
                    
                    Code = request.Code,
                    Description = request.Description,
                    Duration = request.Duration,
                    NumberOfGuest = request.NumberOfGuest,
                    Rate = request.Rate,                

                };

                dbContext.EventsPackageDetails.Add(_newPackage);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
