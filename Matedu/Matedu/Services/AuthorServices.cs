
namespace Matedu.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AuthorSimpleDTO>> GetAllAsync()
        {
            List<Author> authors = await _unitOfWork.AuthorRepository.GetAllWithMaterialsAsync();
            return _mapper.Map<List<AuthorSimpleDTO>>(authors);
        }

        public async Task DeleteAsync(int id)
        {
            Author author = await _unitOfWork.AuthorRepository.GetSingleByIdAsync(id);
            await _unitOfWork.AuthorRepository.RemoveAsync(author);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task<AuthorDetailedDTO> GetSingleWithAllFieldsAsync(int id)
        {
            Author author = await _unitOfWork.AuthorRepository.GetSingleWithAllFieldsByIdAsync(id);
            return _mapper.Map<AuthorDetailedDTO>(author);
        }

        public async Task<AuthorEditDTO> GetSingleToEditAsync(int id)
        {
            Author author = await _unitOfWork.AuthorRepository.GetSingleByIdAsync(id);
            return _mapper.Map<AuthorEditDTO>(author);
        }

        public async Task EditAsync(AuthorEditDTO model)
        {
            if (await _unitOfWork.AuthorRepository.AnyByNameAsync(model.Name))
                throw new ResourceAlreadyExistsException($"Author with name {model.Name} already exists");

            Author author = await _unitOfWork.AuthorRepository.GetSingleByIdAsync(model.Id);
            _mapper.Map(model, author);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task CreateAsync(AuthorCreateDTO model)
        {
            if (await _unitOfWork.AuthorRepository.AnyByNameAsync(model.Name))
                throw new ResourceAlreadyExistsException($"Author with name {model.Name} already exists");

            Author author = _mapper.Map<Author>(model);
            await _unitOfWork.AuthorRepository.AddAsync(author);
            await _unitOfWork.CompleteUnitAsync();
        }
    }
}
