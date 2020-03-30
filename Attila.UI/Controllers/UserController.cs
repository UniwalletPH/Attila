using Attila.Application.Users.Queries;
using MediatR;
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

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var _users = await mediator.Send(new ViewUserListQuery());

            return View(_users);
        }

        public async Task<IActionResult> Profile(Guid uid)
        {
            var _userProfile = await mediator.Send(new SearchUserByIdQuery { UID = uid});

            return View(_userProfile);
        }
    }
}
