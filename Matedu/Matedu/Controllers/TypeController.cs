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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var type = await _typeServices.GetSingleToEditAsync(id);
            return View(type);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TypeEditDTO model)
        {
            if (ModelState.IsValid)
            {
                await _typeServices.EditAsync(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Msg = "An error accured. Your entry have not been submited";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _typeServices.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
