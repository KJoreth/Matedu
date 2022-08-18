namespace Matedu.Services
{
    public class MaterialServices : IMaterialServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MaterialServices(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MaterialSearchDTO>> GetAllAsync()
        {
            var materials = await _unitOfWork.MaterialRepository.GetAllWithAuthorAndTypeAsync();
            return _mapper.Map<List<MaterialSearchDTO>>(materials);
        }

        public async Task<MaterialDetailedDTO> GetSingleAsync(int id)
        {
            var material = await _unitOfWork.MaterialRepository.GetSingleWithAllFieldsByIdAsync(id);
            return _mapper.Map<MaterialDetailedDTO>(material);
        }
    }
}
