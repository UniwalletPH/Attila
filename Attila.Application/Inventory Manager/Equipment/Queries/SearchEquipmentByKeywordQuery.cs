using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Equipment.Queries
{
    public class SearchEquipmentByKeywordQuery : IRequest<IEnumerable<EquipmentInventory>>
    {
        private readonly string searchedKeyword;
        public SearchEquipmentByKeywordQuery(string searchedKeyword)
        {
            this.searchedKeyword = searchedKeyword;
        }

        public class SearchEquipmentByKeywordQueryHandler : IRequestHandler<SearchEquipmentByKeywordQuery, IEnumerable<EquipmentInventory>>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchEquipmentByKeywordQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<EquipmentInventory>> Handle(SearchEquipmentByKeywordQuery request, CancellationToken cancellationToken)
            {
                var _searchedKeyword = dbContext.EquipmentsInventory.Where(a => a.Remarks.Contains(request.searchedKeyword));

                return _searchedKeyword.ToList();
            }
        }
    }
}
