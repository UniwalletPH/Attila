using Attila.Application.Interfaces;
using Attila.Domain.Entities.Enums;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class UpdateEquipmentDetailsCommand : IRequest<bool>
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public UnitType UnitType { get; set; }

        public EquipmentType EquipmentType { get; set; }

        public class UpdateEquipmentDetailsCommandHandler : IRequestHandler<UpdateEquipmentDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateEquipmentDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(UpdateEquipmentDetailsCommand request, CancellationToken cancellationToken)
            {
                var _updatedEquipmentDetails = dbContext.EquipmentsDetails.Find(request.ID);

                if (_updatedEquipmentDetails != null)
                {
                    _updatedEquipmentDetails.Code = request.Code;
                    _updatedEquipmentDetails.Name = request.Name;
                    _updatedEquipmentDetails.Description = request.Description;
                    _updatedEquipmentDetails.UnitType = request.UnitType;
                    _updatedEquipmentDetails.EquipmentType = request.EquipmentType;

                    await dbContext.SaveChangesAsync();

                    return true;
                }

                else
                {
                    throw new Exception("Equipment ID does not exist!");
                }

            }
        }
    }
}
