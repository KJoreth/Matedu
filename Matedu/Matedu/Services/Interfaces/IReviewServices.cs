namespace Matedu.Services.Interfaces
{
    public interface IReviewServices
    {
        Task CreateAsync(ReviewCreateViewModel model, string username);
        Task DeleteAsync(int id);
        Task<List<ReviewDetailedDTO>> GetReviesOfUserAsync(string username);
    }
}