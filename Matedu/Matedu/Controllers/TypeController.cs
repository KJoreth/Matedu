using Microsoft.AspNetCore.Mvc;

namespace Matedu.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeServices _typeServices;
        public TypeController(ITypeServices services)
            => _typeServices = services;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var types = await _typeServices.GetAllAsync();
            return View(types);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var type = await _typeServices.GetSingleAsync(id);
            return View(type);
        }

        
    }
}
