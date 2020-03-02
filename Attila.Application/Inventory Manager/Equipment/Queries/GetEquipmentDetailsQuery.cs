using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipment.Queries;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class GetEquipmentDetailsQuery : IRequest<IEnumerable<EquipmentsDetailsVM>>
    {
        public class GetEquipmentDetailsQueryHandler : IRequestHandler<GetEquipmentDetailsQuery, IEnumerable<EquipmentsDetailsVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetEquipmentDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<EquipmentsDetailsVM>> Handle(GetEquipmentDetailsQuery request, CancellationToken cancellationToken)
            {
                var _equipmentDetailsList = await dbContext.EquipmentsDetails.Select(a => new EquipmentsDetailsVM 
                {
                    ID = a.ID,
                    Code = a.Code,
                    Name = a.Name,
                    Description = a.Description,
                    UnitType = a.UnitType,
                    EquipmentType = a.EquipmentType

                }).ToListAsync();

                return _equipmentDetailsList;
            }
        }
    }
}
