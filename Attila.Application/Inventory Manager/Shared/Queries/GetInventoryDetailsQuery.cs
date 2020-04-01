using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using Attila.Application.Inventory_Manager.Foods.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Shared.Queries
{
    public class GetInventoryDetailsQuery : IRequest<InventoryDetailsVM>
    {
        public class GetInventoryDetailsQueryHandler : IRequestHandler<GetInventoryDetailsQuery, InventoryDetailsVM>
        {
            private readonly IAttilaDbContext dbContext;

            public GetInventoryDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<InventoryDetailsVM> Handle(GetInventoryDetailsQuery request, CancellationToken cancellationToken)
            {
                var _equipmentDetailsList = await dbContext.Equipments.Select(a => new EquipmentsDetailsVM
                {
                    ID = a.ID,
                    Code = a.Code,
                    Name = a.Name,
                    Description = a.Description,
                    UnitType = a.UnitType,
                    EquipmentType = a.EquipmentType

                }).ToListAsync();

                var _foodDetailsList = await dbContext.Foods.Select(a => new FoodsDetailsVM
                {
                    ID = a.ID,
                    Code = a.Code,
                    Name = a.Name,
                    Specification = a.Specification,
                    Description = a.Description,
                    Unit = a.Unit,
                    FoodType = a.FoodType

                }).ToListAsync();

                var _equipmentStocksList = await dbContext.EquipmentInventories.Select(a => new EquipmentsInventoryVM
                {
                    ID = a.ID,
                    Quantity = a.Quantity,
                    EncodingDate = a.EncodingDate,
                    ItemPrice = a.ItemPrice,
                    Remarks = a.Remarks,
                    UserID = a.InventoryManagerID,
                    EquipmentDetailsID = a.EquipmentID,
                    DeliveryDetailsID = a.DeliveryID

                }).ToListAsync();

                var _foodStocksList = await dbContext.FoodInventories.Select(a => new FoodsInventoryVM
                {
                    ID = a.ID,
                    Quantity = a.Quantity,
                    ExpirationDate = a.ExpirationDate,
                    EncodingDate = a.EncodingDate,
                    ItemPrice = a.ItemPrice,
                    Remarks = a.Remarks,
                    UserID = a.InventoryManagerID,
                    FoodDetailsID = a.FoodID,
                    DeliveryDetailsID = a.DeliveryID

                }).ToListAsync();


                InventoryDetailsVM inventoryDetailsVM = new InventoryDetailsVM
                {
                    EquipmentsDetailsVM = _equipmentDetailsList,
                    FoodsDetailsVM = _foodDetailsList,
                    EquipmentsInventoryVM = _equipmentStocksList,
                    FoodsInventoryVM = _foodStocksList
                };

                return inventoryDetailsVM;
            }
        }
    }
}
