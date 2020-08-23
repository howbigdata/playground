using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lcaworld.Models;
using lcaworld.Service;

namespace lcaworld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILcaService lcaService;


        public HomeController(ILogger<HomeController> logger, ILcaService lca)
        {
            _logger = logger;
            _logger.LogInformation("This is information");
            lcaService = lca;
        }

        public IActionResult SomeDataMethod()
        {
            return Json(new { foo = "bar", baz = "Blech" });
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult DataModel()
        {
            return View();
        }
        public IActionResult Architecture()
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
