namespace Matedu.Services.Interfaces
{
    public interface IHomeServices
    {
        Task<HomeViewModel> GetViewModelAsync();
    }
}