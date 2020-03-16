using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Login.Queries
{
    public class GetIDQuery : IRequest<int>
    {
        public User User { get; set; }
        public class GetIDQueryHandler : IRequestHandler<GetIDQuery, int>
        {
            private readonly IAttilaDbContext dbContext;
            public GetIDQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(GetIDQuery request, CancellationToken cancellationToken)
            {
                var _employee = dbContext.Users
                    .Where(a => a.Name == request.User.Name
                    && a.Email == request.User.Email
                    && a.ContactNumber == request.User.ContactNumber)
                    .SingleOrDefault();

                return _employee.ID;
            }
        }
    }
}
