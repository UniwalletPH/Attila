using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Attila.UI.Controllers
{
    public class AdminCommandsController : Controller
    {

        private readonly IMediator mediator;
        public AdminCommandsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}