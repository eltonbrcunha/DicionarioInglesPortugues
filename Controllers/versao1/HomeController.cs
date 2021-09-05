using EltonTradutor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace EltonTradutor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("")]
        public IActionResult Index(String q)
        {
            var da = new DataAccess();

            if (!String.IsNullOrEmpty(q))
            {
                return View(da.BuscarPalavra(q));
            }

            return View();

        }
       

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // HomeController.cs
    // HomeController.cs
    public IActionResult Pesquisa()
    {
        return View();
    }

}
}
