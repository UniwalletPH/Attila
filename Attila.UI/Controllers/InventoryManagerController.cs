using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atilla.Application.Food.Commands;
using Attila.Application.Food.Commands;
using Attila.Application.Food.Queries;
using Attila.Application.Inventory_Manager.Equipment.Commands;
using Attila.Application.Inventory_Manager.Equipment.Queries;
using Attila.Application.Inventory_Manager.Food.Commands;
using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using Attila.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EquipmentDetailsVM = Attila.UI.Models.EquipmentDetailsVM;
using EquipmentInventoryVM = Attila.UI.Models.EquipmentInventoryVM;

namespace Attila.UI.Controllers
{
    public class InventoryManagerController : Controller
    {
        public static bool _checker;
        private readonly IMediator mediator;
        public InventoryManagerController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddEquipmentDetailsCommand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEquipmentDetailsCommand(EquipmentDetailsVM equipmentDetails)
        {
            try
            {
                await mediator.Send(new AddEquipmentDetailsCommand
                {
                    Code = equipmentDetails.Code,
                    Name = equipmentDetails.Name,
                    Description = equipmentDetails.Description,
                    UnitType = equipmentDetails.UnitType,
                    EquipmentType = equipmentDetails.EquipmentType
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
        public async Task<IActionResult> AddEquipmentInventoryCommand()
        {
            var getEquipmentDetails = await mediator.Send(new GetEquipmentDetailsQuery());
            List<SelectListItem> _list = new List<SelectListItem>();

            foreach (var item in getEquipmentDetails)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Code + "|" + item.Name + "|" + item.Description
                });
            }


            var getEquipmentRestock = await mediator.Send(new GetEquipmentStockQuery());
            List<SelectListItem> _list2 = new List<SelectListItem>();

            foreach (var item in getEquipmentRestock)
            {
                _list2.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = "Equipment ID: " + item.EquipmentDetailsID + " | Encoding Date: " + item.EncodingDate.Date
                });
            }




            EquipmentInventoryVM equipmentDetailsListVM = new EquipmentInventoryVM
            {
                EquipmentDetailsList = _list,
                EquipmentDeliveryList = _list2
            };

            return View(equipmentDetailsListVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddEquipmentInventoryCommand(Models.EquipmentInventoryVM equipmentInventory)
        {
            try
            {
                await mediator.Send(new AddEquipmentInventoryCommand
                {
                    Quantity = equipmentInventory.Quantity,
                    EncodingDate = DateTime.Now,
                    ItemPrice = equipmentInventory.ItemPrice,
                    Remarks = equipmentInventory.Remarks,
                    UserID = equipmentInventory.UserID,
                    EquipmentDetailsID = equipmentInventory.EquipmentDetailsID,
                    EquipmentDeliveryID = equipmentInventory.EquipmentDeliveryID
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
        public IActionResult AddEquipmentRestockCommand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEquipmentRestockCommand(EquipmentRestockVM equipmentRestock)
        {
            try
            {
                await mediator.Send(new AddEquipmentRestockCommand
                {
                    DeliveryDate = equipmentRestock.DeliveryDate,
                    ReceiptImage = equipmentRestock.ReceiptImage,
                    DeliveryPrice = equipmentRestock.DeliveryPrice,
                    Remarks = equipmentRestock.Remarks
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
        public async Task<IActionResult> DeleteEquipmentDetailsCommand()
        {
            try
            {
                var _getEquipmentDetails = await mediator.Send(new GetEquipmentDetailsQuery());
                return View(_getEquipmentDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEquipmentDetailsCommand(int deleteID)
        {
            try
            {
                await mediator.Send(new DeleteEquipmentDetailsCommand { DeleteSearchedID = deleteID });
                _checker = true;
            }
            catch (Exception)
            {
                _checker = false;
            }

            return Json(_checker);
        }


        [HttpGet]
        public IActionResult RequestEquipmentRestockCommand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RequestEquipmentRestockCommand(EquipmentRestockRequestVM equipmentRestockRequest)
        {
            try
            {
                await mediator.Send(new RequestEquipmentRestockCommand
                {
                    Quantity = equipmentRestockRequest.Quantity,
                    DateTimeRequest = DateTime.Now,
                    EquipmentDetailsID = equipmentRestockRequest.EquipmentDetailsID,
                    Status = equipmentRestockRequest.Status,
                    UserID = equipmentRestockRequest.UserID
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
        public IActionResult UpdateEquipmentDetailsCommand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEquipmentDetailsCommand(EquipmentDetails equipmentDetails)
        {
            try
            {
                await mediator.Send(new UpdateEquipmentDetailsCommand
                {
                    ID = equipmentDetails.ID,
                    Code = equipmentDetails.Code,
                    Name = equipmentDetails.Name,
                    Description = equipmentDetails.Description,
                    UnitType = equipmentDetails.UnitType,
                    EquipmentType = equipmentDetails.EquipmentType

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
        public IActionResult UpdateEquipmentStockCommand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEquipmentStockCommand(EquipmentInventory equipmentInventory)
        {
            try
            {
                await mediator.Send(new UpdateEquipmentStockCommand
                {
                    ID = equipmentInventory.ID,
                    Quantity = equipmentInventory.Quantity
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
        public async Task<IActionResult> GetEquipmentDetailsQuery()
        {
            try
            {
                var _getEquipmentDetails = await mediator.Send(new GetEquipmentDetailsQuery());
                return View(_getEquipmentDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetEquipmentStockQuery()
        {
            try
            {
                var _getEquipmentStock = await mediator.Send(new GetEquipmentStockQuery());
                return View(_getEquipmentStock);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult SearchEquipmentByIdQuery()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchEquipmentByIdQuery(int searchedID)
        {
            try
            {
                var _equipmentDetails = await mediator.Send(new SearchEquipmentByIdQuery { SearchedID = searchedID });
                return Json(_equipmentDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult SearchEquipmentByKeywordQuery()
        {
            return View();
        }

        public async Task<IActionResult> SearchEquipmentByKeywordResult(string searchKeyword)
        {
            //searchKeyword = "a";

            try
            {
                var _searchEquipmentByKeyword = await mediator.Send(new SearchEquipmentByKeywordQuery { SearchedKeyword = searchKeyword });

                return View(_searchEquipmentByKeyword);

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult AddFoodDetailsCommand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFoodDetailsCommand(FoodDetailsVM foodDetails)
        {
            try
            {
                await mediator.Send(new AddFoodDetailsCommand
                {
                    Code = foodDetails.Code,
                    Name = foodDetails.Name,
                    Specification = foodDetails.Specification,
                    Description = foodDetails.Description,
                    Unit = foodDetails.Unit,
                    FoodType = foodDetails.FoodType
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
        public async Task<IActionResult> AddFoodInventoryCommand()
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


            var getFoodRestock = await mediator.Send(new GetFoodStockQuery());
            List<SelectListItem> _list2 = new List<SelectListItem>();

            foreach (var item in getFoodRestock)
            {
                _list2.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = "Food ID: " + item.FoodDetailsID + " | Encoding Date: " + item.EncodingDate.Date
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
        public async Task<IActionResult> AddFoodInventoryCommand(FoodInventoryVM foodInventory)
        {
            try
            {
                await mediator.Send(new AddFoodInventoryCommand
                {
                    Quantity = foodInventory.Quantity,
                    ExpirationDate = foodInventory.ExpirationDate,
                    EncodingDate = DateTime.Now,
                    ItemPrice = foodInventory.ItemPrice,
                    Remarks = foodInventory.Remarks,
                    UserID = foodInventory.UserID,
                    FoodDetailsID = foodInventory.FoodDetailsID,
                    FoodRestockID = foodInventory.FoodRestockID
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
        public IActionResult AddFoodRestockCommand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFoodRestockCommand(FoodRestockVM foodRestock)
        {
            try
            {
                await mediator.Send(new AddFoodRestockCommand
                {
                    DeliveryDate = foodRestock.DeliveryDate,
                    ReceiptImage = foodRestock.ReceiptImage,
                    DeliveryPrice = foodRestock.DeliveryPrice,
                    Remarks = foodRestock.Remarks
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
        public async Task<IActionResult> DeleteFoodDetailsCommand()
        {
            try
            {
                var _getFoodDetails = await mediator.Send(new GetFoodDetailsQuery());
                return View(_getFoodDetails.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFoodDetailsCommand(int deleteID)
        {
            try
            {
                await mediator.Send(new DeleteFoodDetailsCommand { DeleteSearchedID = deleteID });
                _checker = true;
            }
            catch (Exception)
            {
                _checker = false;
            }
            return Json(_checker);
        }


        [HttpGet]
        public IActionResult RequestFoodRestockCommand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RequestFoodRestockCommand(FoodRestockRequestVM foodRestockRequest)
        {
            try
            {
                await mediator.Send(new RequestFoodRestockCommand
                {
                    Quantity = foodRestockRequest.Quantity,
                    DateTimeRequest = DateTime.Now,
                    FoodDetailsID = foodRestockRequest.FoodDetailsID,
                    Status = foodRestockRequest.Status,
                    UserID = foodRestockRequest.UserID
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
        public IActionResult UpdateFoodDetailsCommand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFoodDetailsCommand(FoodDetails foodDetails)
        {
            try
            {
                await mediator.Send(new UpdateFoodDetailsCommand
                {
                    ID = foodDetails.ID,
                    Code = foodDetails.Code,
                    Name = foodDetails.Name,
                    Specification = foodDetails.Specification,
                    Description = foodDetails.Description,
                    Unit = foodDetails.Unit,
                    FoodType = foodDetails.FoodType
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
        public IActionResult UpdateFoodStockCommand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFoodStockCommand(FoodInventory foodInventory)
        {
            try
            {
                await mediator.Send(new UpdateFoodStockCommand
                {
                    ID = foodInventory.ID,
                    Quantity = foodInventory.Quantity
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
        public async Task<IActionResult> GetFoodDetailsQuery()
        {
            try
            {
                var _getFoodDetails = await mediator.Send(new GetFoodDetailsQuery());
                return View(_getFoodDetails.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetFoodStockQuery()
        {
            try
            {
                var _getFoodStock = await mediator.Send(new GetFoodStockQuery());
                return View(_getFoodStock.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult SearchFoodByIdQuery()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchFoodByIdQuery(int searchedID)
        {
            try
            {
                var _foodDetails = await mediator.Send(new SearchFoodByIdQuery { SearchedID = searchedID });
                return Json(_foodDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult SearchFoodByKeywordQuery()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> SearchFoodByKeywordResult(string searchKeyword)
        {
            searchKeyword = "a";
            try
            {
                var _searchFoodByKeyword = await mediator.Send(new SearchFoodByKeywordQuery { SearchedKeyword = searchKeyword });
                return View(_searchFoodByKeyword);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}