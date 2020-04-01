using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipment.Queries;
using Attila.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class AddEquipmentDetailsCommand : IRequest<bool>
    {
        public EquipmentsDetailsVM MyEquipmentsDetailsVM { get; set; }

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
                    Code = request.MyEquipmentsDetailsVM.Code,
                    Name = request.MyEquipmentsDetailsVM.Name,
                    Description = request.MyEquipmentsDetailsVM.Description,
                    RentalFee = request.MyEquipmentsDetailsVM.RentalFee,
                    UnitType = request.MyEquipmentsDetailsVM.UnitType,
                    EquipmentType = request.MyEquipmentsDetailsVM.EquipmentType
                };

                dbContext.EquipmentDetails.Add(_equipmentDetails);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
