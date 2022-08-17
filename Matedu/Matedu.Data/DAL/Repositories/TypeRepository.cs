using Matedu.Data.DAL.Interfaces;

namespace Matedu.Data.DAL.Repositories
{
    public class TypeRepository : BaseRepository<MaterialType>, ITypeRepository
    {
        public TypeRepository(MateduContext context) : base(context) { }
        public MateduContext MateduContext => _context as MateduContext;

        public async Task<MaterialType> GetSingleWithAllFieldsByIdAsync(int id)
        {
            if (!await AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Type with id: {id} was not found");

            return await MateduContext.Types
                .Where(x => x.Id == id)
                .Include(x => x.Materials)
                .FirstOrDefaultAsync();
        }

        public async Task<MaterialType> GetSingleByIdAsync(int id)
        {
            if (!await AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Type with id: {id} was not found");

            return await MateduContext.Types
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AnyByIdAsync(int id)
            => await MateduContext.Types
            .Where(x => x.Id == id)
            .AnyAsync();
    }
}
