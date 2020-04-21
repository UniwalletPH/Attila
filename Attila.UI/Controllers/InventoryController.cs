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
using Attila.Application.Notification.Commands;
using Attila.Application.Admin.Equipments.Queries;
using Attila.Application.Admin.Foods.Queries;

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
            var _pendingEquipmentRestockRequests = await mediator.Send(new GetAllPendingEquipmentRestockRequestQuery { });
            var _pendingFoodRestockRequests = await mediator.Send(new GetAllPendingFoodRestockRequestQuery { });

            InventoryDataCVM _inventoryDataVM = new InventoryDataCVM
            {
                FoodListVM = _getDetails.FoodListVM,
                EquipmentListVM = _getDetails.EquipmentListVM,
                InventoryDeliveryVM = _getDetails.InventoryDeliveryVM,
                EquipmentRequestList = _pendingEquipmentRestockRequests,
                FoodRequestList = _pendingFoodRestockRequests
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

            InventoriesDeliveryVM _inventory = new InventoriesDeliveryVM
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

            await mediator.Send(new AddInventoryNotificationCommand
            {
                Message = "New Delivery",
                TargetUserID = -1,
                MethodName = "/Inventory/Details",
                RequestID = response

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
        public async Task<IActionResult> AddFood(FoodDetailsCVM foodDetailsVM)
        {
            FoodDetailsVM _food = new FoodDetailsVM
            {
                Code = foodDetailsVM.Code,
                Name = foodDetailsVM.Name,
                Specification = foodDetailsVM.Specification,
                Description = foodDetailsVM.Description,
                Unit = foodDetailsVM.Unit,
                FoodType = foodDetailsVM.FoodType,
            };

            var response = await mediator.Send(new AddFoodDetailsCommand
            {
                MyFoodDetailsVM = _food
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
        public async Task<IActionResult> AddFoodInventory(FoodInventoryCVM foodInventoryVM)
        {

            FoodInventoryVM _foodInventory = new FoodInventoryVM
            {
                FoodDetailsID = foodInventoryVM.FoodDetailsID,
                DeliveryDetailsID = foodInventoryVM.DeliveryDetailsID,
                UserID = CurrentUser.ID,
                ItemPrice = foodInventoryVM.ItemPrice,
                Quantity = foodInventoryVM.Quantity,
                ExpirationDate = foodInventoryVM.ExpirationDate,
                Remarks = foodInventoryVM.Remarks
            };


            var response = await mediator.Send(new AddFoodInventoryCommand
            {
                MyFoodInventoryVM = _foodInventory
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
                    Text = item.Code + " | " + item.Name + " | " + item.Unit
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
        public async Task<IActionResult> RequestFoodRestock(FoodRestockRequestCVM foodRestockRequestVM)
        {
            FoodsRestockRequestVM _foodRequestCollection = new FoodsRestockRequestVM
            {
                UserID = CurrentUser.ID,
                FoodRequestCollection = foodRestockRequestVM.FoodRequestCollectionCVM
            };

            var response = await mediator.Send(new RequestFoodRestockCommand
            {
                MyFoodRestockRequestVM = _foodRequestCollection
            });

            //Send Notif to Admin
            await mediator.Send(new AddInventoryNotificationCommand 
            { 
                Message = "New Food Restock Request",
                TargetUserID = -1,
                MethodName = "/Inventory/FoodRestockRequestDetails",
                RequestID = response 
            });

            return Json(response);
        }


        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> UpdateFoodStock()
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

            FoodInventoryCVM FoodDetailsListVM = new FoodInventoryCVM
            {
                FoodDetailsList = _list,
            };

            return View(FoodDetailsListVM);
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> UpdateFoodStock(FoodInventoryCVM foodInventoryVM)
        {
            FoodInventoryVM _updateFoodStock = new FoodInventoryVM
            {
                FoodDetailsID = foodInventoryVM.FoodDetailsID,
                Quantity = foodInventoryVM.Quantity
            };

            var response = await mediator.Send(new UpdateFoodStockCommand
            {
                MyFoodInventoryVM = _updateFoodStock
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
        public async Task<IActionResult> AddEquipment(EquipmentDetailsCVM equipmentDetailsVM)
        {
            EquipmentsDetailsVM _equipment = new EquipmentsDetailsVM
            {
                Code = equipmentDetailsVM.Code,
                Name = equipmentDetailsVM.Name,
                Description = equipmentDetailsVM.Description,
                RentalFee = equipmentDetailsVM.RentalFee,
                UnitType = equipmentDetailsVM.UnitType,
                EquipmentType = equipmentDetailsVM.EquipmentType,
            };

            var response = await mediator.Send(new AddEquipmentDetailsCommand
            {
                MyEquipmentsDetailsVM = _equipment
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
        public async Task<IActionResult> AddEquipmentInventory(EquipmentInventoryCVM equipmentInventoryVM)
        {

            EquipmentsInventoryVM _equipmentInventory = new EquipmentsInventoryVM
            {
                EquipmentDetailsID = equipmentInventoryVM.EquipmentDetailsID,
                DeliveryDetailsID = equipmentInventoryVM.DeliveryDetailsID,
                UserID = CurrentUser.ID,
                EncodingDate = DateTime.Now,
                ItemPrice = equipmentInventoryVM.ItemPrice,
                Quantity = equipmentInventoryVM.Quantity,
                Remarks = equipmentInventoryVM.Remarks
            };


            var response = await mediator.Send(new AddEquipmentInventoryCommand
            {
                MyEquipmentsInventoryVM = _equipmentInventory
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
        public async Task<IActionResult> RequestEquipmentRestock(EquipmentRestockRequestCVM equipmentRestockRequestVM)
        {
            EquipmentsRestockRequestVM _equipmentRequest = new EquipmentsRestockRequestVM
            {
                UserID = CurrentUser.ID,
                EquipmentRequestCollection = equipmentRestockRequestVM.EquipmentRequestCollectionCVM
            };

            var response = await mediator.Send(new RequestEquipmentRestockCommand
            {
                MyEquipmentRestockRequestVM = _equipmentRequest
            });

            //Send Notif to Admin
            await mediator.Send(new AddInventoryNotificationCommand 
            { 
                Message = "New Equipment Restock Request",
                TargetUserID = -1,
                MethodName = "/Inventory/EquipmentRestockRequestDetails",
                RequestID = response 
            });


            return Json(response);
        }


        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> UpdateEquipmentStock()
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


            EquipmentInventoryCVM equipmentDetailsListVM = new EquipmentInventoryCVM
            {
                EquipmentDetailsList = _list,
            };

            return View(equipmentDetailsListVM);
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> UpdateEquipmentStock(EquipmentInventoryCVM equipmentInventoryVM)
        {
            EquipmentsInventoryVM _updateEquipmentStock = new EquipmentsInventoryVM
            {
                EquipmentDetailsID = equipmentInventoryVM.EquipmentDetailsID,
                Quantity = equipmentInventoryVM.Quantity
            };

            var response = await mediator.Send(new UpdateEquipmentStockCommand
            {
                MyEquipmentInventoryVM = _updateEquipmentStock
            });


            return Json(response);
        }


        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public IActionResult RegisterSupplier()
        {
            return View();
        }

        [Authorize(Roles = "Admin, InventoryManager")]
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
        public async Task<IActionResult> Details(int id)
        {
            var _inventoryDelivery = await mediator.Send(new SearchDeliveryByIdQuery { DeliveryID = id });

            return View(_inventoryDelivery);
        }

        [HttpGet]
        public async Task<IActionResult> FoodRestockRequestDetails(int id)
        {
            var _details = await mediator.Send(new GetFoodRestockRequestDetailsQuery { RequestID = id });

            return View(_details);
        }

        [HttpGet]
        public async Task<IActionResult> EquipmentRestockRequestDetails(int id)
        {
            var _details = await mediator.Send(new GetEquipmentRestockRequestDetailsQuery { RequestID = id });

            return View(_details);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
}
