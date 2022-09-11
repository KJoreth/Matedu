namespace Matedu.Data.DAL.Interfaces
{
    public interface ITypeRepository : IBaseRepository<MaterialType>
    {
        Task<bool> AnyByIdAsync(int id);
        Task<bool> AnyByNameAsync(string name);
        Task<MaterialType> GetSingleByIdAsync(int id);
        Task<MaterialType> GetSingleWithAllFieldsByIdAsync(int id);
    }
}