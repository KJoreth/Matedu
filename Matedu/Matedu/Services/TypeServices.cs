namespace Matedu.Services
{
    public class TypeServices : ITypeServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TypeServices(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TypeSimpleDTO>> GetAllAsync()
        {
            var types = await _unitOfWork.TypeRepository.GetAllAsync();
            return _mapper.Map<List<TypeSimpleDTO>>(types);
        }

        public async Task<TypeDetailedDTO> GetSingleAsync(int id)
        {
            var type = await _unitOfWork.TypeRepository.GetSingleWithAllFieldsByIdAsync(id);
            return _mapper.Map<TypeDetailedDTO>(type);
        }

    }
}
