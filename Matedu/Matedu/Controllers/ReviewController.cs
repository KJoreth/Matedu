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
                await _reviewServices.CreateAsync(model);
                return RedirectToAction("Details", "Material", new {id = model.MaterialId});
            }
            ViewBag.Msg = "An error accured. Your entry have not been submited";
            return View(model);
        }
    }
}
