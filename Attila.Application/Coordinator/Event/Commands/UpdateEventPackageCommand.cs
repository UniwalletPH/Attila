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
    public class UpdateEventPackageCommand : IRequest<bool>
    {
        //public EventPackageDetails UpdatePackage { get; set; }
        public int ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfGuest { get; set; }

        public decimal Rate { get; set; }

        public TimeSpan Duration { get; set; }

        public class UpdateEventPackageCommandHandler : IRequestHandler<UpdateEventPackageCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdateEventPackageCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateEventPackageCommand request, CancellationToken cancellationToken)
            {
                var _updatedEventPackage = dbContext.EventsPackageDetails.Find(request.ID);

                _updatedEventPackage.Description = request.Description;
                _updatedEventPackage.Duration = request.Duration;
                _updatedEventPackage.NumberOfGuest = request.NumberOfGuest;
                _updatedEventPackage.Rate = request.Rate;
                _updatedEventPackage.Name = request.Name;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
