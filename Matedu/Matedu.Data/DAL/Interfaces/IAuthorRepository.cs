namespace Matedu.Data.DAL.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<bool> AnyByIdAsync(int id);
        Task<bool> AnyByNameAsync(string name);
        Task<List<Author>> GetAllWithMaterialsAsync();
        Task<Author> GetSingleByIdAsync(int id);
        Task<Author> GetSingleWithAllFieldsByIdAsync(int id);
    }
}