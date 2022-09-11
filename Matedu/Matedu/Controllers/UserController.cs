namespace Matedu.Controllers
{
    public class UserController : Controller
    {
        private readonly IReviewServices _reviewServices;

        public UserController(IReviewServices reviewServices)
            => _reviewServices = reviewServices;

        [HttpGet]
        public async Task<IActionResult> Index(string username)
        {
            if(User.Identity.Name == username)
            {
                var reviews = await _reviewServices.GetReviesOfUserAsync(username);
                return View(reviews);
            }

            return LocalRedirect("/Identity/Account/AccessDenied");
        }
    }
}
