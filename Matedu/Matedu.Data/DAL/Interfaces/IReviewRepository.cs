namespace Matedu.Data.DAL.Interfaces
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task<bool> AnyByIdAsync(int id);
        Task<Review> GetSingleByIdAsync(int id);
    }
}