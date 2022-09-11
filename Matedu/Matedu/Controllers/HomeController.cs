using System.Diagnostics;

namespace Matedu.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeServices _homeServices;
        public HomeController(IHomeServices homeServices)
            => _homeServices = homeServices;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _homeServices.GetViewModelAsync();
            return View(model);
        }   
        public IActionResult Error()
        {
            return View();
        }
    }
}