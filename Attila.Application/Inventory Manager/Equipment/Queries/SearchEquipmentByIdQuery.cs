using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class SearchEquipmentByIdQuery : IRequest<EquipmentDetailsVM>
    {
        public int SearchedID { get; set; }

        public class SearchEquipmentByIdQueryHandler : IRequestHandler<SearchEquipmentByIdQuery, EquipmentDetailsVM>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchEquipmentByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<EquipmentDetailsVM> Handle(SearchEquipmentByIdQuery request, CancellationToken cancellationToken)
            {
                EquipmentDetails _searchedEquipmentDetails = dbContext.EquipmentsDetails.Find(request.SearchedID);
                if (_searchedEquipmentDetails != null)
                {
                    EquipmentDetailsVM searchEquipmentDetailsVM = new EquipmentDetailsVM
                    {
                        ID = request.SearchedID,
                        Code = _searchedEquipmentDetails.Code,
                        Name = _searchedEquipmentDetails.Name,
                        Description = _searchedEquipmentDetails.Description,
                        UnitType = _searchedEquipmentDetails.UnitType,
                        EquipmentType = _searchedEquipmentDetails.EquipmentType
                    };
                    return searchEquipmentDetailsVM;
                }
                else
                {
                    throw new Exception("Equipment Details ID does not exist!");
                }

            }
        }
    }
}
