using Matedu.Data.DAL.Interfaces;

namespace Matedu.Data.DAL.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MateduContext context) : base(context) { }
        public MateduContext MateduContext => _context as MateduContext;

        public async Task<Review> GetSingleByIdAsync(int id)
        {
            if (!await AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Review with id: {id} was not found");

            return await MateduContext.Reviews
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Review>> GetAllOfUser(string username)
        {
            return await MateduContext.Reviews
                .Where(x => x.UserName == username)
                .Include(x => x.Material)
                .ToListAsync();
        }

        public async Task<bool> AnyByIdAsync(int id)
            => await MateduContext.Reviews
            .Where(x => x.Id == id)
            .AnyAsync();

        public async Task<bool> AnyByUsernameAsync(string username)
            => await MateduContext.Reviews
            .Where(x => x.UserName == username)
            .AnyAsync();
    }
}
