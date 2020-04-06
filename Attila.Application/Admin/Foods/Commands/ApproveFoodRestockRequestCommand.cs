using Attila.Application.Admin.Foods.Queries;
using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Foods.Commands
{
    public class ApproveFoodRestockRequestCommand : IRequest<FoodRequestVM>
    {
        public int RequestID { get; set; }

        public class ApproveFoodRestockRequestCommandHandler : IRequestHandler<ApproveFoodRestockRequestCommand, FoodRequestVM>
        {
            private readonly IAttilaDbContext dbContext;
            public ApproveFoodRestockRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<FoodRequestVM> Handle(ApproveFoodRestockRequestCommand request, CancellationToken cancellationToken)
            {
                var _requestToApproved = dbContext.FoodRestockRequests
                    .Where(a => a.ID == request.RequestID)
                    .Include(a => a.InventoryManager).SingleOrDefault();

                  

                if (_requestToApproved != null)
                {
                    _requestToApproved.Status = Status.Approved;
                    await dbContext.SaveChangesAsync();

                    var _toReturn = new FoodRequestVM
                    { 
                        ID = _requestToApproved.ID,
                        InventoryManager = _requestToApproved.InventoryManager
                    };

                    return _toReturn;
                }
                else
                {
                    throw new Exception("Does not exist!");
                }         
            }
        }
    }
}
