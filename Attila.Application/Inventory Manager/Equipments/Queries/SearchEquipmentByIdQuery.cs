using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipments.Queries
{
    public class SearchEquipmentByIdQuery : IRequest<EquipmentsDetailsVM>
    {
        public int SearchedID { get; set; }

        public class SearchEquipmentByIdQueryHandler : IRequestHandler<SearchEquipmentByIdQuery, EquipmentsDetailsVM>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchEquipmentByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<EquipmentsDetailsVM> Handle(SearchEquipmentByIdQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.Equipment _searchedEquipmentDetails = dbContext.EquipmentDetails.Find(request.SearchedID);
                
                if (_searchedEquipmentDetails != null)
                {
                    EquipmentsDetailsVM searchEquipmentDetailsVM = new EquipmentsDetailsVM
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
