using Attila.Application.Interfaces;
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

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public UnitType UnitType { get; set; }

        public EquipmentType EquipmentType { get; set; }
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
                    Code = request.Code,
                    Name = request.Name,
                    Description = request.Description,
                    UnitType = request.UnitType,
                    EquipmentType = request.EquipmentType
                };

                dbContext.EquipmentsDetails.Add(_equipmentDetails);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
