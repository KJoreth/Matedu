namespace Matedu.Services
{
    public class ReviewServices : IReviewServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ReviewServices(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(ReviewCreateViewModel model, string username)
        {
            if (await _unitOfWork.ReviewRepository.UserAlreadyAddedReview(username, model.MaterialId))
                throw new ReviewAlreadyExistsException("This user has added review for this material already");

            Review review = new()
            {
                MaterialId = model.MaterialId,
                Text = model.Text,
                Points = model.Points,
                UserName = username
            };

            await _unitOfWork.ReviewRepository.AddAsync(review);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var review = await _unitOfWork.ReviewRepository.GetSingleByIdAsync(id);
            await _unitOfWork.ReviewRepository.RemoveAsync(review);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task<List<ReviewDetailedDTO>> GetReviesOfUserAsync(string username)
        {
            var reviews = await _unitOfWork.ReviewRepository.GetAllOfUser(username);
            return _mapper.Map<List<ReviewDetailedDTO>>(reviews);
        }
    }
}
