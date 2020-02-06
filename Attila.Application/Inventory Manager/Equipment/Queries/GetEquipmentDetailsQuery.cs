using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Commands
{
    public class GetEquipmentDetailsQuery : IRequest<IEnumerable<EquipmentDetails>>
    {
        public class ViewEquipmentDetailsQueryHandler : IRequestHandler<GetEquipmentDetailsQuery, IEnumerable<EquipmentDetails>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewEquipmentDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<EquipmentDetails>> Handle(GetEquipmentDetailsQuery request, CancellationToken cancellationToken)
            {
                var _equipmentDetailsList = await dbContext.EquipmentsDetails.ToListAsync();

                return _equipmentDetailsList;
            }
        }
    }
}
