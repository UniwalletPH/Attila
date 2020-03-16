using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Login.Queries
{
    public class VerifyUserLoginQuery : IRequest<UserLoginVM>
    {
        public string Username { get; set; }

        public class VerifyUserLoginQueryHandler : IRequestHandler<VerifyUserLoginQuery, UserLoginVM>
        {
            private readonly IAttilaDbContext dbContext;
            public VerifyUserLoginQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<UserLoginVM> Handle(VerifyUserLoginQuery request, CancellationToken cancellationToken)
            {
                var _employee = dbContext.UserLogins
                    .Where(a => a.Username == request.Username)
                    .SingleOrDefault();

                if (_employee != null)
                {
                    var _employeeDetails = new UserLoginVM
                    {
                        Username = _employee.Username,
                        Password = _employee.Password,
                        Salt = _employee.Salt

                    };

                    return _employeeDetails;
                }

                return null;
            }
        }
    }
}
