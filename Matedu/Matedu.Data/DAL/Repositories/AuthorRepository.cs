namespace Matedu.Data.DAL.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(MateduContext context) : base(context) { }

        public MateduContext MateduContext => _context as MateduContext;

        public async Task<Author> GetSingleByIdAsync(int id)
        {
            if (!await AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Author with id: {id} was not found");

            return await MateduContext.Authors
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<Author> GetSingleWithAllFieldsByIdAsync(int id)
        {
            if (!await AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Author with id: {id} was not found");
    
            return await MateduContext.Authors
                .Where(x => x.Id == id)
                .Include(x => x.Materials)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Author>> GetAllWithMaterialsAsync()
            => await MateduContext.Authors
                .Include(x => x.Materials)
                .ToListAsync();
    
        public async Task<bool> AnyByIdAsync(int id)
            => await MateduContext.Authors
            .Where(x => x.Id == id)
            .AnyAsync();

        public async Task<bool> AnyByNameAsync(string name)
            => await MateduContext.Authors
            .Where(x => x.Name == name)
            .AnyAsync();

    }
    
}
