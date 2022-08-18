using Microsoft.AspNetCore.Mvc;

namespace Matedu.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialServices _materialServices;
        public MaterialController(IMaterialServices materialServices)
            => _materialServices = materialServices;

        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = sortOrder == "name" ? "" : "name";
            ViewData["AuthorSortParm"] = sortOrder == "author" ? "" : "author";
            ViewData["TypeSortParm"] = sortOrder == "type" ? "" : "type";
            var materials = await _materialServices.GetAllAsync();

            switch (sortOrder)
            {
                case "name":
                    materials = materials.OrderBy(m => m.Title).ToList();
                    break;
                case "author":
                    materials = materials.OrderBy(m => m.Author.Name).ToList();
                    break;
                case "type":
                    materials = materials.OrderBy(m => m.Type.Name).ToList();
                    break;
                default:
                    break;
            }

            return View(materials);
        }
    }
}
