using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Commands
{
    public class AddAdditionalDurationRequestCommand : IRequest<bool>
    {
        public AdditionalDurationRequestVM AdditionalPackage { get; set; }

       
        public class AddAdditionalDurationRequestCommandHandler : IRequestHandler<AddAdditionalDurationRequestCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddAdditionalDurationRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddAdditionalDurationRequestCommand request, CancellationToken cancellationToken)
            {
                
                    var _additionalDuration = new EventAdditionalDurationRequest
                    {
                        EventID = request.AdditionalPackage.EventDetailsID,
                        Duration = request.AdditionalPackage.Duration,
                        CreatedOn = DateTime.Now,
                        Status = Status.Processing
                    };

                    dbContext.EventAdditionalDurationRequests.Add(_additionalDuration);
                    await dbContext.SaveChangesAsync();
                    return true;
               
                
            }
        }
    }
}
