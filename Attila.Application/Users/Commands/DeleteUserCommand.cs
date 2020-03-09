using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Users.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int UserID { get; set; }
        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public DeleteUserCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var _user = dbContext.Users.Find(request.UserID);
                dbContext.Users.Remove(_user);
                await dbContext.SaveChangesAsync();
                var _userLogin = dbContext.UserLogins.Find(request.UserID);
                dbContext.UserLogins.Remove(_userLogin);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
