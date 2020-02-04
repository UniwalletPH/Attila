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
    public class AddEquipmentDetailsInventoryCommand : IRequest<bool>
    {
        public readonly EquipmentDetails myEquipmentDetails;
        public AddEquipmentDetailsInventoryCommand(EquipmentDetails myEquipmentDetails)
        {
            this.myEquipmentDetails = myEquipmentDetails;
        }

        public EquipmentDetails MyEquipmentDetails { get; set; }

        public class AddEquipmentDetailsInventoryCommandHandler : IRequestHandler<AddEquipmentDetailsInventoryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public AddEquipmentDetailsInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(AddEquipmentDetailsInventoryCommand request, CancellationToken cancellationToken)
            {
                EquipmentDetails _equipmentDetails = new EquipmentDetails
                {
                    Code = request.MyEquipmentDetails.Code,
                    Name = request.MyEquipmentDetails.Name,
                    Description = request.MyEquipmentDetails.Description,
                    UnitType = request.MyEquipmentDetails.UnitType
                };

                dbContext.EquipmentsDetails.Add(_equipmentDetails);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
