using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipment.Queries;
using Attila.Application.Inventory_Manager.Food.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                var _equipmentDetailsList = await dbContext.EquipmentDetails.Select(a => new EquipmentsDetailsVM
                {
                    ID = a.ID,
                    Code = a.Code,
                    Name = a.Name,
                    Description = a.Description,
                    UnitType = a.UnitType,
                    EquipmentType = a.EquipmentType

                }).ToListAsync();

                var _foodDetailsList = await dbContext.FoodDetails.Select(a => new FoodsDetailsVM
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
                    UserID = a.UserID, 
                    EquipmentDetailsID = a.EquipmentDetailsID,
                    EquipmentDeliveryID = a.EquipmentDeliveryID

                }).ToListAsync();

                var _foodStocksList = await dbContext.FoodInventories.Select(a => new FoodsInventoryVM 
                {
                    ID = a.ID,
                    Quantity = a.Quantity,
                    ExpirationDate = a.ExpirationDate,
                    EncodingDate = a.EncodingDate,
                    ItemPrice = a.ItemPrice,
                    Remarks = a.Remarks,
                    UserID = a.UserID,
                    FoodDetailsID = a.FoodDetailsID,
                    FoodDeliveryID = a.FoodDeliveryID

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
