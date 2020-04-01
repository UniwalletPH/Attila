using Attila.Application.Coordinator.Events.Commands;
using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Events.Commands;
using Attila.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Attila.UI.Controllers
{
    public class EventPackagesController : BaseController
    {
        private readonly IMediator mediator;

        public EventPackagesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var eventPackages = await mediator.Send(new GetEventPackageListQuery { });

            var menulist = await mediator.Send(new GetMenuListQuery());


            List<SelectListItem> list = new List<SelectListItem>();
            List<SelectListItem> _list = new List<SelectListItem>();

            foreach (var item in menulist)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Name  + item.MenuCategory.Category
                });


            }

            foreach (var item in eventPackages)
            {
                list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Name + item.RatePerHead
                });

            }


            var packages = new PackagesCVM
            {
                MenuList = _list,
                EventPackages = eventPackages,
                PackageList = list
            };

            return View(packages);
        }




      

        [HttpGet]
        public async Task<IActionResult> AddEventPackages()
        {


            if (User.Identities != null)
            {

                var _getPackageList = await mediator.Send(new GetEventPackageListQuery());

                return View(_getPackageList);
            }
            else
            {
                return Redirect("/Login");
            }

        }

        public IActionResult PackageForm()
        {
            return View();
        }


        
        [HttpGet]
        public async Task<IActionResult> MenuForm()
        {


            if (User.Identities != null)
            {

                var _menuCategoryNames = await mediator.Send(new GetMenuCategoryListQuery());

                List<SelectListItem> _list = new List<SelectListItem>();

                foreach (var item in _menuCategoryNames)
                {
                    _list.Add(new SelectListItem
                    {
                        Value = item.ID.ToString(),
                        Text = item.Category
                    });

                }
                var _addEventList = new AddMenuCVM();
                _addEventList.CategoryList = _list;
                return View(_addEventList);


            }
            else
            {
                return Redirect("/Login");
            }

        }
        [HttpGet]
        public IActionResult MenuCategoryForm()
        {

 
                return View();

 

        }
        [HttpGet]
        public async Task<IActionResult> MenuList()
        {

            if (User.Identities != null)
            {

                var _menu = await mediator.Send(new GetMenuListQuery());
                var _menuCategoryNames = await mediator.Send(new GetMenuCategoryListQuery());

                List<SelectListItem> _list = new List<SelectListItem>();

                foreach (var item in _menuCategoryNames)
                {
                    _list.Add(new SelectListItem
                    {
                        Value = item.ID.ToString(),
                        Text = item.Category
                    });

                }

                AddMenuCVM add = new AddMenuCVM
                {
                    MenuList = _menu,
                    CategoryList = _list

                };
                return View(add);
            }
            else
            {
                return Redirect("/Login");
            }



        }





        [HttpGet]
        public async Task<IActionResult> PackageMenuForm()
        {
            if (User.Identities != null)
            {
                var eventPackages = await mediator.Send(new GetEventPackageListQuery());
                var menuList = await mediator.Send(new GetMenuListQuery());

                List<SelectListItem> _packageslist = new List<SelectListItem>();

                List<SelectListItem> _menulist = new List<SelectListItem>();
                foreach (var item in eventPackages)
                {
                    _packageslist.Add(new SelectListItem
                    {
                        Value = item.ID.ToString(),
                        Text = item.Name + item.RatePerHead,
                    });
                }

                foreach (var item in menuList)
                {
                    _menulist.Add(new SelectListItem
                    {
                        Value = item.ID.ToString(),
                        Text = item.Name,
                    });
                }

                var _packageList = new  AddPackageMenuCVM();
                _packageList.PackageList = _packageslist;
                _packageList.MenuList = _menulist;
                return View(_packageList);
            }
            else
            {
                return Redirect("/Login");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddPackageMenu(AddPackageMenuCVM _packageMenu)
        {
            bool flag = true;
            PackageMenuVM _container = new PackageMenuVM
            {
                MenuID = _packageMenu.SelectedMenu,
                PackageDetailsID = _packageMenu.SelectedPackage
            };

            try
            {
                await mediator.Send(new AddPackageMenuCommand {

                    PackageMenu =_container

                });
            }
            catch (Exception)
            {
                flag = false;
            }

            return Json(flag);
        }


        [HttpPost]
        public async Task<IActionResult> AddEventPackage(EventPackageVM _eventPackage)
        {
            //int _duration = _eventPackage.Duration.Hours;
            //string _parsedDurationString = _duration.ToString("hh':'mm");
            //TimeSpan _fromStringToTimeSpan = TimeSpan.Parse(_parsedDurationString);
            bool flag = true;
            EventPackageVM eventPackageVM = new EventPackageVM
            {
                Code = _eventPackage.Code,
                Description = _eventPackage.Description,
                //Duration = _fromStringToTimeSpan,
                Name = _eventPackage.Name,
                RatePerHead = _eventPackage.RatePerHead

            };
            
            try
            {
                await mediator.Send(new AddEventPackageCommand
                {
                    PackageDetails = eventPackageVM
                });

            }
            catch (Exception)
            {
                flag = false;
            }
            return Json(flag);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int PackageID){

            var package = await mediator.Send(new SearchPackageByIdQuery { PackageId = PackageID });
            var eventPackages = await mediator.Send(new GetEventPackageListQuery { });

            var menulist = await mediator.Send(new GetMenuListQuery());


            List<SelectListItem> list = new List<SelectListItem>();
            List<SelectListItem> _list = new List<SelectListItem>();

            foreach (var item in menulist)
            {
                _list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Name + item.MenuCategory.Category
                });


            }

            foreach (var item in eventPackages)
            {
                list.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Name + item.RatePerHead
                });

            }
 


            var packages = new PackagesCVM
            {

                MenuList = _list,
                EventPackages = eventPackages,
                PackageList = list,
              PackageMenu = package
           };
            return View(packages);


        }
         

[HttpPost]
        public async Task<IActionResult> AddMenu(AddMenuCVM _menuDetails)
        {  
            MenuVM menuDetails = new MenuVM
            {

                Name = _menuDetails.Menu.Name,
                Description = _menuDetails.Menu.Description,
                MenuCategoryID = _menuDetails.Selected

            };
            var response = await mediator.Send(new AddMenuCommand
                {
                    PackageMenu = menuDetails
                });

          
            return Json(response);
        }




        [HttpPost]
        public async Task<IActionResult> AddMenuCategory(AddMenuCategoryCVM _menu)
        {

            var menu = new MenuCategoryVM { 
            
            Category = _menu.Category

            
            
            };
           
             var response = await mediator.Send(new AddMenuCategoryCommand
                {
                    MenuCategory = menu
                });
 
           
            return Json(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
