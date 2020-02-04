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
    public class UpdateEquipmentDetailsCommand : IRequest<bool>
    {
        public EquipmentDetails MyEquipmentDetails { get; set; }

        public class UpdateEquipmentDetailsCommandHandler : IRequestHandler<UpdateEquipmentDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateEquipmentDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(UpdateEquipmentDetailsCommand request, CancellationToken cancellationToken)
            {
                var _updatedEquipmentDetails = dbContext.EquipmentsDetails.Find(request.MyEquipmentDetails.ID);

                _updatedEquipmentDetails.Code = request.MyEquipmentDetails.Code;
                _updatedEquipmentDetails.Name = request.MyEquipmentDetails.Name;
                _updatedEquipmentDetails.Description = request.MyEquipmentDetails.Description;
                _updatedEquipmentDetails.UnitType = request.MyEquipmentDetails.UnitType;
                _updatedEquipmentDetails.EquipmentType = request.MyEquipmentDetails.EquipmentType;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
