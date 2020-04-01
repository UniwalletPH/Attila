using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Foods.Commands
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

                if (_requestToApproved != null)
                {
                    _requestToApproved.Status = Status.Approved;

                    await dbContext.SaveChangesAsync();

                    return _requestToApproved.ID;
                }
                else
                {
                    throw new Exception("Does not exist!");
                }         
            }
        }
    }
}
