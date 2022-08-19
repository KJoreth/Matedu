namespace Matedu.Services.Interfaces
{
    public interface IReviewServices
    {
        Task CreateAsync(ReviewCreateViewModel model);
    }
}