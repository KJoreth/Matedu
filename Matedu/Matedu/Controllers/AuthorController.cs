using Microsoft.AspNetCore.Mvc;

namespace Matedu.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorServices _authorServices;

        public AuthorController(IAuthorServices authorServices)
            => _authorServices = authorServices;


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<AuthorSimpleDTO> authors = await _authorServices.GetAllAsync();
            return View(authors);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorServices.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var author = await _authorServices.GetSingleWithAllFieldsAsync(id);
            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorServices.GetSingleToEditAsync(id);
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AuthorEditDTO model)
        {
            if (ModelState.IsValid)
            {
                await _authorServices.EditAsync(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Msg = "An error accured. Your entry have not been submited";
            return View(model);          
        }

        [HttpGet]
        public async Task<IActionResult> Create()
            => View();
        [HttpPost]
        public async Task<IActionResult> Create(AuthorCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                await _authorServices.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Msg = "An error accured. Your entry have not been submited";
            return View(model);
        }
    }
}
