using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attila.UI.Models;
using MediatR;
using Attila.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Attila.UI.Controllers
{
    public class DashboardController : Controller
    {


        public static bool _checker;

        private readonly IMediator mediator;

        private readonly ISignInManager signInManager;
        private readonly IHttpContextAccessor context;
        public DashboardController(IMediator mediator, ISignInManager signInManager, IHttpContextAccessor context)
        {
            this.mediator = mediator;
            this.signInManager = signInManager;
            this.context = context;
        }

        [Route("Dashboard")]
        [HttpGet]         
        public IActionResult Index()
        {
            if (User.Identity.Name!= null)
            {
                return View();
            }
            else
            {
                return Redirect("/Login");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
