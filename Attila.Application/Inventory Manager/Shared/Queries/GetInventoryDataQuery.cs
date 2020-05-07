using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using Attila.Application.Inventory_Manager.Foods.Queries;
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
    public class GetInventoryDataQuery : IRequest<InventoriesVM>
    {
        public class GetInventoryQueryHandler : IRequestHandler<GetInventoryDataQuery, InventoriesVM>
        {
            private readonly IAttilaDbContext dbContext;
            private readonly IMediator mediator;
            public GetInventoryQueryHandler(IAttilaDbContext dbContext, IMediator mediator)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
            }
            public async Task<InventoriesVM> Handle(GetInventoryDataQuery request, CancellationToken cancellationToken)
            {
                var _foodListData = new List<FoodVM>();
                var _equipmentListData = new List<EquipmentVM>();
                var _inventoryDeliveryData = new List<InventoriesDeliveryVM>();


                var _getFoodData = await mediator.Send(new GetFoodStockDetailsQuery());

                foreach (var item in _getFoodData)
                {
                    var _foodAllDetails = new FoodVM
                    {
                        ID = item.ID,
                        Quantity = item.Quantity,
                        ExpirationDate = item.ExpirationDate,
                        EncodingDate = item.EncodingDate,
                        ItemPrice = item.ItemPrice,
                        Remarks = item.Remarks,
                        UserID = item.UserID,
                        FoodDetails = item.FoodDetailsVM
                    };

                    _foodListData.Add(_foodAllDetails);
                }


                //var _getEquipmentData = await mediator.Send(new GetEquipmentStockDetailsQuery());
                var _getEquipmentDetails = await mediator.Send(new GetEquipmentDetailsQuery());


                foreach (var equipmentDetails in _getEquipmentDetails)
                {
                    var _getEquipmentInventory = await dbContext.EquipmentInventories.Where(a => a.EquipmentID == equipmentDetails.ID).ToListAsync();

                    int _totalEquipmentQuantity = new int();


                    foreach (var item in _getEquipmentInventory)
                    {
                        _totalEquipmentQuantity += item.Quantity;
                    }

                    var _equipmentStockDetails = new EquipmentVM
                    {
                        Name = equipmentDetails.Name,
                        Description = equipmentDetails.Description,
                        RentalFee = equipmentDetails.RentalFee,
                        Quantity = _totalEquipmentQuantity,
                        UnitType = equipmentDetails.UnitType,
                        EquipmentType = equipmentDetails.EquipmentType
                    };

                    _equipmentListData.Add(_equipmentStockDetails);
                }


                //foreach (var item in _getEquipmentData)
                //{
                //    var _equipmentAllDetails = new EquipmentVM
                //    {
                //        ID = item.ID,
                //        Quantity = item.Quantity,
                //        EncodingDate = item.EncodingDate,
                //        ItemPrice = item.ItemPrice,
                //        Remarks = item.Remarks,
                //        UserID = item.UserID,
                //        EquipmentDetails = item.EquipmentDetailsVM
                //    };

                //    _equipmentListData.Add(_equipmentAllDetails);
                //}


                var _getInventoryDeliveryList = await mediator.Send(new GetInventoryDeliveryQuery());

                foreach (var item in _getInventoryDeliveryList)
                {
                    var _inventoryDelivery = new InventoriesDeliveryVM
                    {
                        ID = item.ID,
                        DeliveryDate = item.DeliveryDate,
                        ReceiptImage = item.ReceiptImage,
                        DeliveryPrice = item.DeliveryPrice,
                        SupplierID = item.SupplierID,
                        Remarks = item.Remarks,
                        Supplier = item.Supplier
                    };

                    _inventoryDeliveryData.Add(_inventoryDelivery);
                }


                InventoriesVM _inventoryVM = new InventoriesVM 
                {
                    FoodListVM = _foodListData,
                    EquipmentListVM = _equipmentListData,
                    InventoryDeliveryVM = _inventoryDeliveryData
                };


                return _inventoryVM;
            }
        }
    }
}
