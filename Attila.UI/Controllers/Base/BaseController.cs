using Attila.Application.Identity.Queries;
using Attila.UI.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public AttilaUser CurrentUser
        {
            get
            {
                if (User == null)
                {
                    return null;
                }

                if (User.Identity == null)
                {
                    return null;
                }

                return User.Identity.GetUserData();
            }
        }

    }
}
