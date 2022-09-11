namespace Matedu.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorServices _authorServices;

        public AuthorController(IAuthorServices authorServices)
            => _authorServices = authorServices;


        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = sortOrder == "name" ? "" : "name";
            ViewData["MaterialCountSortParm"] = sortOrder == "counter" ? "" : "counter";
            ViewData["SearchParm"] = searchString;

            List<AuthorSimpleDTO> authors = await _authorServices.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
                authors = authors.Where(a => a.Name.ToLower().Contains(searchString.ToLower())).ToList();

            switch (sortOrder)
            {
                case "name":
                    authors = authors.OrderBy(a => a.Name).ToList();
                    break;
                case "counter":
                    authors = authors.OrderByDescending(a => a.MaterialCounter).ToList();
                    break;
                default:
                    break;
            }

            return View(authors);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorServices.GetSingleToEditAsync(id);
            return View(author);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
            => View();
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
