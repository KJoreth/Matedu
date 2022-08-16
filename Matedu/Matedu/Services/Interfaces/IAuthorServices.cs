namespace Matedu.Services.Interfaces
{
    public interface IAuthorServices
    {
        Task DeleteAsync(int id);
        Task<List<AuthorSimpleDTO>> GetAllAsync();
        Task<AuthorDetailedDTO> GetSingleAsync(int id);
    }
}