using Microsoft.AspNetCore.Mvc;

namespace Matedu.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorServices _authorServices;

        public AuthorController(IAuthorServices authorServices)
            => _authorServices = authorServices;


        public async Task<IActionResult> Index()
        {
            List<AuthorSimpleDTO> authors = await _authorServices.GetAllAsync();
            return View(authors);
        }


        public async Task<IActionResult> Delete(int id)
        {
            await _authorServices.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
