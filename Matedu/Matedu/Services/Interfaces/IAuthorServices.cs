namespace Matedu.Services.Interfaces
{
    public interface IAuthorServices
    {
        Task CreateAsync(AuthorCreateDTO model);
        Task DeleteAsync(int id);
        Task EditAsync(AuthorEditDTO model);
        Task<List<AuthorSimpleDTO>> GetAllAsync();
        Task<AuthorEditDTO> GetSingleToEditAsync(int id);
        Task<AuthorDetailedDTO> GetSingleWithAllFieldsAsync(int id);
    }
}