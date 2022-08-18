using Microsoft.AspNetCore.Mvc;

namespace Matedu.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialServices _materialServices;
        public MaterialController(IMaterialServices materialServices)
            => _materialServices = materialServices;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var materials = await _materialServices.GetAllAsync();
            return View(materials);
        }
    }
}
