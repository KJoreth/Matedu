namespace Matedu.Data.DAL.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<bool> AnyByIdAsync(int id);
        Task<List<Author>> GetAllWithMaterialsAsync();
        Task<Author> GetSingleWithAllFieldsAndReviewsByIdAsync(int id);
        Task<Author> GetSingleWithAllFieldsByIdAsync(int id);
    }
}