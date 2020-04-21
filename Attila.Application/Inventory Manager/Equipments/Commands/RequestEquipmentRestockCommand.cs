using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Commands
{
    public class RequestEquipmentRestockCommand : IRequest<int>
    {
        public EquipmentsRestockRequestVM MyEquipmentRestockRequestVM { get; set; }

        public class RequestEquipmentRestockCommandHandler : IRequestHandler<RequestEquipmentRestockCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public RequestEquipmentRestockCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(RequestEquipmentRestockCommand request, CancellationToken cancellationToken)
            {
                EquipmentRestockRequest _equipmentRestockRequest = new EquipmentRestockRequest
                {
                    DateTimeRequest = DateTime.Now,
                    Status = Status.Processing,
                    InventoryManagerID = request.MyEquipmentRestockRequestVM.UserID
                };

                dbContext.EquipmentRestockRequests.Add(_equipmentRestockRequest);
                await dbContext.SaveChangesAsync();


                foreach (var item in request.MyEquipmentRestockRequestVM.EquipmentRequestCollection)
                {
                    EquipmentRequestCollection _equipmentRequestCollection = new EquipmentRequestCollection 
                    {
                        EquipmentID = item.EquipmentID,
                        EquipmentRestockRequestID = _equipmentRestockRequest.ID,
                        Quantity = item.Quantity
                    };

                    dbContext.EquipmentRequestCollections.Add(_equipmentRequestCollection);
                }


                await dbContext.SaveChangesAsync();
                return _equipmentRestockRequest.ID;
            }
        }
    }
}

