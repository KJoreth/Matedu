
namespace Matedu.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewServices _reviewServices;
        public ReviewController(IReviewServices reviewServices)
            => _reviewServices = reviewServices;

        [HttpGet]
        public IActionResult Create(int materialId)
            => View(new ReviewCreateViewModel() { MaterialId = materialId});

        [HttpPost]
        public async Task<IActionResult> Create(ReviewCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userName = User.FindFirstValue(ClaimTypes.Name);
                await _reviewServices.CreateAsync(model, User.Identity.Name);
                return RedirectToAction("Details", "Material", new {id = model.MaterialId});
            }
            ViewBag.Msg = "An error accured. Your entry have not been submited";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, int materialId)
        {
            await _reviewServices.DeleteAsync(id);
            return RedirectToAction("details", "material", new { id = materialId });
        }
    }
}
