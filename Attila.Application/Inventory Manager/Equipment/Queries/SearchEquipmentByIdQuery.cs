using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class SearchEquipmentByIdQuery : IRequest<EquipmentInventory>
    {
        public int SearchedID { get; set; }

        public class SearchEquipmentByIdQueryHandler : IRequestHandler<SearchEquipmentByIdQuery, EquipmentInventory>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchEquipmentByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<EquipmentInventory> Handle(SearchEquipmentByIdQuery request, CancellationToken cancellationToken)
            {
                EquipmentInventory _searchedEquipmentInventory = dbContext.EquipmentsInventory.Find(request.SearchedID);

                return _searchedEquipmentInventory;
            }
        }
    }
}
