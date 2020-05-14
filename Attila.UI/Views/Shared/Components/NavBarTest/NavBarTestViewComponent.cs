using Attila.Application.Notification.Queries;
using Attila.UI.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Views.Shared.Components.NavBarTest
{
    public class NavBarTestViewComponent : ViewComponent
    {
        private readonly IMediator mediator; 
        public NavBarTestViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = User.Identity.GetUserData();
              var _notifList = await mediator.Send(new GetNotificationQuery { TargetID = user.ID });
            
            return View(_notifList);
        }
    }
}
