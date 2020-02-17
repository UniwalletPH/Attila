using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Attila.UI.Controllers
{
    public class InventoryManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}