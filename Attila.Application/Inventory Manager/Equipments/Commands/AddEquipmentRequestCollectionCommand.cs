using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Commands
{
    public class AddEquipmentRequestCollectionCommand : IRequest<bool>
    {
        public int EquipmentRestockID { get; set; }

        public EquipmentsRestockRequestVM MyEquipmentRestockRequestVM { get; set; }

        public class AddEquipmentRequestCollectionCommandHandler : IRequestHandler<AddEquipmentRequestCollectionCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public AddEquipmentRequestCollectionCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddEquipmentRequestCollectionCommand request, CancellationToken cancellationToken)
            {
                EquipmentRequestCollection _equipmentRequestCollection = new EquipmentRequestCollection
                {
                    EquipmentID = request.MyEquipmentRestockRequestVM.EquipmentDetails.ID,
                    EquipmentRestockRequestID = request.EquipmentRestockID,
                    Quantity = request.MyEquipmentRestockRequestVM.Quantity,
                    EstimatedPrice = request.MyEquipmentRestockRequestVM.EstimatedPrice,
                    CreatedOn = DateTime.Now
                };

                dbContext.EquipmentRequestCollections.Add(_equipmentRequestCollection);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
