using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Attila.UI.Models;
using MediatR;
using Attila.Application.Food.Queries;
using Attila.Application.Inventory_Manager.Food.Queries;
using Attila.Application.Food.Commands;
using Microsoft.AspNetCore.Mvc.Rendering;
using Attila.Application.Inventory_Manager.Shared.Queries;
using Microsoft.AspNetCore.Http;
using Attila.Application.Inventory_Manager.Equipment.Commands;
using Attila.Application.Inventory_Manager.Equipment.Queries;
using Attila.Application.Inventory_Manager.Food.Commands;
using Attila.Application.Inventory_Manager.Shared.Commands;

namespace Attila.UI.Controllers
{
    public class InventoryController : Controller
    {
        public static bool _checker;

        private readonly IMediator mediator;

        public InventoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identities != null)
            {
                try
                {
                    var getDetails = await mediator.Send(new GetInventoryQuery());

                    return View(getDetails);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return Redirect("/Login");
            }
        }


        public IActionResult AddFood()
        {
            return View();
        }
        public IActionResult AddEquipment()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddFoodDetails(FoodsDetailsVM foodDetails)
        {
            if (User.Identities != null)
            {
                try
                {
                    await mediator.Send(new AddFoodDetailsCommand
                    {
                        MyFoodDetailsVM = foodDetails
                    });
                    _checker = true;
                }
                catch (Exception)
                {
                    _checker = false;
                }

                return Json(_checker);
            }
            else
            {
                return Redirect("/Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEquipmentDetails(EquipmentsDetailsVM equipDetails)
        {
            if (User.Identities != null)
            {
                try
                {
                    await mediator.Send(new AddEquipmentDetailsCommand
                    {
                        MyEquipmentsDetailsVM = equipDetails
                    });
                    _checker = true;
                }
                catch (Exception)
                {
                    _checker = false;
                }

                return Json(_checker);
            }
            else
            {
                return Redirect("/Login");
            }
        }


        [HttpGet]
        public IActionResult AddInventoryDelivery()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Suppliers()
        {

            var _suppliers = await mediator.Send(new GetSupplierDetailsQuery());


            return View(_suppliers);
        }
        [HttpPost]
        public async Task<IActionResult> AddInventoryDelivery(InventoriesDeliveryVM inventoriesDeliveryVM)
        {

            var _inventory = new InventoriesDeliveryVM
            {
                DeliveryDate = inventoriesDeliveryVM.DeliveryDate,
                DeliveryPrice = inventoriesDeliveryVM.DeliveryPrice,
                SupplierDetailsID = inventoriesDeliveryVM.SupplierDetailsID,
                ReceiptImage = inventoriesDeliveryVM.ReceiptImage,
                Remarks = inventoriesDeliveryVM.Remarks,
            };
            try
            {
                await mediator.Send(new AddInventoryDeliveryCommand
                {
                    MyInventoriesDeliveryVM = _inventory
                });
                _checker = true;
            }
            catch (Exception)
            {
                _checker = false;
            }

            return Json(_checker);
        }


        [HttpGet]
        public IActionResult AddSupplierDetails()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplierDetails(SuppliersDetailsVM suppliersDetails)
        {
            try
            {
                await mediator.Send(new AddSupplierDetailsCommand
                {
                    MySuppliersDetailsVM = suppliersDetails
                });
                _checker = true;
            }
            catch (Exception)
            {
                _checker = false;
            }
            return Json(_checker);
        }


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


            EquipmentInventoryVM equipmentDetailsListVM = new EquipmentInventoryVM
            {
                EquipmentDetailsList = _list,
                EquipmentDeliveryList = _list2
            };

            return View(equipmentDetailsListVM);
        }

        [HttpGet]
        public async Task<IActionResult> RequestFoodRestock()
        {
            if (User.Identities != null)
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

                FoodRestockRequestVM foodDetailsListVM = new FoodRestockRequestVM
                {
                    FoodDetailsList = _list
                };

                return View(foodDetailsListVM);
            }
            else
            {
                return Redirect("/Login");
            }
        }

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


            FoodInventoryVM FoodDetailsListVM = new FoodInventoryVM
            {
                FoodDetailsList = _list,
                FoodDeliveryList = _list2
            };

            return View(FoodDetailsListVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddFoodInventory(FoodsInventoryVM foodInventory)
        {

            var foodDetails = new FoodsInventoryVM
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

            try
            {
                await mediator.Send(new AddFoodInventoryCommand
                {
                    MyFoodInventoryVM = foodDetails
                });
                _checker = true;
            }
            catch (Exception)
            {
                _checker = false;
            }

            return Json(_checker);
        }

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
            try
            {


                await mediator.Send(new AddEquipmentInventoryCommand
                {
                    MyEquipmentsInventoryVM = equipments
                });
                _checker = true;
            }
            catch (Exception)
            {
                _checker = false;
            }

            return Json(_checker);
        }

        [HttpPost]
        public async Task<IActionResult> RequestFoodRestock(FoodsRestockRequestVM foodRestockRequest)
        {
            if (User.Identities != null)
            {
                FoodsRestockRequestVM _foodRequestDetails = new FoodsRestockRequestVM
                {
                    FoodDetailsID = foodRestockRequest.FoodDetailsID,
                    DateTimeRequest = DateTime.Now,


                    Quantity = foodRestockRequest.Quantity,
                    Status = Domain.Enums.Status.Pending,
                    UserID = 1
                };

                try
                {
                    var val = await mediator.Send(new RequestFoodRestockCommand
                    {
                        MyFoodRestockRequestVM = _foodRequestDetails
                    });
                    _checker = val;
                }
                catch (Exception)
                {
                    _checker = false;
                }

                return Json(_checker);
            }
            else
            {
                return Redirect("/Login");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
