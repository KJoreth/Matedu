namespace Matedu.Data.DAL.Interfaces
{
    public interface ITypeRepository : IBaseRepository<MaterialType>
    {
        Task<bool> AnyByIdAsync(int id);
        Task<MaterialType> GetSingleWithAllFieldsByIdAsync(int id);
    }
}