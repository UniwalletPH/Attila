using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Foods.Commands
{
    public class DeclineFoodRestockRequestCommand : IRequest<int>
    {
        public int RequestID { get; set; }

        public class DeclineFoodRestockRequestCommandHandler : IRequestHandler<DeclineFoodRestockRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;

            public DeclineFoodRestockRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            
            }

            public async Task<int> Handle(DeclineFoodRestockRequestCommand request, CancellationToken cancellationToken)
            {
                var _requestToDecline = dbContext.FoodRestockRequests.Find(request.RequestID);

                if (_requestToDecline != null)
                {
                    _requestToDecline.Status = Status.Declined;

                    await dbContext.SaveChangesAsync();

                    return _requestToDecline.ID;
                }
                else
                {
                    throw new Exception("Does not exist!");
                }
            }
        }
    }
}
