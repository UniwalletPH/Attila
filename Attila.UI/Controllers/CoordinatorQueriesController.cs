using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Attila.UI.Controllers
{
    public class CoordinatorQueriesController : Controller
    {

        private readonly IMediator mediator;
        public CoordinatorQueriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}