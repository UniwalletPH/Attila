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
    public class UpdateClientDetailsCommand : IRequest<bool>
    {
       public EventClient UpdateClient { get; set; }

        public class UpdateClientDetailsCommandHandler : IRequestHandler<UpdateClientDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdateClientDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateClientDetailsCommand request, CancellationToken cancellationToken)
            {
                var _updatedClientDetails = dbContext.EventClients.Find(request.UpdateClient.ID);

                _updatedClientDetails.Lastname = request.UpdateClient.Lastname;
                _updatedClientDetails.Firstname = request.UpdateClient.Firstname;
                _updatedClientDetails.Address = request.UpdateClient.Address;
                _updatedClientDetails.Contact = request.UpdateClient.Contact;
                _updatedClientDetails.Email = request.UpdateClient.Email;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
