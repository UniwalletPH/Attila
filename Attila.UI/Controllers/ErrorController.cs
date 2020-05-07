using Attila.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Controllers
{
    [AllowAnonymous]
    public class ErrorController : BaseController
    {
        [Route("/Error/403")]
        public IActionResult Error_403()
        {
            return View();
        }

        [Route("/Error/405")]
        public IActionResult Error_405()
        {
            return View();
        }

        [Route("/Error/404")]
        public IActionResult Error_404()
        {
            return View();
        }

        [Route("/Error/500")]
        public IActionResult Error_500()
        {
            var _exHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            return View(new ErrorViewModel
            {
                Path = _exHandler.Path,
                Error = _exHandler.Error.InnermostException(),
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
