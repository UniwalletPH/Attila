using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Commands
{
    public class RequestEquipmentRestockCommand : IRequest<bool>
    {
        public EquipmentsRestockRequestVM MyEquipmentRestockRequestVM { get; set; }

        public class RequestEquipmentRestockCommandHandler : IRequestHandler<RequestEquipmentRestockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public RequestEquipmentRestockCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(RequestEquipmentRestockCommand request, CancellationToken cancellationToken)
            {
                EquipmentRestockRequest _equipmentRestockRequest = new EquipmentRestockRequest
                {
                    Quantity = request.MyEquipmentRestockRequestVM.Quantity,
                    DateTimeRequest = DateTime.Now,
                    EquipmentID = request.MyEquipmentRestockRequestVM.EquipmentDetailsID,
                    Status = request.MyEquipmentRestockRequestVM.Status,
                    InventoryManagerID = request.MyEquipmentRestockRequestVM.UserID
                };

                dbContext.EquipmentRestockRequests.Add(_equipmentRestockRequest);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}

