using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipment.Queries;
using Attila.Domain.Entities.Enums;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class AddEquipmentDetailsCommand : IRequest<bool>
    {
        public EquipmentDetailsVM EquipmentsDetailsVM { get; set; }

        public class AddEquipmentDetailsCommandHandler : IRequestHandler<AddEquipmentDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public AddEquipmentDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddEquipmentDetailsCommand request, CancellationToken cancellationToken)
            {
                var _equipmentDetails = new EquipmentDetails
                {
                    Code = request.EquipmentsDetailsVM.Code,
                    Name = request.EquipmentsDetailsVM.Name,
                    Description = request.EquipmentsDetailsVM.Description,
                    UnitType = request.EquipmentsDetailsVM.UnitType,
                    EquipmentType = request.EquipmentsDetailsVM.EquipmentType
                };

                dbContext.EquipmentsDetails.Add(_equipmentDetails);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
