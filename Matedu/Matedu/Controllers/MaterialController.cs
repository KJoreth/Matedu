using Matedu.ViewModels.MaterialViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Matedu.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialServices _materialServices;
        public MaterialController(IMaterialServices materialServices)
            => _materialServices = materialServices;

        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["TitleSortParm"] = sortOrder == "title" ? "" : "title";
            ViewData["AuthorSortParm"] = sortOrder == "author" ? "" : "author";
            ViewData["TypeSortParm"] = sortOrder == "type" ? "" : "type";
            ViewData["SearchParm"] = searchString;
            var materials = await _materialServices.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
                materials = materials.Where(m => m.Title.ToLower().Contains(searchString.ToLower())).ToList();

            switch (sortOrder)
            {
                case "title":
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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var material = await _materialServices.GetSingleAsync(id);
            return View(material);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _materialServices.GetViewModelForEditAsync(id);
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult>Edit(MaterialEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _materialServices.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Msg = "An error accured. Your entry have not been submited";
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var model = await _materialServices.GetViewModelForCreateAsync();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(MaterialCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _materialServices.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Msg = "An error accured. Your entry have not been submited";
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _materialServices.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
