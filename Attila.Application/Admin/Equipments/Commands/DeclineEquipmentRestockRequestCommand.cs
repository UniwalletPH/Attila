using Attila;
using Attila.Application.Admin.Equipments.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Admin.Equipments.Commands
{
    public class DeclineEquipmentRestockRequestCommand : IRequest<EquipmentRequestVM>
    {
        public int RequestID { get; set; }

        public class DeclineAdditionalEquipmentRequestCommandHandler : IRequestHandler<DeclineEquipmentRestockRequestCommand, EquipmentRequestVM>
        {
            private readonly IAttilaDbContext dbContext;
            public DeclineAdditionalEquipmentRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EquipmentRequestVM> Handle(DeclineEquipmentRestockRequestCommand request, CancellationToken cancellationToken)
            {
                var _requestToDecline = dbContext.EquipmentRestockRequests
                     .Where(a => a.ID == request.RequestID)
                    .Include(a => a.InventoryManager).SingleOrDefault();

                if (_requestToDecline != null)
                {
                    _requestToDecline.Status = Status.Declined;
                    await dbContext.SaveChangesAsync();

                    var _toReturn = new EquipmentRequestVM
                    { 
                        ID = _requestToDecline.ID,
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
