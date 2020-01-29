using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Equipment.Queries
{
    public class SearchEquipmentByIdQuery : IRequest<EquipmentInventory>
    {
        private readonly int searchedID;

        public SearchEquipmentByIdQuery(int searchedID)
        {
            this.searchedID = searchedID;
        }

        public class SearchEquipmentByIdQueryHandler : IRequestHandler<SearchEquipmentByIdQuery, EquipmentInventory>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchEquipmentByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<EquipmentInventory> Handle(SearchEquipmentByIdQuery request, CancellationToken cancellationToken)
            {
                EquipmentInventory _searchedEquipmentInventory = dbContext.EquipmentsInventory.Find(request.searchedID);

                return _searchedEquipmentInventory;
            }
        }
    }
}
