using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Commands
{
    public class UpdateClientDetailsCommand : IRequest<bool>
    {
        public EventClientVM UpdateClient { get; set; }

        public class UpdateClientDetailsCommandHandler : IRequestHandler<UpdateClientDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdateClientDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateClientDetailsCommand request, CancellationToken cancellationToken)
            {
                var _updatedClientDetails = dbContext.Clients.Find(request.UpdateClient.ID);

                _updatedClientDetails.Name = request.UpdateClient.Name;
                _updatedClientDetails.Address = request.UpdateClient.Address;
                _updatedClientDetails.Contact = request.UpdateClient.Contact;
                _updatedClientDetails.Email = request.UpdateClient.Email;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
