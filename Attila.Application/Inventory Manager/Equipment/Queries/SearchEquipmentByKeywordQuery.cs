using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class SearchEquipmentByKeywordQuery : IRequest<IEnumerable<EquipmentsDetailsVM>>
    {
        public string SearchedKeyword { get; set; }

        public class SearchEquipmentByKeywordQueryHandler : IRequestHandler<SearchEquipmentByKeywordQuery, IEnumerable<EquipmentsDetailsVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchEquipmentByKeywordQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<EquipmentsDetailsVM>> Handle(SearchEquipmentByKeywordQuery request, CancellationToken cancellationToken)
            {
                var _searchedKeywordList = new List<EquipmentsDetailsVM>();

                var _searchedKeyword = dbContext.EquipmentsDetails.Where(a => a.Name.Contains(request.SearchedKeyword) ||
                                                                         a.Code.Contains(request.SearchedKeyword) ||
                                                                         a.Description.Contains(request.SearchedKeyword));

                if (_searchedKeyword != null)
                {
                    foreach (var item in _searchedKeyword)
                    {
                        var _searchedResult = new EquipmentsDetailsVM
                        {
                            ID = item.ID,
                            Code = item.Code,
                            Name = item.Name,
                            Description = item.Description,
                            UnitType = item.UnitType,
                            EquipmentType = item.EquipmentType
                        };
                        _searchedKeywordList.Add(_searchedResult);
                    }
                    return _searchedKeywordList;
                }

                else
                {
                    throw new Exception("Searched keyword does not exist!");
                }

            }
        }
    }
}

