namespace Matedu.Data.DAL.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<bool> AnyByIdAsync(int id);
        Task<List<Author>> GetAllWithMaterialsAsync();
        Task<Author> GetSingleByIdAsync(int id);
        Task<Author> GetSingleWithAllFieldsAndReviewsByIdAsync(int id);
        Task<Author> GetSingleWithAllFieldsByIdAsync(int id);
    }
}