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
    public class GetEquipmentDetailsQuery : IRequest<IEnumerable<EquipmentDetailsVM>>
    {
        public class ViewEquipmentDetailsQueryHandler : IRequestHandler<GetEquipmentDetailsQuery, IEnumerable<EquipmentDetailsVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewEquipmentDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<EquipmentDetailsVM>> Handle(GetEquipmentDetailsQuery request, CancellationToken cancellationToken)
            {
                var _equipmentDetailsList = await dbContext.EquipmentsDetails.Select(a => new EquipmentDetailsVM 
                { 
                    Code = a.Code, 
                    Description = a.Description, 
                    EquipmentType = a.EquipmentType, 
                    ID = a.ID, 
                    Name = a.Name, 
                    UnitType = a.UnitType

                }).ToListAsync();

                return _equipmentDetailsList;
            }
        }
    }
}
