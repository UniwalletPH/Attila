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
 

        [HttpGet]
        public async Task<IActionResult> AddEventPackages()
        {
            var _getPackageList = await mediator.Send(new GetEventPackageListQuery());

            return View(_getPackageList);
        }

        public IActionResult PackageForm()
        {
            
            return View();
        }





        [HttpGet]
        public async Task<IActionResult> MenuCategoryForm()
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


        [HttpGet]
            public async Task<IActionResult> MenuForm()
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
                   var _addEventList = new AddEventMenuVM();
                 _addEventList.MenuList = _list;
                   return View(_addEventList);
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





        [HttpPost]
        public async Task<IActionResult> AddMenu(AddMenuVM _menuDetails)
        { 


             
            bool flag = true;
            MenuVM menuDetails = new MenuVM
            {

                Name = _menuDetails.Menu.Name,
                Description = _menuDetails.Menu.Description,
                MenuCategoryID = _menuDetails.Menu.MenuCategoryID

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
        public async Task<IActionResult> AddMenuCategory(MenuCategoryVM _menu)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new AddMenuCategoryCommand
                {
                    MenuCategory = _menu
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
