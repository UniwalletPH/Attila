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
            if (User.Identities!=null)
            {

                return Redirect("/Dashboard");
            }
            else { return Redirect("/Login"); }
            
        }

       

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(LoginDetailsVM data)
        {
            var x = await signInManager.PasswordSignInAsync(data.Username, data.Password);
         
            if (x.Succeeded)
            {

                if (User.Identities != null) 
                {


                    //Claim _claim = User?.FindFirst(ClaimTypes.UserData); //kinuha yung Identity
                    //var _userData = _claim?.Value;//Kinuha yung isang claim na laman yung JSON na Details ng User
                    //var _user = JsonConvert.DeserializeObject<UserVM>(_userData); //tapos desirialize.. Pacheck kung okay 
                    //var identity = (ClaimsIdentity)User.Identity;
                    //IEnumerable<Claim> claims = identity.Claims;
                    return Redirect("/Dashboard"); } else
                {
                    return View("Login");
                }               
            }
            else {



                return View("Login");
            }


        }


        [Route("RegisterAccount")]
        public IActionResult RegisterAccount()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            //if (User.Identities!=null)
            //{
              await signInManager.SignOutAsync(); 
                return Redirect("/Login");
            //}
            //else {
            //return Redirect("/Login");
            //}
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
