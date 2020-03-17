using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attila.Application.Users.Queries; 
using Attila.UI.Models;
using MediatR;
using Attila.Application.Users.Commands;
using Attila.Application.Login.Queries;
using Attila.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Attila.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;
        private readonly ISignInManager signInManager;
        private readonly IHttpContextAccessor context;
        public HomeController(IMediator mediator, ISignInManager signInManager, IHttpContextAccessor context)
        {
            this.mediator = mediator;
            this.signInManager = signInManager;
            this.context = context;
        }


        public IActionResult Index()
        {
            return Redirect("~/Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(LoginDetailsVM data)
        {
            await signInManager.PasswordSignInAsync(data.Username, data.Password);

            return Json(true);

        }


        [Route("RegisterAccount")]
        public IActionResult RegisterAccount()
        {
            return View();
        }


        [HttpPost]  
        public async Task<IActionResult> AddUser(UserVM user)
        {
            var _return = await mediator.Send(new AddUserCommand { User = user });

            return Json(_return);
        }

 


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
