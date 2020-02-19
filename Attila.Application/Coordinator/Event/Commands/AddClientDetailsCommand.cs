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
    public class AddClientDetailsCommand : IRequest<bool>
    {
        //public EventClient EventClient { get; set; }
        public int ID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Contact { get; set; }

        public class AddClientDetailsCommandHandler : IRequestHandler<AddClientDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddClientDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddClientDetailsCommand request, CancellationToken cancellationToken)
            {
                var _newClient = new EventClient
                {
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    Address = request.Address,
                    Contact = request.Contact,
                    Email = request.Email

                };

                dbContext.EventClients.Add(_newClient);
                await dbContext.SaveChangesAsync();

                return true;

            }
        }
    }
}
