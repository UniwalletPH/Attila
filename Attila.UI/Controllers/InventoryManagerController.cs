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
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddEquipmentDetailsCommand(EquipmentDetails equipmentDetails)
        {
            try
            {
                await mediator.Send(new AddEquipmentDetailsCommand { MyEquipmentDetails = equipmentDetails });
                _checker = true;

            }
            catch (Exception)
            {
                _checker = false;
            }

            return Json(_checker);
        }

        [HttpGet]
        public IActionResult AddEquipmentInventoryCommand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEquipmentInventoryCommand(EquipmentInventory equipmentInventory)
        {
            try
            {
                await mediator.Send(new AddEquipmentInventoryCommand { MyEquipmentInventory = equipmentInventory });
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
        public async Task<IActionResult> AddEquipmentRestockCommand(EquipmentRestock equipmentRestock)
        {
            try
            {
                await mediator.Send(new AddEquipmentRestockCommand { MyEquipmentRestock = equipmentRestock});
                _checker = true;
            }
            catch (Exception)
            {
                _checker = false;
            }

            return Json(_checker);
        }


        [HttpGet]
        public IActionResult DeleteEquipmentDetailsCommand()
        {
            return View();
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
        public async Task<IActionResult> RequestEquipmentRestockCommand(int reqEquipmentID, EquipmentRestockRequest equipmentRestockRequest)
        {
            try
            {
                await mediator.Send(new RequestEquipmentRestockCommand { RequestEquipmentID = reqEquipmentID, MyEquipmentRestockRequest = equipmentRestockRequest });
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
                await mediator.Send(new UpdateEquipmentDetailsCommand { MyEquipmentDetails = equipmentDetails });
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
        public async Task<IActionResult> UpdateEquipmentStockCommand(int equipmentID, int equipmentQuantity)
        {
            try
            {
                await mediator.Send(new UpdateEquipmentStockCommand { SearchedID = equipmentID, NewEquipmentQuantity = equipmentQuantity });
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
                return View(_getEquipmentStock.ToList());
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
                var _searchEquipmentById = await mediator.Send(new SearchEquipmentByIdQuery {SearchedID = searchedID });
                return View(_searchEquipmentById);
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

        [HttpPost]
        public async Task<IActionResult> SearchEquipmentByKeywordQuery(string searchKeyword)
        {
            try
            {
                var _searchEquipmentByKeyword = await mediator.Send(new SearchEquipmentByKeywordQuery { SearchedKeyword = searchKeyword });
                return View(_searchEquipmentByKeyword.ToList());
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
        public async Task<IActionResult> AddFoodDetailsCommand(FoodDetails foodDetails)
        {
            try
            {
                await mediator.Send(new AddFoodDetailsCommand { MyFoodDetails = foodDetails });
                _checker = true;
            }
            catch (Exception)
            {
                _checker = false;
            }
            return Json(_checker);
        }


        [HttpGet]
        public IActionResult AddFoodInventoryCommand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFoodInventoryCommand(FoodInventory foodInventory)
        {
            try
            {
                await mediator.Send(new AddFoodInventoryCommand { MyFoodInventory = foodInventory });
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
        public async Task<IActionResult> AddFoodRestockCommand(FoodRestock foodRestock)
        {
            try
            {
                await mediator.Send(new AddFoodRestockCommand { MyFoodRestock = foodRestock });
                _checker = true;
            }
            catch (Exception)
            {
                _checker = false;
            }
            return Json(_checker);
        }


        [HttpGet]
        public IActionResult DeleteFoodDetailsCommand()
        {
            return View();
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
        public async Task<IActionResult> RequestFoodRestockCommand(int reqFoodID, FoodRestockRequest foodRestockRequest)
        {
            try
            {
                await mediator.Send(new RequestFoodRestockCommand { RequestFoodID = reqFoodID, MyFoodRestockRequest = foodRestockRequest });
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
                await mediator.Send(new UpdateFoodDetailsCommand { MyFoodDetails = foodDetails });
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
        public async Task<IActionResult> UpdateFoodStockCommand(int foodID, int foodQuantity)
        {
            try
            {
                await mediator.Send(new UpdateFoodStockCommand { SearchedID = foodID, NewFoodQuantity = foodQuantity });
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
                var _searchFoodById = await mediator.Send(new SearchFoodByIdQuery { SearchedID = searchedID });
                return View(_searchFoodById);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult SearchFoodByIdKeyword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchFoodByIdKeyword(string searchedKeyword)
        {
            try
            {
                var _searchFoodByKeyword = await mediator.Send(new SearchFoodByKeywordQuery { SearchedKeyword = searchedKeyword });
                return View(_searchFoodByKeyword);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}