using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Queries
{
    public class GetAllEquipmentsQuery : IRequest<List<EquipmentsDetailsVM>>
    {
        public class GetAllEquipmentsQueryHandler : IRequestHandler<GetAllEquipmentsQuery, List<EquipmentsDetailsVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetAllEquipmentsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public  async Task<List<EquipmentsDetailsVM>> Handle(GetAllEquipmentsQuery request, CancellationToken cancellationToken)
            {
                var _equipmentList = await dbContext.Equipments
                    .Select(a => new EquipmentsDetailsVM
                    {
                       ID = a.ID,
                       Code = a.Code,
                       Description = a.Description,
                       EquipmentType = a.EquipmentType,
                       Name = a.Name,
                       RentalFee = a.RentalFee,
                       UnitType = a.UnitType,

                    }).ToListAsync();

                return _equipmentList;

            }
        }
    }
}
