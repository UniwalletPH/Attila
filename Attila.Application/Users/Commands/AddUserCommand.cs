using Attila.Application.Interfaces;
using Attila.Application.Login.Queries;
using Attila.Application.Users.Queries;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Users.Commands
{
    public class AddUserCommand : IRequest<bool>
    {
        public UserVM User { get; set; }

        public class AddUserCommandHandler : IRequestHandler<AddUserCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            private readonly IPasswordHasher passwordHasher;
            private readonly IMediator mediator;
            public AddUserCommandHandler(IAttilaDbContext dbContext, IPasswordHasher passwordHasher, IMediator mediator)
            {
                this.dbContext = dbContext;
                this.passwordHasher = passwordHasher;
                this.mediator = mediator;
            }

            public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                var salt = passwordHasher.GenerateSalt();

                var _user = new User
                {
                    UID = Guid.NewGuid(),
                    Name = request.User.Name,
                    ContactNumber = request.User.ContactNumber,
                    Email = request.User.Email,
                    Position = request.User.Position,
                    Role = request.User.Role,
                    UserLogins = new UserLogin
                    {
                        Username = request.User.Username,
                        Salt = salt,
                        Password = passwordHasher.HashPassword(salt, request.User.Password)
                    }
                };

                dbContext.Users.Add(_user);

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}