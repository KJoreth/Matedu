namespace Matedu.Services
{
    public class HomeServices : IHomeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HomeServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<HomeViewModel> GetViewModelAsync()
        {
            var materials = await _unitOfWork.MaterialRepository.GetAllWithAllFieldsAsync();
            materials = materials.OrderByDescending(x => x.AverageScore).ToList();
            var materialCount = materials.Count();
            var authors = await _unitOfWork.AuthorRepository.GetAllAsync();
            var authorCount = authors.Count();
            var types = await _unitOfWork.TypeRepository.GetAllAsync();
            var typeCount = types.Count();

            return new HomeViewModel()
            {
                AuthorCounter = authorCount,
                TypeCounter = typeCount,
                MaterialCounter = materialCount,
                TopMaterials = _mapper.Map<List<MaterialDetailedDTO>>(materials.Take(3))
            };
        }
    }
}
