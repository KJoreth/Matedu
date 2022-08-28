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
    }
}
