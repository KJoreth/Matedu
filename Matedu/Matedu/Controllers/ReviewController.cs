
namespace Matedu.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewServices _reviewServices;
        public ReviewController(IReviewServices reviewServices)
            => _reviewServices = reviewServices;

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
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
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> DeleteFromMaterialPage(int id, int materialId)
        {
            await _reviewServices.DeleteAsync(id);
            return RedirectToAction("details", "material", new { id = materialId });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFromUserPage(int id, string username)
        {
            if(User.Identity.Name == username)
            {
                await _reviewServices.DeleteAsync(id);
                return RedirectToAction("index", "user", new { username = username });
            }

            return LocalRedirect("/Identity/Account/AccessDenied"); 
        }
    }
}
