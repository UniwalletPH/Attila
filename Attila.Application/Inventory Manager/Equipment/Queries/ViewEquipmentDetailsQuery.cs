using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Equipment.Queries
{
    public class ViewEquipmentDetailsQuery : IRequest<IEnumerable<EquipmentDetails>>
    {
        private readonly int searchedID;

        public ViewEquipmentDetailsQuery (int searchedID)
        {
            this.searchedID = searchedID;
        }

        public class ViewEquipmentDetailsQueryHandler : IRequestHandler<ViewEquipmentDetailsQuery, IEnumerable<EquipmentDetails>>
        {
            private readonly IAttilaDbContext dbContext;

            public ViewEquipmentDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<EquipmentDetails>> Handle(ViewEquipmentDetailsQuery request, CancellationToken cancellationToken)
            {
                var _equipmentDetailsList = await dbContext.EquipmentsDetails.ToListAsync();

                return _equipmentDetailsList;
            }
        }
    }
}
