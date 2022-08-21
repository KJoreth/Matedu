using Matedu.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Matedu.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeServices _homeServices;
        public HomeController(IHomeServices homeServices)
            => _homeServices = homeServices;

        public async Task<IActionResult> Index()
        {
            var model = await _homeServices.GetViewModelAsync();
            return View(model);
        }

        public IActionResult Privacy()
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