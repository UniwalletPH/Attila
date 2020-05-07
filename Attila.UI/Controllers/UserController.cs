using Attila.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            var _users = await mediator.Send(new ViewUserListQuery());

            return View(_users);
        }
        [Authorize(Roles = "Admin,Coordinator,InventoryManager")]
        public async Task<IActionResult> Profile()
        {
            var _userProfile = await mediator.Send(new SearchUserByIdQuery { ID = CurrentUser.ID});

            return View(_userProfile);
        }
    }
}
