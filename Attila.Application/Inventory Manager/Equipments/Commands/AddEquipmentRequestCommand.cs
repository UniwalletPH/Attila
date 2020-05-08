using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Commands
{
    public class AddEquipmentRequestCommand : IRequest<int>
    {
        public int ID { get; set; }

        public class AddEquipmentRequestCommandHandler : IRequestHandler<AddEquipmentRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public AddEquipmentRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(AddEquipmentRequestCommand request, CancellationToken cancellationToken)
            {
                EquipmentRestockRequest _equipmentRestockRequest = new EquipmentRestockRequest
                {
                    DateTimeRequest = DateTime.Now,
                    Status = Status.Processing,
                    InventoryManagerID = request.ID,
                    CreatedOn = DateTime.Now
                };

                dbContext.EquipmentRestockRequests.Add(_equipmentRestockRequest);
                await dbContext.SaveChangesAsync();

                return _equipmentRestockRequest.ID;
            }
        }
    }
}
