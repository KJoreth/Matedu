namespace Matedu.Data.DAL.Interfaces
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task<bool> AnyByIdAsync(int id);
        Task<bool> AnyByUsernameAsync(string username);
        Task<List<Review>> GetAllOfUser(string username);
        Task<Review> GetSingleByIdAsync(int id);
    }
}