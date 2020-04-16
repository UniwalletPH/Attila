using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
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
                if(request.AdditionalPackage.Duration != null && request.AdditionalPackage.Rate != 0 && request.AdditionalPackage.EventDetailsID != 0)
                {
                    var _additionalDuration = new EventAdditionalDurationRequest
                    {
                        EventID = request.AdditionalPackage.EventDetailsID,
                        Duration = request.AdditionalPackage.Duration
                    };

                    dbContext.EventAdditionalDurationRequests.Add(_additionalDuration);
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
