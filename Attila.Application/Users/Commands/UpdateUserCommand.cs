using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Attila.Application.Users.Queries;

namespace Attila.Application.Users.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public UserVM user { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateUserCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var _data = dbContext.Users
                    .Find(request.user.ID);

                _data.UserLogins.Username = request.user.Username; 
                _data.Name = request.user.Name;
                await dbContext.SaveChangesAsync();





                return true;
            }
        }
    }
}
