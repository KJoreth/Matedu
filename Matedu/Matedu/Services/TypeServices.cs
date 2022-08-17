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

        public async Task<TypeEditDTO> GetSingleToEditAsync(int id)
        {
            var type = await _unitOfWork.TypeRepository.GetSingleByIdAsync(id);
            return _mapper.Map<TypeEditDTO>(type);
        }

        public async Task EditAsync(TypeEditDTO model)
        {
            var type = await _unitOfWork.TypeRepository.GetSingleByIdAsync(model.Id);
            _mapper.Map(model, type);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var type = await _unitOfWork.TypeRepository.GetSingleByIdAsync(id);
            await _unitOfWork.TypeRepository.RemoveAsync(type);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task CreateAsync(TypeCreateDTO model)
        {
            var type = _mapper.Map<MaterialType>(model);
            await _unitOfWork.TypeRepository.AddAsync(type);
            await _unitOfWork.CompleteUnitAsync();
        }

    }
}
