using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class SearchEquipmentByIdQuery : IRequest<EquipmentDetails>
    {
        public int SearchedID { get; set; }

        public class SearchEquipmentByIdQueryHandler : IRequestHandler<SearchEquipmentByIdQuery, EquipmentDetails>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchEquipmentByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<EquipmentDetails> Handle(SearchEquipmentByIdQuery request, CancellationToken cancellationToken)
            {
                EquipmentDetails _searchedEquipmentDetails = dbContext.EquipmentsDetails.Find(request.SearchedID);

                return _searchedEquipmentDetails;
            }
        }
    }
}
