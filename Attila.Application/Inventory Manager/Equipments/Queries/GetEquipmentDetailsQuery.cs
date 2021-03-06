﻿using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Queries
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
                var _equipmentDetailsList = await dbContext.Equipments.Select(a => new EquipmentsDetailsVM
                {
                    ID = a.ID,
                    Code = a.Code,
                    Name = a.Name,
                    Description = a.Description,
                    RentalFee = a.RentalFee,
                    UnitType = a.UnitType,
                    EquipmentType = a.EquipmentType

                }).ToListAsync();

                return _equipmentDetailsList;
            }
        }
    }
}
