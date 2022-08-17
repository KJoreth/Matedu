namespace Matedu.Services.Interfaces
{
    public interface ITypeServices
    {
        Task CreateAsync(TypeCreateDTO model);
        Task DeleteAsync(int id);
        Task EditAsync(TypeEditDTO model);
        Task<List<TypeSimpleDTO>> GetAllAsync();
        Task<TypeDetailedDTO> GetSingleAsync(int id);
        Task<TypeEditDTO> GetSingleToEditAsync(int id);
    }
}