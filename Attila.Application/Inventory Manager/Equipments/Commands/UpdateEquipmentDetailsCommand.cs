using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Commands
{
    public class UpdateEquipmentDetailsCommand : IRequest<bool>
    {
        public EquipmentsDetailsVM MyEquipmentDetails { get; set; }

        public class UpdateEquipmentDetailsCommandHandler : IRequestHandler<UpdateEquipmentDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateEquipmentDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(UpdateEquipmentDetailsCommand request, CancellationToken cancellationToken)
            {
                var _updatedEquipmentDetails = dbContext.Equipments.Find(request.MyEquipmentDetails.ID);

                if (_updatedEquipmentDetails != null)
                {
                    _updatedEquipmentDetails.Code = request.MyEquipmentDetails.Code;
                    _updatedEquipmentDetails.Name = request.MyEquipmentDetails.Name;
                    _updatedEquipmentDetails.Description = request.MyEquipmentDetails.Description;
                    _updatedEquipmentDetails.RentalFee = request.MyEquipmentDetails.RentalFee;
                    _updatedEquipmentDetails.UnitType = request.MyEquipmentDetails.UnitType;
                    _updatedEquipmentDetails.EquipmentType = request.MyEquipmentDetails.EquipmentType;

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
