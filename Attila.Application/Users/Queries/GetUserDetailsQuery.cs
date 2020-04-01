using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Users.Queries
{
    public class GetUserDetailsQuery : IRequest<UserVM>
    {
        public string Username { get; set; }

        public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserVM>
        {
            private readonly IAttilaDbContext dbContext;
            public GetUserDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<UserVM> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
            {
                var _user = dbContext.UserLogins
                    .Where(a => a.Username == request.Username)
                    .Include(a => a.User).SingleOrDefault();

                var _userDetails = new UserVM
                {
                   ID = _user.ID,
                   Name = _user.User.Name,
                   Email = _user.User.Email,
                   ContactNumber = _user.User.ContactNumber,
                   Position = _user.User.Position,
                   Role = _user.User.Role
                };

                return _userDetails;

            }
        }
    }
}
