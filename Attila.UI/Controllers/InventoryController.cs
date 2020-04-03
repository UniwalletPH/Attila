using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Attila.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Attila.Application.Inventory_Manager.Shared.Queries;
using Microsoft.AspNetCore.Http;
using Attila.Application.Inventory_Manager.Shared.Commands;
using Attila.Application.Inventory_Manager.Foods.Queries;
using Attila.Application.Inventory_Manager.Foods.Commands;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using Attila.Application.Inventory_Manager.Equipments.Commands;
using Microsoft.AspNetCore.Authorization;

namespace Attila.UI.Controllers
{ 
    public class InventoryController : BaseController
    {
        private readonly IMediator mediator;

        public InventoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var _getDetails = await mediator.Send(new GetInventoryDataQuery());

            InventoryDataCVM _inventoryDataVM = new InventoryDataCVM
            {
                FoodListVM = _getDetails.FoodListVM,
                EquipmentListVM = _getDetails.EquipmentListVM,
                InventoryDeliveryVM = _getDetails.InventoryDeliveryVM
            };

            return View(_inventoryDataVM);
        }


        [Authorize(Roles = "InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> AddInventoryDelivery()
        {
            var getSupplierDetails = await mediator.Send(new GetSupplierDetailsQuery());
            List<SelectListItem> _supplierList = new List<SelectListItem>();

            foreach (var item in getSupplierDetails)
            {
                _supplierList.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Name
                });
            }

            InventoryDeliveryCVM InventoryDeliveryListVM = new InventoryDeliveryCVM
            {
                SupplierDetailsList = _supplierList
            };

            return View(InventoryDeliveryListVM);
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> AddInventoryDelivery(InventoryDeliveryCVM inventoriesDeliveryVM)
        {

            var _inventory = new InventoriesDeliveryVM
            {
                DeliveryDate = inventoriesDeliveryVM.DeliveryDate,
                DeliveryPrice = inventoriesDeliveryVM.DeliveryPrice,
                SupplierID = inventoriesDeliveryVM.SupplierDetailsID,
                ReceiptImage = inventoriesDeliveryVM.ReceiptImage,
                Remarks = inventoriesDeliveryVM.Remarks,
            };

            var response = await mediator.Send(new AddInventoryDeliveryCommand
            {
                MyInventoriesDeliveryVM = _inventory
            });

            return Json(response);
        }


        [Authorize(Roles = "Admin,  InventoryManager")]
        [HttpGet]
        public IActionResult AddFood()
        {
            return View();
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> AddFood(FoodDetailsVM foodDetails)
        {

            var response = await mediator.Send(new AddFoodDetailsCommand
            {
                MyFoodDetailsVM = foodDetails
            });

            return Json(response);
        }


        [Authorize(Roles = "Admin,  InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> RequestFoodRestock()
        {

            var getFoodDetails = await mediator.Send(new GetFoodDetailsQuery());
            List<SelectListItem> _list = new List<SelectListItem>();

            foreach (var item in getFoodDetails)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Code + " | " + item.Name + " | " + item.Description
                });
            }

            FoodRestockRequestCVM foodDetailsListVM = new FoodRestockRequestCVM
            {
                FoodDetailsList = _list
            };

            return View(foodDetailsListVM);
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> RequestFoodRestock(FoodsRestockRequestVM foodRestockRequest)
        {

            FoodsRestockRequestVM _foodRequestDetails = new FoodsRestockRequestVM
            {
                FoodDetailsID = foodRestockRequest.FoodDetailsID,
                DateTimeRequest = DateTime.Now,


                Quantity = foodRestockRequest.Quantity,
                Status = Status.Processing,
                UserID = 1
            };


            var response = await mediator.Send(new RequestFoodRestockCommand
            {
                MyFoodRestockRequestVM = _foodRequestDetails
            });

            return Json(response);
        }


        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> AddFoodInventory()
        {
            var getFoodDetails = await mediator.Send(new GetFoodDetailsQuery());
            List<SelectListItem> _list = new List<SelectListItem>();

            foreach (var item in getFoodDetails)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Code + " | " + item.Name + " | " + item.Description
                });
            }

            var getFoodRestock = await mediator.Send(new GetFoodDeliveryQuery());
            List<SelectListItem> _list2 = new List<SelectListItem>();

            foreach (var item in getFoodRestock)
            {
                _list2.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = "Delivery ID: " + item.ID + " | Encoding Date: " + item.DeliveryDate

                });
            }

            FoodInventoryCVM FoodDetailsListVM = new FoodInventoryCVM
            {
                FoodDetailsList = _list,
                FoodDeliveryList = _list2
            };

            return View(FoodDetailsListVM);
        }

        [Authorize(Roles = "Admin,  InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> AddFoodInventory(FoodInventoryVM foodInventory)
        {

            var foodDetails = new FoodInventoryVM
            {
                FoodDetailsID = foodInventory.FoodDetailsID,
                DeliveryDetailsID = foodInventory.DeliveryDetailsID,
                UserID = 1,
                EncodingDate = DateTime.Now,
                ItemPrice = foodInventory.ItemPrice,
                Quantity = foodInventory.Quantity,
                ExpirationDate = foodInventory.ExpirationDate,
                Remarks = foodInventory.Remarks
            };


            var response = await mediator.Send(new AddFoodInventoryCommand
            {
                MyFoodInventoryVM = foodDetails
            });

            return Json(response);
        }


        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public IActionResult AddEquipment()
        {
            return View();
        }
        
        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> AddEquipment(EquipmentsDetailsVM equipDetails)
        {
            var response = await mediator.Send(new AddEquipmentDetailsCommand
            {
                MyEquipmentsDetailsVM = equipDetails
            });

            return Json(response);
        }


        [Authorize(Roles = "Admin,  InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> RequestEquipmentRestock()
        {
            var getEquipmentDetails = await mediator.Send(new GetEquipmentDetailsQuery());
            List<SelectListItem> _list = new List<SelectListItem>();

            foreach (var item in getEquipmentDetails)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Code + " | " + item.Name + " | " + item.Description
                });
            }

            EquipmentRestockRequestCVM equipmentDetailsListVM = new EquipmentRestockRequestCVM
            {
                EquipmentDetailsList = _list
            };

            return View(equipmentDetailsListVM);
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> RequestEquipmentRestock(EquipmentsRestockRequestVM equipmentRestockRequest)
        {
            EquipmentsRestockRequestVM _equipmentRequestDetails = new EquipmentsRestockRequestVM
            {
                EquipmentDetailsID = equipmentRestockRequest.EquipmentDetailsID,
                DateTimeRequest = DateTime.Now,
                Quantity = equipmentRestockRequest.Quantity,
                Status = Status.Processing,
                UserID = CurrentUser.ID
            };

            var response = await mediator.Send(new RequestEquipmentRestockCommand
            {
                MyEquipmentRestockRequestVM = _equipmentRequestDetails
            });

            return Json(response);
        }


        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> AddEquipmentInventory()
        {
            var getEquipmentDetails = await mediator.Send(new GetEquipmentDetailsQuery());
            List<SelectListItem> _list = new List<SelectListItem>();

            foreach (var item in getEquipmentDetails)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Code + " | " + item.Name + " | " + item.Description
                });
            }


            var getEquipmentRestock = await mediator.Send(new GetEquipmentDeliveryQuery());
            List<SelectListItem> _list2 = new List<SelectListItem>();

            foreach (var item in getEquipmentRestock)
            {
                _list2.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = "Delivery ID: " + item.ID + " | Encoding Date: " + item.DeliveryDate
                });
            }


            EquipmentInventoryCVM equipmentDetailsListVM = new EquipmentInventoryCVM
            {
                EquipmentDetailsList = _list,
                EquipmentDeliveryList = _list2
            };

            return View(equipmentDetailsListVM);
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> AddEquipmentInventory(EquipmentsInventoryVM equipmentInventory)
        {

            var equipments = new EquipmentsInventoryVM
            {
                EquipmentDetailsID = equipmentInventory.EquipmentDetailsID,
                DeliveryDetailsID = equipmentInventory.DeliveryDetailsID,
                UserID = 1,
                EncodingDate = DateTime.Now,
                ItemPrice = equipmentInventory.ItemPrice,
                Quantity = equipmentInventory.Quantity,
                Remarks = equipmentInventory.Remarks
            };


            var response = await mediator.Send(new AddEquipmentInventoryCommand
            {
                MyEquipmentsInventoryVM = equipments
            });

            return Json(response);
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public IActionResult UpdateFoodStock()
        {
            return View();
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> UpdateFoodStock(FoodInventoryVM foodInventory)
        { 
              var response=   await mediator.Send(new UpdateFoodStockCommand
                {
                    MyFoodInventoryVM = foodInventory
                });
                
             
            return Json(response);
        }


        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public IActionResult RegisterSupplier()
        {
            return View();
        }

        [Authorize(Roles = "Admin, nventoryManager")]
        [HttpPost]
        public async Task<IActionResult> RegisterSupplier(SuppliersDetailsVM suppliersDetails)
        {
            var response = await mediator.Send(new AddSupplierDetailsCommand
            {
                MySuppliersDetailsVM = suppliersDetails
            });

            return Json(response);
        }


        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> Suppliers()
        {
            var _suppliers = await mediator.Send(new GetSupplierDetailsQuery());
            return View(_suppliers);
        }


        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> SearchDeliveryById(int DeliveryID)
        {
            var _inventoryDelivery = await mediator.Send(new SearchDeliveryByIdQuery { DeliveryID = DeliveryID });

            return View(_inventoryDelivery);
        }


         
         
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
