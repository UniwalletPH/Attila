using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Commands
{
    public class UpdateClientDetailsCommand : IRequest<bool>
    {
        //public EventClient UpdateClient { get; set; }
        public int ID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Contact { get; set; }

        public class UpdateClientDetailsCommandHandler : IRequestHandler<UpdateClientDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdateClientDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateClientDetailsCommand request, CancellationToken cancellationToken)
            {
                var _updatedClientDetails = dbContext.ClientDetails.Find(request.ID);

                _updatedClientDetails.Lastname = request.Lastname;
                _updatedClientDetails.Firstname = request.Firstname;
                _updatedClientDetails.Address = request.Address;
                _updatedClientDetails.Contact = request.Contact;
                _updatedClientDetails.Email = request.Email;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
