using Atilla.Application.Admin.Equipments.Commands;
using Attila.Application.Admin.Equipments.Commands;
using Attila.Application.Admin.Equipments.Queries;
using Attila.Application.Admin.Foods.Commands;
using Attila.Application.Admin.Foods.Queries;
using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Inventory_Manager.Equipments.Commands;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using Attila.Application.Inventory_Manager.Events.Queries;
using Attila.Application.Inventory_Manager.Foods.Commands;
using Attila.Application.Inventory_Manager.Foods.Queries;
using Attila.Application.Inventory_Manager.Shared.Commands;
using Attila.Application.Inventory_Manager.Shared.Queries;
using Attila.Application.Notification.Commands;
using Attila.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

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
            var _forApprovalEquipmentRequests = await mediator.Send(new GetAllForApprovalEquipmentRequestQuery { });
            var _forApprovalFoodRequests = await mediator.Send(new GetAllForApprovalFoodRequestQuery { });

            //var _getFoodToExpireList = await mediator.Send(new ExpirationDateNotificationQuery());

            InventoryDataCVM _inventoryDataVM = new InventoryDataCVM
            {
                FoodListVM = _getDetails.FoodListVM,
                EquipmentListVM = _getDetails.EquipmentListVM,
                InventoryDeliveryVM = _getDetails.InventoryDeliveryVM,
                EquipmentRequestList = _pendingEquipmentRestockRequests,
                FoodRequestList = _pendingFoodRestockRequests,
                ForApprovalEquipmentRequestList = _forApprovalEquipmentRequests,
                ForApprovalFoodRequestList = _forApprovalFoodRequests
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
            _supplierList.Add(new SelectListItem
            {
                Value = "Add New Supplier",
                Text = "Add New Supplier"
            });
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
            if (inventoriesDeliveryVM.file == null)
            {
                InventoriesDeliveryVM _inventory = new InventoriesDeliveryVM
                {
                    DeliveryDate = inventoriesDeliveryVM.DeliveryDate,
                    DeliveryPrice = inventoriesDeliveryVM.DeliveryPrice,
                    SupplierID = inventoriesDeliveryVM.SupplierDetailsID,
                    ReceiptImage = null,
                    Remarks = inventoriesDeliveryVM.Remarks,
                };

                var response = await mediator.Send(new AddInventoryDeliveryCommand
                {
                    MyInventoriesDeliveryVM = _inventory
                });

                var result = await mediator.Send(new AddInventoryNotificationCommand
                {
                    Message = "New Delivery",
                    TargetUserID = -1,
                    MethodName = "/Inventory/Details",
                    RequestID = response

                });

                return Json(result);
            }

            else if (inventoriesDeliveryVM.file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    inventoriesDeliveryVM.file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);


                    InventoriesDeliveryVM _inventory = new InventoriesDeliveryVM
                    {
                        DeliveryDate = inventoriesDeliveryVM.DeliveryDate,
                        DeliveryPrice = inventoriesDeliveryVM.DeliveryPrice,
                        SupplierID = inventoriesDeliveryVM.SupplierDetailsID,
                        ReceiptImage = fileBytes,
                        Remarks = inventoriesDeliveryVM.Remarks,
                    };

                    var response = await mediator.Send(new AddInventoryDeliveryCommand
                    {
                        MyInventoriesDeliveryVM = _inventory
                    });

                    var result = await mediator.Send(new AddInventoryNotificationCommand
                    {
                        Message = "New Delivery",
                        TargetUserID = -1,
                        MethodName = "/Inventory/Details",
                        RequestID = response

                    });

                    return Json(result);
                }
            }
            else
            {
                return Json(false);
            }
        }


        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> DeliveryDetails(int id)
        {
            var _inventoryDelivery = await mediator.Send(new SearchDeliveryByIdQuery { DeliveryID = id });

            return View(_inventoryDelivery);
        }


        [Authorize(Roles = "Admin,  InventoryManager")]
        [HttpGet]
        public IActionResult AddFood()
        {
            return View();
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> AddFood(FoodDetailsCVM foodDetailsCVM)
        {
            FoodDetailsVM _food = new FoodDetailsVM
            {
                Code = foodDetailsCVM.Code,
                Name = foodDetailsCVM.Name,
                Specification = foodDetailsCVM.Specification,
                Description = foodDetailsCVM.Description,
                Unit = foodDetailsCVM.Unit,
                FoodType = foodDetailsCVM.FoodType,
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

            _list.Add(new SelectListItem { Text = "Add New Food", Value = "Add New Food" });
            var getFoodRestock = await mediator.Send(new GetFoodDeliveryQuery());
            List<SelectListItem> _list2 = new List<SelectListItem>();

            foreach (var item in getFoodRestock)
            {
                _list2.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = "Delivery ID: " + item.ID + " | Delivery Date: " + item.DeliveryDate.ToString("MMM dd, yyyy")

                });
            }
            _list2.Add(new SelectListItem { Text = "Add New Delivery", Value = "Add New Delivery" });

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


        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> CheckOutFoodStock()
        {
            var getFoodDetails = await mediator.Send(new GetFoodStockDetailsQuery());
            List<SelectListItem> _list = new List<SelectListItem>();

            foreach (var item in getFoodDetails)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.FoodDetailsVM.Code + " | " + item.FoodDetailsVM.Name + " | Quantity: " + item.Quantity
                });
            }

            _list.Add(new SelectListItem { Text = "Add New Food", Value = "Add New Food" });

            FoodInventoryCVM FoodDetailsListVM = new FoodInventoryCVM
            {
                FoodStockDetailsList = _list,
            };

            return View(FoodDetailsListVM);
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> CheckOutFoodStock(FoodInventoryCVM foodInventoryVM)
        {
            FoodInventoryVM _updateFoodStock = new FoodInventoryVM
            {
                FoodDetailsID = foodInventoryVM.FoodDetailsID,
                Quantity = foodInventoryVM.Quantity
            };

            var response = await mediator.Send(new CheckOutFoodStockCommand
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
            _list.Add(new SelectListItem
            {
                Value = "Add New Equipment",
                Text = "Add New Equipment"
            });
            var getEquipmentRestock = await mediator.Send(new GetEquipmentDeliveryQuery());
            List<SelectListItem> _list2 = new List<SelectListItem>();

            foreach (var item in getEquipmentRestock)
            {
                _list2.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = "Delivery ID: " + item.ID + " | Delivery Date: " + item.DeliveryDate.ToString("MMM dd, yyyy")
                });
            }

            _list2.Add(new SelectListItem
            {
                Value = "Add New Delivery",
                Text = "Add New Delivery"
            });
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

        [Authorize(Roles = "InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> CheckInEquipmentStockList(int EventID)
        {
            var getEquipmentCheckOutList = await mediator.Send(new GetEventCheckOutEquipmentListQuery { EventDetailsID = EventID });
            var getEquipmentDetails = await mediator.Send(new GetEventDetailsQuery { EventDetailsID = EventID });

            //List<SelectListItem> _list = new List<SelectListItem>();

            //foreach (var item in getEquipmentCheckOutList)
            //{
            //    _list.Add(new SelectListItem
            //    {
            //        Value = item.ID.ToString(),
            //        Text = "Check Out ID: " + item.ID + " | " + item.Equipment.Code + " | " + item.Equipment.Name + " | " + item.Equipment.Description + " | Quantity: " + item.Quantity + " | Check Out Date: " + item.TrackingDate 
            //    });
            //}

            EquipmentInventoryCVM equipmentDetailsListVM = new EquipmentInventoryCVM
            {
                EquipmentTrackingVMs = getEquipmentCheckOutList,
                EventDetailsVM = getEquipmentDetails
            };

            return View(equipmentDetailsListVM);
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> CheckInEquipmentStock(int EventID, int TrackingID)
        {
            var getEquipmentTracking = await mediator.Send(new SearchEquipmentTrackingQuery { EquipmentTrackingID = TrackingID });
            var getEquipmentList = await mediator.Send(new GetAllEquipmentsQuery());

            List<SelectListItem> _list = new List<SelectListItem>();

            foreach (var item in getEquipmentList)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Code + " | " + item.Name + " | " + item.Description
                });
            }

            EquipmentInventoryCVM equipmentTracking = new EquipmentInventoryCVM
            {
                EquipmentDetailsList = _list,
                EquipmentTrackingVM = getEquipmentTracking
            };

            return View(equipmentTracking);
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> CheckInEquipmentStock(EquipmentInventoryCVM equipmentInventoryVM)
        {
            EquipmentsInventoryVM _checkInEquipment = new EquipmentsInventoryVM
            {
                EventDetailsID = equipmentInventoryVM.EventDetailsID,
                EquipmentDetailsID = equipmentInventoryVM.EquipmentDetailsID,
                CheckOutEquipmentID = equipmentInventoryVM.CheckOutEquipmentID,
                Quantity = equipmentInventoryVM.Quantity,
                Remarks = equipmentInventoryVM.Remarks,
                UserID = CurrentUser.ID
            };

            var response = await mediator.Send(new CheckInEquipmentStockCommand
            {
                MyEquipmentInventoryVM = _checkInEquipment
            });

            return Json(response);
        }

        [Authorize(Roles = "InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> CheckOutEquipmentStock()
        {
            var getEquipmentDetails = await mediator.Send(new GetEquipmentStockDetailsQuery());
            var getApprovedEquipment = await mediator.Send(new GetApprovedEventsQuery());

            List<SelectListItem> _list = new List<SelectListItem>();
            List<SelectListItem> _list2 = new List<SelectListItem>();

            foreach (var item in getEquipmentDetails)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.EquipmentDetailsVM.Code + " | " + item.EquipmentDetailsVM.Name + " | " + item.EquipmentDetailsVM.Description + " | Quantity: " + item.Quantity
                });
            }

            foreach (var item in getApprovedEquipment)
            {
                _list2.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = "Event Name: " + item.EventName + " | Event Date: " + item.EventDate + " | Event Status: " + item.EventStatus
                });
            }

            _list.Add(new SelectListItem { Text = "Add New Equipment", Value = "Add New Equipment" });

            EquipmentInventoryCVM equipmentDetailsListVM = new EquipmentInventoryCVM
            {
                EquipmentStockDetailsList = _list,
                ProcessingEventsList = _list2
            };

            return View(equipmentDetailsListVM);
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> CheckOutEquipmentStock(EquipmentInventoryCVM equipmentInventoryVM)
        {
            EquipmentsInventoryVM _checkOutEquipment = new EquipmentsInventoryVM
            {
                EventDetailsID = equipmentInventoryVM.EventDetailsID,
                EquipmentDetailsID = equipmentInventoryVM.EquipmentDetailsID,
                Quantity = equipmentInventoryVM.Quantity,
                Remarks = equipmentInventoryVM.Remarks,
                UserID = CurrentUser.ID
            };

            var response = await mediator.Send(new CheckOutEquipmentStockCommand
            {
                MyEquipmentInventoryVM = _checkOutEquipment
            });

            return Json(response);
        }

        [Authorize(Roles = "Admin,  InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> AddFoodRestockRequest()
        {
            var id = await mediator.Send(new AddFoodRequestCommand { ID = CurrentUser.ID });

            return Redirect("/Inventory/RequestFoodRestock?id=" + id);
        }

        [Authorize(Roles = "Admin,  InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> RequestFoodRestock(int id)
        {
            var _requestDetails = await mediator.Send(new GetFoodRequestDetailsQuery { ID = id });
            var _foodCollection = await mediator.Send(new GetFoodRestockRequestDetailsQuery { RequestID = id });
            var _getFoodDetails = await mediator.Send(new GetFoodDetailsQuery());

            List<SelectListItem> _list = new List<SelectListItem>();

            foreach (var item in _getFoodDetails)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Code + " | " + item.Name + " | " + item.Unit
                });
            }
            _list.Add(new SelectListItem
            {
                Value = "Add New Food",
                Text = "Add New Food"
            });
            FoodRestockRequestCVM foodDetailsListVM = new FoodRestockRequestCVM
            {
                ID = _requestDetails.ID,

                FoodRequest = _requestDetails,
                FoodCollection = _foodCollection,
                FoodDetailsList = _list,
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
                Quantity = foodRestockRequestVM.Quantity,
                EstimatedPrice = foodRestockRequestVM.EstimatedPrice,
                FoodDetails = foodRestockRequestVM.FoodDetails
            };

            var response = await mediator.Send(new AddFoodRequestCollectionCommand
            {
                FoodRestockID = foodRestockRequestVM.FoodRequest.ID,
                MyFoodRestockRequestVM = _foodRequestCollection,
            });

            //Send Notif to Admin
            //await mediator.Send(new AddInventoryNotificationCommand
            //{
            //    Message = "New Food Restock Request",
            //    TargetUserID = -1,
            //    MethodName = "/Inventory/FoodRestockRequestDetails",
            //    RequestID = _foodRequestCollection.ID
            //});

            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> FoodRestockRequestDetails(int id)
        {
            var _requestDetails = await mediator.Send(new GetFoodRequestDetailsQuery { ID = id });
            var _foodCollection = await mediator.Send(new GetFoodRestockRequestDetailsQuery { RequestID = id });

            return View(new FoodRestockRequestDetailsCVM
            {
                FoodRequest = _requestDetails,
                FoodCollection = _foodCollection
            });
        }

        [Authorize(Roles = "Admin,  InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> DeleteFoodRequest(int id)
        {
            var _result = await mediator.Send(new DeleteFoodRestockRequestCommand { DeleteRequestID = id });
            return Json(_result);
        }


        [Authorize(Roles = "Admin,  InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> AddEquipmentRestockRequest()
        {
            var id = await mediator.Send(new AddEquipmentRequestCommand { ID = CurrentUser.ID });

            return Redirect("/Inventory/RequestEquipmentRestock?id=" + id);
        }

        [Authorize(Roles = "Admin,  InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> RequestEquipmentRestock(int id)
        {
            var getEquipmentDetails = await mediator.Send(new GetEquipmentDetailsQuery());
            List<SelectListItem> _list = new List<SelectListItem>();

            foreach (var item in getEquipmentDetails)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Code + " | " + item.Name + " | " + item.UnitType
                });
            }
            _list.Add(new SelectListItem
            {
                Value = "Add New Equipment",
                Text = "Add New Equipment"
            });
            var _requestDetails = await mediator.Send(new GetEquipmentRequestDetailsQuery { ID = id });
            var _equipmentRequestCollection = await mediator.Send(new GetEquipmentRestockRequestDetailsQuery { RequestID = id });

            EquipmentRestockRequestCVM equipmentDetailsListVM = new EquipmentRestockRequestCVM
            {
                EquipmentDetailsList = _list,
                EquipmentRequest = _requestDetails,
                EquipmentCollection = _equipmentRequestCollection
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
                Quantity = equipmentRestockRequestVM.Quantity,
                EstimatedPrice = equipmentRestockRequestVM.EstimatedPrice,
                EquipmentDetails = equipmentRestockRequestVM.EquipmentDetails
            };

            var response = await mediator.Send(new AddEquipmentRequestCollectionCommand
            {
                EquipmentRestockID = equipmentRestockRequestVM.EquipmentRequest.ID,
                MyEquipmentRestockRequestVM = _equipmentRequest
            });

            //Send Notif to Admin
            //await mediator.Send(new AddInventoryNotificationCommand
            //{
            //    Message = "New Equipment Restock Request",
            //    TargetUserID = -1,
            //    MethodName = "/Inventory/EquipmentRestockRequestDetails",
            //    RequestID = equipmentRestockRequestVM.EquipmentRequest.ID
            //});

            return Redirect("/Inventory/EquipmentRestockRequestDetails?id=" + equipmentRestockRequestVM.EquipmentRequest.ID);
        }

        [HttpGet]
        public async Task<IActionResult> EquipmentRestockRequestDetails(int id)
        {
            var _requestDetails = await mediator.Send(new GetEquipmentRequestDetailsQuery { ID = id });
            var _equipmentRequestCollection = await mediator.Send(new GetEquipmentRestockRequestDetailsQuery { RequestID = id });

            var _details = new EquipmentRestockRequestDetailsCVM
            {
                EquipmentRequest = _requestDetails,
                EquipmentCollection = _equipmentRequestCollection
            };

            return View(_details);
        }

        [Authorize(Roles = "Admin,  InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> DeleteEquipmentRequest(int id)
        {
            var _result = await mediator.Send(new DeleteEquipmentRestockRequestCommand { DeleteRequestID = id });
            return Json(_result);
        }



        [HttpGet]
        public async Task<IActionResult> ApproveFoodRequest(int id)
        {
            var _requestDetails = await mediator.Send(new ApproveFoodRestockRequestCommand { RequestID = id });
            await mediator.Send(new AddInventoryNotificationCommand
            {
                Message = "New Approved Food Restock Request",
                TargetUserID = _requestDetails.InventoryManager.ID,
                MethodName = "/Inventory/FoodRestockRequestDetails",
                RequestID = _requestDetails.ID
            });

            return Redirect("/Inventory/FoodRestockRequestDetails?id=" + id);
        }

        [HttpPost]
        public async Task<IActionResult> DeclineFoodRequest(int id, string remarks)
        {
            var _requestDetails = await mediator.Send(new DeclineFoodRestockRequestCommand { RequestID = id, Remarks = remarks });
            await mediator.Send(new AddInventoryNotificationCommand
            {
                Message = "New Declined Food Restock Request",
                TargetUserID = _requestDetails.InventoryManager.ID,
                MethodName = "/Inventory/FoodRestockRequestDetails",
                RequestID = _requestDetails.ID
            });

            return Json(true);
        }


        [HttpGet]
        public async Task<IActionResult> ApproveEquipmentRequest(int id)
        {
            var _requestDetails = await mediator.Send(new ApproveEquipmentRestockRequestCommand { RequestID = id });

            await mediator.Send(new AddInventoryNotificationCommand
            {
                Message = "New Approved Equipment Restock Request",
                TargetUserID = _requestDetails.InventoryManager.ID,
                MethodName = "/Inventory/EquipmentRestockRequestDetails",
                RequestID = _requestDetails.ID
            });

            return Redirect("/Inventory/EquipmentRestockRequestDetails?id=" + id);
        }

        [HttpPost]
        public async Task<IActionResult> DeclineEquipmentRequest(int id, string remarks)
        {
            var _requestDetails = await mediator.Send(new DeclineEquipmentRestockRequestCommand { RequestID = id, Remarks = remarks });

            await mediator.Send(new AddInventoryNotificationCommand
            {
                Message = "New Declined Equipment Restock Request",
                TargetUserID = _requestDetails.InventoryManager.ID,
                MethodName = "/Inventory/EquipmentRestockRequestDetails",
                RequestID = _requestDetails.ID
            });

            return Json(true);
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
        public async Task<IActionResult> ChangeRequestStatus(int id)
        {
            var response = await mediator.Send(new ChangeRequestStatusCommand
            {
                ID = id

            });

            await mediator.Send(new AddInventoryNotificationCommand
            {
                Message = "New Food Restock Request",
                TargetUserID = -1,
                MethodName = "/Inventory/FoodRestockRequestDetails",
                RequestID = id
            });

            return Redirect("/Inventory/FoodRestockRequestDetails?id=" + id);
        }


        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> ChangeEquipmentRequestStatus(int id)
        {
            var response = await mediator.Send(new Application.Inventory_Manager.Equipments.Commands.ChangeEquipmentRequestStatusCommand
            {
                ID = id
            });

            await mediator.Send(new AddInventoryNotificationCommand
            {
                Message = "New Equipment Restock Request",
                TargetUserID = -1,
                MethodName = "/Inventory/EquipmentRestockRequestDetails",
                RequestID = id
            });

            return Redirect("/Inventory/EquipmentRestockRequestDetails?id=" + id);
        }


        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> UploadReceipt(InventoryDeliveryCVM inventoriesDeliveryVM)
        {


            if (inventoriesDeliveryVM.file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    inventoriesDeliveryVM.file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);


                    InventoriesDeliveryVM _inventory = new InventoriesDeliveryVM
                    {
                        ID = inventoriesDeliveryVM.ID,
                        ReceiptImage = fileBytes,
                    };

                    var response = await mediator.Send(new UploadReceiptImageCommand
                    {
                        MyInventoriesDeliveryVM = _inventory
                    });

                    return Json(response);
                }
            }
            else
            {
                return Json(false);
            }
        }


        [Authorize(Roles = "InventoryManager,Coordinator,Admin")]
        [HttpGet]
        public async Task<IActionResult> Tracking()
        {
            var getEquipmentCheckIn = await mediator.Send(new GetEquipmentTrackingCheckInQuery());
            var getEquipmentCheckOut = await mediator.Send(new GetEquipmentTrackingCheckOutQuery());

            EquipmentTrackingCVM equipmentTracking = new EquipmentTrackingCVM
            {
                CheckInEquipmentTracking = getEquipmentCheckIn,
                CheckOutEquipmentTracking = getEquipmentCheckOut
            };

            return View(equipmentTracking);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> InventoryAdminIndex()
        {
            var _inventoryAdmin = await mediator.Send(new GetInventoryDataQuery());
            return View(_inventoryAdmin);
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> InventoryCreativesIndex()
        {
            var _inventoryCreatives = await mediator.Send(new GetInventoryDataQuery());
            return View(_inventoryCreatives);
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> InventoryKitchenIndex()
        {
            var _inventoryKitchen = await mediator.Send(new GetInventoryDataQuery());
            return View(_inventoryKitchen);
        }

        [Authorize(Roles = "Admin, InventoryManager")]
        [HttpGet]
        public async Task<IActionResult> InventoryServiceIndex()
        {
            var _inventoryService = await mediator.Send(new GetInventoryDataQuery());
            return View(_inventoryService);
        }



    }
}
