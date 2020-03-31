using Attila.Application.Interfaces;
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
    public class GetInventoryQuery : IRequest<InventoriesVM>
    {
        public class GetInventoryQueryHandler : IRequestHandler<GetInventoryQuery, InventoriesVM>
        {
            private readonly IAttilaDbContext dbContext;
            private readonly IMediator mediator;
            public GetInventoryQueryHandler(IAttilaDbContext dbContext, IMediator mediator)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
            }
            public async Task<InventoriesVM> Handle(GetInventoryQuery request, CancellationToken cancellationToken)
            {
                var _foodListData = new List<FoodVM>();
                var _equipmentListData = new List<EquipmentVM>();
                var _inventoryDeliveryData = new List<InventoriesDeliveryVM>();


                var _getFoodData = dbContext.FoodInventories.Include(a => a.FoodDetails);

                foreach (var item in _getFoodData)
                {
                    var _foodAllDetails = new FoodVM
                    {
                        ID = item.ID,
                        Quantity = item.Quantity,
                        EncodingDate = item.EncodingDate,
                        ItemPrice = item.ItemPrice,
                        Remarks = item.Remarks,
                        UserID = item.UserID,
                        FoodDetails = item.FoodDetails
                    };

                    _foodListData.Add(_foodAllDetails);
                }


                var _getEquipmentData = dbContext.EquipmentInventories.Include(a => a.EquipmentDetails);

                foreach (var item in _getEquipmentData)
                {
                    var _equipmentAllDetails = new EquipmentVM
                    {
                        ID = item.ID,
                        Quantity = item.Quantity,
                        EncodingDate = item.EncodingDate,
                        ItemPrice = item.ItemPrice,
                        Remarks = item.Remarks,
                        UserID = item.UserID,
                        EquipmentDetails = item.EquipmentDetails
                    };

                    _equipmentListData.Add(_equipmentAllDetails);
                }


                var _getInventoryDeliveryList = await mediator.Send(new GetInventoryDeliveryQuery());

                foreach (var item in _getInventoryDeliveryList)
                {
                    var _inventoryDelivery = new InventoriesDeliveryVM
                    {
                        ID = item.ID,
                        DeliveryDate = item.DeliveryDate,
                        ReceiptImage = item.ReceiptImage,
                        DeliveryPrice = item.DeliveryPrice,
                        SupplierDetailsID = item.SupplierDetailsID,
                        Remarks = item.Remarks
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
