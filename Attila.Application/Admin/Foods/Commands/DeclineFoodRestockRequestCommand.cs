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
    public class DeclineFoodRestockRequestCommand : IRequest<FoodRequestVM>
    {
        public int RequestID { get; set; }

        public string Remarks { get; set; }

        public class DeclineFoodRestockRequestCommandHandler : IRequestHandler<DeclineFoodRestockRequestCommand, FoodRequestVM>
        {
            private readonly IAttilaDbContext dbContext;

            public DeclineFoodRestockRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            
            }

            public async Task<FoodRequestVM> Handle(DeclineFoodRestockRequestCommand request, CancellationToken cancellationToken)
            {
                var _requestToDecline = dbContext.FoodRestockRequests
                    .Where(a => a.ID == request.RequestID)
                    .Include(a => a.InventoryManager).SingleOrDefault();

                if (_requestToDecline != null)
                {
                    _requestToDecline.Status = Status.Declined;
                    _requestToDecline.Remarks = request.Remarks;

                    await dbContext.SaveChangesAsync();

                    var _toReturn = new FoodRequestVM
                    { 
                        ID = _requestToDecline.ID,
                        Remarks = _requestToDecline.Remarks,
                        InventoryManager = _requestToDecline.InventoryManager
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
