using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Commands
{
    public class AddClientDetailsCommand : IRequest<bool>
    {
        public EventClientVM EventClient { get; set; }
      
        public class AddClientDetailsCommandHandler : IRequestHandler<AddClientDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddClientDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddClientDetailsCommand request, CancellationToken cancellationToken)
            {
                var _newClient = new Client
                {
                    Firstname = request.EventClient.Firstname,
                    Lastname = request.EventClient.Lastname,
                    Address = request.EventClient.Address,
                    Contact = request.EventClient.Contact,
                    Email = request.EventClient.Email

                };

                dbContext.Clients.Add(_newClient);
                await dbContext.SaveChangesAsync();

                return true;

            }
        }
    }
}
