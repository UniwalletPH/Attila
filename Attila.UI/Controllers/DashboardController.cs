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
using Attila.Application.Notification.Queries;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Attila.Application.Admin.Events.Queries;

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
        public async Task<IActionResult>  Index()
        {


            var _pendingEvents = await mediator.Send(new GetAllPendingEventsQuery { });
            var _incomingEvents = await mediator.Send(new GetAllIncomingEventsQuery { });
            var _pastEvents = await mediator.Send(new GetAllPastEventsQuery { });

            var _forEvent = new EventViewCVM
            { 
                IncomingEvent = _incomingEvents,
                PastEvent = _pastEvents,
                PendingEvent = _pendingEvents
            };


            return View(_forEvent);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


     
    } 
}