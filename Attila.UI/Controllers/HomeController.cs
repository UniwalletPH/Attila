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

namespace Attila.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
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
