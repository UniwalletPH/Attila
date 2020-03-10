using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attila.UI.Models;
using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Event.Commands;
using MediatR;
using Attila.Application.Event.Queries;

namespace Attila.UI.Controllers
{
    public class ClientsController : Controller
    { 
        private readonly IMediator mediator;

        public ClientsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        public async Task<IActionResult> Index()
        
        {
            var _searchResult = await mediator.Send(new GetClientListQuery());

            return View(_searchResult); 
                }
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddClientDetails(EventClientVM _eventClient)
        {
            bool flag = true;
            try
            {
                await mediator.Send(new AddClientDetailsCommand
                {
                    EventClient = _eventClient
                });
            }
            catch (Exception)
            {
                flag = false;
            }

            return Json(flag);
        }

      

        public IActionResult Privacy()
        {
            return View();
        } 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
