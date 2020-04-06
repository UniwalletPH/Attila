using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Attila.Application.Inventory_Manager.Equipments.Commands;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using Attila.Application.Inventory_Manager.Foods.Commands;
using Attila.Application.Inventory_Manager.Foods.Queries;
using Attila.Application.Inventory_Manager.Shared.Commands;
using Attila.Application.Inventory_Manager.Shared.Queries;
using Attila.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Attila.UI.Controllers
{

    [Authorize(Roles = "Admin")]
    public class InventoryManagerController : BaseController
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
        public IActionResult AddEquipmentDetails()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEquipmentDetails(EquipmentsDetailsVM equipmentDetails)
        {
            try
            {
                await mediator.Send(new AddEquipmentDetailsCommand
                {
                    MyEquipmentsDetailsVM = equipmentDetails
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


            EquipmentInventoryCVM equipmentDetailsListVM = new EquipmentInventoryCVM
            {
                EquipmentDetailsList = _list,
                EquipmentDeliveryList = _list2
            };

            return View(equipmentDetailsListVM);
        }


        [HttpPost]
        public async Task<IActionResult> AddEquipmentInventory(EquipmentsInventoryVM equipmentInventory)
        {
            try
            {
                await mediator.Send(new AddEquipmentInventoryCommand
                {
                    MyEquipmentsInventoryVM = equipmentInventory
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
        public async Task<IActionResult> DeleteEquipmentDetails()
        {
            try
            {
                var _getEquipmentDetails = await mediator.Send(new GetEquipmentDetailsQuery());

                EquipmentDetailsCVM equipmentDetailsVM = new EquipmentDetailsCVM
                {
                    EquipmentDetailsVMs = _getEquipmentDetails
                };

                return View(equipmentDetailsVM);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteEquipmentDetails(EquipmentDetailsCVM deleteID)
        {
            try
            {
                await mediator.Send(new DeleteEquipmentDetailsCommand { DeleteSearchedID = deleteID.ID });
                _checker = true;
            }
            catch (Exception)
            {
                _checker = false;
            }

            return Json(_checker);
        }


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


        [HttpPost]
        public async Task<IActionResult> RequestEquipmentRestock(EquipmentsRestockRequestVM equipmentRestockRequest)
        {
            try
            {
                await mediator.Send(new RequestEquipmentRestockCommand
                {
                    MyEquipmentRestockRequestVM = equipmentRestockRequest
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
        public async Task<IActionResult> UpdateEquipmentDetails()
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


            EquipmentDetailsCVM equipmentDetailsListVM = new EquipmentDetailsCVM
            {
                EquipmentDetailsList = _list
            };

            return View(equipmentDetailsListVM);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateEquipmentDetails(EquipmentsDetailsVM equipmentDetails)
        {
            try
            {
                await mediator.Send(new UpdateEquipmentDetailsCommand
                {
                    MyEquipmentDetails = equipmentDetails

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
                EquipmentDetailsList = _list
            };

            return View(equipmentDetailsListVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEquipmentStock(EquipmentsInventoryVM equipmentInventory)
        {
            try
            {
                await mediator.Send(new UpdateEquipmentStockCommand
                {
                    MyEquipmentInventoryVM = equipmentInventory
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
        public async Task<IActionResult> GetEquipmentDetails()
        {
            try
            {
                var _getEquipmentDetails = await mediator.Send(new GetEquipmentDetailsQuery());

                Models.EquipmentDetailsCVM equipmentDetailsVM = new Models.EquipmentDetailsCVM
                {
                    EquipmentDetailsVMs = _getEquipmentDetails
                };


                return View(equipmentDetailsVM);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetEquipmentStock()
        {
            try
            {
                var _getEquipmentStock = await mediator.Send(new GetEquipmentStockQuery());

                EquipmentInventoryCVM equipmentInventoryVM = new EquipmentInventoryCVM 
                {
                    EquipmentsInventoryVMs = _getEquipmentStock
                };

                return View(equipmentInventoryVM);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEquipmentDelivery()
        {
            try
            {
                var _getEquipmentDelivery = await mediator.Send(new GetEquipmentDeliveryQuery());

                DeliveryDetailsCVM deliveryDetailsVM = new DeliveryDetailsCVM
                {
                    InventoryDeliveryVM = _getEquipmentDelivery
                };


                return View(deliveryDetailsVM);
            }
            catch (Exception)
            {
                throw;
            }
        }



        [Authorize(Roles = "InventoryManager")]

        [HttpGet]
        public IActionResult SearchEquipmentById()
        {
            return View();
        }

        [Authorize(Roles = "InventoryManager")]
        [HttpPost]
        public async Task<IActionResult> SearchEquipmentById(EquipmentsDetailsVM equipmentsDetailsVM)
        {
            try
            {
                var _equipmentDetails = await mediator.Send(new SearchEquipmentByIdQuery { SearchedID = equipmentsDetailsVM.ID });
                return Json(_equipmentDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult SearchEquipmentByKeyword()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> SearchEquipmentByKeywordResult(EquipmentsDetailsVM equipmentDetailsVM)
        {
            try
            {
                var _searchEquipmentByKeyword = await mediator.Send(new SearchEquipmentByKeywordQuery { SearchedKeyword = equipmentDetailsVM.SearchedKeyword });

                EquipmentDetailsCVM equipmentDetails = new EquipmentDetailsCVM
                {
                    EquipmentDetailsVMs = _searchEquipmentByKeyword
                };

                return View(equipmentDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult AddFoodDetails()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFoodDetails(FoodDetailsVM foodDetails)
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

        [HttpPost]
        public async Task<IActionResult> AddFoodInventory(FoodInventoryVM foodInventory)
        {
            try
            {
                await mediator.Send(new AddFoodInventoryCommand
                {
                    MyFoodInventoryVM = foodInventory
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
        public IActionResult DeleteFoodDetails()
        {
            try
            {
                //var _getFoodDetails = await mediator.Send(new GetFoodDetailsQuery());

                //FoodDetailsCVM foodDetailsVM = new FoodDetailsCVM
                //{
                //    FoodDetailsVMs = _getFoodDetails
                //};

                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFoodDetails(FoodDetailsVM deleteID)
        {
            try
            {
                await mediator.Send(new DeleteFoodDetailsCommand { DeleteSearchedID = deleteID.ID });
                _checker = true;
            }
            catch (Exception)
            {
                _checker = false;
            }
            return Json(_checker);
        }


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


        [HttpPost]
        public async Task<IActionResult> RequestFoodRestock(FoodsRestockRequestVM foodRestockRequest)
        {
            try
            {
                await mediator.Send(new RequestFoodRestockCommand
                {
                    MyFoodRestockRequestVM = foodRestockRequest
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
        public IActionResult UpdateFoodDetails()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFoodDetails(FoodDetailsVM foodDetails)
        {
            try
            {
                await mediator.Send(new UpdateFoodDetailsCommand
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


        [HttpGet]
        public IActionResult UpdateFoodStock()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFoodStock(FoodInventoryVM foodInventory)
        {
            try
            {
                await mediator.Send(new UpdateFoodStockCommand
                {
                    MyFoodInventoryVM = foodInventory
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
        public IActionResult GetFoodDetails()
        {
            try
            {
                //var _getFoodDetails = await mediator.Send(new GetFoodDetailsQuery());

                //FoodDetailsCVM foodDetailsVM = new FoodDetailsCVM
                //{
                //    FoodDetailsVMs = _getFoodDetails
                //};


                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetFoodStock()
        {
            try
            {
                var _getFoodStock = await mediator.Send(new GetFoodStockQuery());

                FoodInventoryCVM foodInventoryVM = new FoodInventoryCVM
                {
                    FoodsInventoryVMs = _getFoodStock
                };


                return View(foodInventoryVM);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetFoodDelivery()
        {
            try
            {
                var _getFoodDelivery = await mediator.Send(new GetFoodDeliveryQuery());

                DeliveryDetailsCVM deliveryDetailsVM = new DeliveryDetailsCVM
                {
                    InventoryDeliveryVM = _getFoodDelivery
                };

                return View(deliveryDetailsVM);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult SearchFoodById()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchFoodById(FoodInventoryVM foodsInventoryVM)
        {
            try
            {
                var _foodDetails = await mediator.Send(new SearchFoodByIdQuery { SearchedID = foodsInventoryVM.ID});
                return Json(_foodDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult SearchFoodByKeyword()
        {
            return View();
        }


        [HttpGet]
        public IActionResult SearchFoodByKeywordResult(FoodDetailsVM foodsDetailsVM)
        {
            try
            {
                //var _searchFoodByKeyword = await mediator.Send(new SearchFoodByKeywordQuery { SearchedKeyword = foodsDetailsVM.SearchedKeyword });

                //FoodDetailsCVM foodDetails = new FoodDetailsCVM
                //{
                //    FoodDetailsVMs = _searchFoodByKeyword
                //};

                return View();

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult GetInventoryDetails()
        {
            try
            {
                //var _getInventoryDetails = await mediator.Send(new GetInventoryDetailsQuery());

                //InventoryDetailsVM inventoryDetailsVM = new InventoryDetailsVM
                //{
                //    EquipmentsDetailsVM = _getInventoryDetails.EquipmentsDetailsVM,
                //    FoodsDetailsVM = _getInventoryDetails.FoodsDetailsVM
                //};


                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult AddInventoryDelivery()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddInventoryDelivery(InventoriesDeliveryVM inventoriesDeliveryVM)
        {
            try
            {
                await mediator.Send(new AddInventoryDeliveryCommand
                {
                    MyInventoriesDeliveryVM = inventoriesDeliveryVM
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
        public async Task<IActionResult> GetSupplierDetails()
        {
            try
            {
                var _getSupplierDetails = await mediator.Send(new GetSupplierDetailsQuery());

                SupplierDetailsCVM supplierDetailsVM = new SupplierDetailsCVM
                {
                    SupplierDetailsVMs = _getSupplierDetails
                };


                return View(supplierDetailsVM);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}