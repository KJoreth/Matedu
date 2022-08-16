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
    }
}
