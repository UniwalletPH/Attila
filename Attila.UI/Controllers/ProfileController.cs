using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attila.UI.Models;
using MediatR;
using Attila.Application.Users.Queries;
using System.Security.Claims;
using Newtonsoft.Json;

namespace Attila.UI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IMediator mediator;
        public static bool _checker;
        public ProfileController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {

            if (User.Identity.Name != null)
            {

                Claim _claim = User?.FindFirst(ClaimTypes.UserData); //kinuha yung Identity
                var _userData = _claim?.Value;//Kinuha yung isang claim na laman yung JSON na Details ng User
                var _user = JsonConvert.DeserializeObject<UserVM>(_userData); //tapos desirialize.. Pacheck kung okay 


                //var _user = await mediator.Send(new GetUserDetailsQuery { Username = User.Ide });
                return View("Profile");
            }


            return Redirect("Login");
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
