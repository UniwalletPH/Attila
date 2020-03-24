using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attila.UI.Models;
using MediatR;
using Attila.Application.Admin.Event.Queries;
using Attila.Application.Event.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Event.Commands;
using Attila.Application.Coordinator.Event.Commands;

namespace Attila.UI.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IMediator mediator;

        public PackagesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var eventPackages = await mediator.Send(new GetEventPackageListQuery { }); 

           

            return View(eventPackages);
        }

         


        [HttpPost]
        public async Task<IActionResult> Details(int PackageID)
        {
            var eventPackages = await mediator.Send(new GetEventPackageListQuery());

            List<SelectListItem> _list = new List<SelectListItem>();




            return View(eventPackages);
        }
        
        [HttpGet]
        public async Task<IActionResult> AddEventPackages()
        {


            if (User.Identities!=null)
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
            if (User.Identities!=null)
            {

                return PartialView("~/Views/Packages/Partials/PackageForm.cshtml");
            }
            else
            {
                return Redirect("/Login");
            }
         
        }
        [HttpGet]
        public async Task<IActionResult> MenuCategoryForm()
        {
            

            if (User.Identities!=null)
            {

                var eventPackages = await mediator.Send(new GetEventPackageListQuery());

                List<SelectListItem> _list = new List<SelectListItem>();



                foreach (var item in eventPackages)
                {
                    _list.Add(new SelectListItem
                    {
                        Value = item.ID.ToString(),
                        Text = item.Name + item.RatePerHead,
                    });
                }

                var _packageList = new AddMenuCategoryVM();
                _packageList.PackageList = _list;
                return View(_packageList);

            }
            else
            {
                return Redirect("/Login");
            }

        }


        [HttpGet]
            public async Task<IActionResult> MenuForm()
                {


            if (User.Identities!=null)
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
                var _addEventList = new AddMenuVM();
                _addEventList.CategoryList = _list;
                return PartialView("~/Views/Packages/Partials/MenuForm.cshtml",_addEventList);

                 
            }
            else
            {
                return Redirect("/Login");
            }
            
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

                AddMenuVM add = new AddMenuVM
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
            if (User.Identities!=null)
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

            var _packageList = new AddPackageMenuVM();
            _packageList.PackageList = _packageslist;
            _packageList.MenuList = _menulist;
            return PartialView("~/Views/Packages/Partials/PackageMenuForm.cshtml", _packageList); 
            }
            else
            {
                return Redirect("/Login");
            }
          
        }

        [HttpPost]
        public async Task<IActionResult> AddPackageMenu(AddPackageMenuVM _packageMenu)
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
                
                    PackageMenu = _container
                
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
        public async Task<IActionResult> Details() {
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

                var _packageList = new PackagesVM();
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
        public async Task<IActionResult> AddMenu(AddMenuVM _menuDetails)
        { 
            bool flag = true;
            MenuVM menuDetails = new MenuVM
            {

                Name = _menuDetails.Menu.Name,
                Description = _menuDetails.Menu.Description,
                MenuCategoryID = _menuDetails.Selected

            };

            try
            {
                await mediator.Send(new AddMenuCommand
                {
                    PackageMenu = menuDetails
                });

            }
            catch (Exception)
            {
                flag = false;
            }
            return Json(flag);
        }




        [HttpPost]
        public async Task<IActionResult> AddMenuCategory(AddMenuCategoryVM _menu)
        {
            bool flag = true;
            MenuCategoryVM _menuCategory = new MenuCategoryVM
            {
                Category = _menu.MenuCategory.Category,
            };
            try
            {
                await mediator.Send(new AddMenuCategoryCommand
                {
                    MenuCategory = _menuCategory
                });
            }
            catch (Exception)
            {
                flag = false;
            }

            return Json(flag);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
