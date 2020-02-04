using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class SearchEquipmentByKeywordQuery : IRequest<IEnumerable<EquipmentDetails>>
    {
        public string SearchedKeyword { get; set; }

        public class SearchEquipmentByKeywordQueryHandler : IRequestHandler<SearchEquipmentByKeywordQuery, IEnumerable<EquipmentDetails>>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchEquipmentByKeywordQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<EquipmentDetails>> Handle(SearchEquipmentByKeywordQuery request, CancellationToken cancellationToken)
            {
                var _searchedKeyword = dbContext.EquipmentsDetails.Where(a => a.Name.Contains(request.SearchedKeyword) ||
                                                                         a.Code.Contains(request.SearchedKeyword) ||
                                                                         a.Description.Contains(request.SearchedKeyword));

                return _searchedKeyword.ToList();
            }
        }
    }
}

