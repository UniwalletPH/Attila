using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attila.UI.Models;
using MediatR;
using Attila.Application.Event.Queries;

namespace Attila.UI.Controllers
{
    public class ReportsController : Controller
    {

        private readonly IMediator mediator;

        public ReportsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        public async Task<IActionResult> Index()
        {

            var _searchResult = await mediator.Send(new GetClientListQuery());

            return View(_searchResult); 
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
