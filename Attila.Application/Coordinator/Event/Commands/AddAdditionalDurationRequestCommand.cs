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
        //public PackageAdditionalDurationRequest AdditionalPackage { get; set; }
        public int ID { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Rate { get; set; }

        public int EventDetailsID { get; set; }

        public class AddAdditionalDurationRequestCommandHandler : IRequestHandler<AddAdditionalDurationRequestCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddAdditionalDurationRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddAdditionalDurationRequestCommand request, CancellationToken cancellationToken)
            {
                if(request.Duration != null && request.Rate != 0 && request.EventDetailsID != 0)
                {
                    var _additionalDuration = new PackageAdditionalDurationRequest
                    {
                        EventDetailsID = request.EventDetailsID,
                        Duration = request.Duration,
                        Rate = request.Rate
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
