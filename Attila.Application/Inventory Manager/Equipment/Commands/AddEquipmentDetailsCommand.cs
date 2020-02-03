using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class AddEquipmentDetailsCommand : IRequest<bool>
    {

        public EquipmentDetails MyEquipmentDetails { get; set; }

        public class AddEquipmentDetailsCommandHandler : IRequestHandler<AddEquipmentDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public AddEquipmentDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(AddEquipmentDetailsCommand request, CancellationToken cancellationToken)
            {
                EquipmentDetails _equipmentDetails = new EquipmentDetails
                {
                    Code = request.MyEquipmentDetails.Code,
                    Name = request.MyEquipmentDetails.Name,
                    Description = request.MyEquipmentDetails.Description,
                    UnitType = request.MyEquipmentDetails.UnitType,
                    EquipmentType = request.MyEquipmentDetails.EquipmentType
                };

                dbContext.EquipmentsDetails.Add(_equipmentDetails);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
