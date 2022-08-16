using Matedu.Data.DAL.Interfaces;

namespace Matedu.Data.DAL.Repositories
{
    public class MaterialRepository : BaseRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(MateduContext context) : base(context) { }
        public MateduContext MateduContext => _context as MateduContext;

        public async Task<Material> GetSingleWithAllFieldsByIdAsync(int id)
        {
            if (!await AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Material with id: {id} was not found");

            return await MateduContext.Materials
                .Where(x => x.Id == id)
                .Include(x => x.Author)
                .Include(x => x.Type)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync();
        }


        public async Task<List<Material>> GetAllByTypeIdAsync(int typeId)
        {
            if (!await MateduContext.Types.Where(x => x.Id == typeId).AnyAsync())
                throw new ResourceNotFoundException($"Type with id: {typeId} was not found");

            return await MateduContext.Materials
                .Where(x => x.Type.Id == typeId)
                .Include(x => x.Author)
                .Include(x => x.Type)
                .Include(x => x.Reviews)
                .ToListAsync();
        }

        public async Task<Material> GetSingleAsNoTrackingByIdAsync(int id)
        {
            if (!await AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Material with id: {id} was not found");

            return await MateduContext.Materials
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AnyByIdAsync(int id)
            => await MateduContext.Materials
            .Where(x => x.Id == id)
            .AnyAsync();

        public async Task<bool> AnyByTtileAsync(string title)
            => await MateduContext.Materials
            .Where(x => x.Title.ToLower() == title.ToLower())
            .AnyAsync();


    }
}

    
