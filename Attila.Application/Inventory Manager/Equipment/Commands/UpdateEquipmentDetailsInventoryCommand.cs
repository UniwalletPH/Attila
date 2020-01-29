using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Equipment.Commands
{
    public class UpdateEquipmentDetailsInventoryCommand : IRequest<bool>
    {
        private readonly EquipmentDetails myEquipmentDetails;
        public UpdateEquipmentDetailsInventoryCommand(EquipmentDetails myEquipmentDetails)
        {
            this.myEquipmentDetails = myEquipmentDetails;
        }

        public class UpdateEquipmentDetailsInventoryCommandHandler : IRequestHandler<UpdateEquipmentDetailsInventoryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateEquipmentDetailsInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(UpdateEquipmentDetailsInventoryCommand request, CancellationToken cancellationToken)
            {
                var _updatedEquipmentDetails = dbContext.EquipmentsDetails.Find(request.myEquipmentDetails.ID);

                _updatedEquipmentDetails.Code = request.myEquipmentDetails.Code;
                _updatedEquipmentDetails.Name = request.myEquipmentDetails.Name;
                _updatedEquipmentDetails.Description = request.myEquipmentDetails.Description;
                _updatedEquipmentDetails.UnitType = request.myEquipmentDetails.UnitType;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
