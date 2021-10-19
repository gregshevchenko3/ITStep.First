using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITStep.First.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
