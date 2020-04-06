using Attila.Application.Admin.Equipments.Queries;
using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Equipments.Commands
{
    public class ApproveEquipmentRestockRequestCommand : IRequest<EquipmentRequestVM>
    {
        public int RequestID { get; set; }

        public class ApproveAdditionalEquipmentRequestCommandHandler : IRequestHandler<ApproveEquipmentRestockRequestCommand, EquipmentRequestVM>
        {
            private readonly IAttilaDbContext dbContext;

            public ApproveAdditionalEquipmentRequestCommandHandler(IAttilaDbContext dbContext)
            {

                this.dbContext = dbContext;
            
            }

            public async  Task<EquipmentRequestVM> Handle(ApproveEquipmentRestockRequestCommand request, CancellationToken cancellationToken)
            {
                var _requestToApprove = dbContext.EquipmentRestockRequests
                    .Where(a => a.ID == request.RequestID)
                    .Include(a => a.InventoryManager).SingleOrDefault();

                if (_requestToApprove != null)
                {
                    _requestToApprove.Status = Status.Approved;
                    await dbContext.SaveChangesAsync();

                    var _toReturn = new EquipmentRequestVM
                    { 
                        ID = _requestToApprove.ID,
                        InventoryManager = _requestToApprove.InventoryManager 
                    
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
