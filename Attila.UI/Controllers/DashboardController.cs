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
using Microsoft.AspNetCore.Authorization;

namespace Attila.UI.Controllers
{
    [Authorize(Roles = "Admin,Coordinator, InventoryManager,Chef")]
    public class DashboardController : BaseController
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

        [HttpGet]         
        public IActionResult Index()
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
