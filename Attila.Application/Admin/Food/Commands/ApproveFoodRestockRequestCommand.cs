using Attila.Application.Interfaces;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Food.Commands
{
    public class ApproveFoodRestockRequestCommand : IRequest<int>
    {
        public int RequestID { get; set; }

        public class ApproveFoodRestockRequestCommandHandler : IRequestHandler<ApproveFoodRestockRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public ApproveFoodRestockRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(ApproveFoodRestockRequestCommand request, CancellationToken cancellationToken)
            {
                var _requestToApproved = dbContext.FoodRestockRequests.Find(request.RequestID);

                // TODO: Always put checking of object is null before accessing it

                // this might throw object reference is not set to an instance of an object if object is null
                _requestToApproved.Status = Status.Approved;

                await dbContext.SaveChangesAsync();

                return _requestToApproved.ID;

            }
        }
    }
}
