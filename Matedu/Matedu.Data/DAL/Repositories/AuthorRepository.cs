namespace Matedu.Data.DAL.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(MateduContext context) : base(context) { }

        public MateduContext MateduContext => _context as MateduContext;
        public async Task<Author> GetSingleWithAllFieldsByIdAsync(int id)
        {
            if (!await AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Author with id: {id} was not found");
    
            return await MateduContext.Authors
                .Where(x => x.Id == id)
                .Include(x => x.Materials)
                .FirstOrDefaultAsync();
        }
    
        public async Task<Author> GetSingleWithAllFieldsAndReviewsByIdAsync(int id)
        {
            if (!await AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Author with id: {id} was not found");
    
            return await MateduContext.Authors
                .Where(x => x.Id == id)
                .Include(x => x.Materials)
                .ThenInclude(x => x.Reviews)
                .FirstOrDefaultAsync();
        }
    
        public async Task<bool> AnyByIdAsync(int id)
            => await MateduContext.Authors
            .Where(x => x.Id == id)
            .AnyAsync();
    
    }
    
}
