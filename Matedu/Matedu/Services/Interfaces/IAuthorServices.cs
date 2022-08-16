namespace Matedu.Services.Interfaces
{
    public interface IAuthorServices
    {
        Task<List<AuthorSimpleDTO>> GetAllAsync();
    }
}