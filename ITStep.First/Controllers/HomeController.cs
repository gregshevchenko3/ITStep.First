using ITStep.First.Models;
using ITStep.First.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ITStep.First.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController()
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(opts => opts.AddConsole());
            _logger = loggerFactory.CreateLogger<HomeController>();
        }

        public IActionResult Index()
        {
            var p = new Profile();
            _logger.LogInformation(p.Title);
            return View(p);
        }
    }
}
