using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto_PrograAvanzadaWeb.Models;
using Proyecto_PrograAvanzadaWeb.Services;

namespace Proyecto_PrograAvanzadaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductoService _productoService;

        public HomeController(ILogger<HomeController> logger, IProductoService productoService)
        {
            _logger = logger;
            _productoService = productoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult contact()
        {
            return View();
        }

        public async Task<IActionResult> Shop()
        {
            return View(_productoService.ObtenerProductos());
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Inicio()
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