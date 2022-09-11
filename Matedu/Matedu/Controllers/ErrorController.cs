using Microsoft.AspNetCore.Mvc;

namespace Matedu.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ResourceNotFound()
            => View();
        public IActionResult ResourceAlreadyExists()
            => View();
        public IActionResult ReviewAlreadyExists()
            => View();

    }
}
