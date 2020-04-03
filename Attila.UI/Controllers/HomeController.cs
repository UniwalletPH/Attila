using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; 
using Attila.Application.Users.Queries;
using Attila.UI.Models;
using MediatR;
using Attila.Application.Users.Commands;
using Attila.Application.Login.Queries;
using Attila.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Attila.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMediator mediator;
        private readonly ISignInManager signInManager;
        public HomeController(IMediator mediator, ISignInManager signInManager)
        {
            this.mediator = mediator;
            this.signInManager = signInManager;
        }

        [Authorize(Roles = "Admin,Coordinator, InventoryManager")]
        public IActionResult Index()
        {
            return Redirect("/Dashboard");
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(LoginDetailsVM data)
        {
            var _signinResult = await signInManager.PasswordSignInAsync(data.Username, data.Password);

            return Json(_signinResult);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult RegisterAccount()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }

        [Route("/Error/403")]
        public IActionResult ErrorPage() {  
            return View();
        }

        [Authorize(Roles = "Admin")]
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
