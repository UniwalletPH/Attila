using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Event.Commands
{
    public class UpdateClientDetailsCommand : IRequest<bool>
    {
        private readonly EventClient client;
        public UpdateClientDetailsCommand(EventClient client)
        {
            this.client = client;
        }

        public class UpdateClientDetailsCommandHandler : IRequestHandler<UpdateClientDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdateClientDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateClientDetailsCommand request, CancellationToken cancellationToken)
            {
                var _updatedClientDetails = dbContext.EventClients.Find(request.client.ID);

                _updatedClientDetails.Lastname = request.client.Lastname;
                _updatedClientDetails.Firstname = request.client.Firstname;
                _updatedClientDetails.Address = request.client.Address;
                _updatedClientDetails.Contact = request.client.Contact;
                _updatedClientDetails.Email = request.client.Email;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
