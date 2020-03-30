using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Users.Queries
{
    public class SearchUserByIdQuery : IRequest<UserVM>
    {
        public Guid UID { get; set; }

        public class SearchUserByIdQueryHandler : IRequestHandler<SearchUserByIdQuery, UserVM>
        {
            private readonly IAttilaDbContext dbContext;
            public SearchUserByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<UserVM> Handle(SearchUserByIdQuery request, CancellationToken cancellationToken)
            {
                var _data = dbContext.Users
                    .Where(a => a.UID == request.UID)
                    .Include(a => a.UserLogins)
                    .SingleOrDefault();

                var _userDetails = new UserVM
                {
                    ID = _data.ID,
                    UID = _data.UID,
                    Name = _data.Name,
                    Position = _data.Position,
                    ContactNumber = _data.ContactNumber,
                    Email = _data.Email,
                    Role = _data.Role,
                    Username = _data.UserLogins.Username
                };

                return _userDetails;
            }
        }
    }
}
