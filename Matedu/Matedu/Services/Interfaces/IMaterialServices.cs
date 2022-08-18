namespace Matedu.Services.Interfaces
{
    public interface IMaterialServices
    {
        Task<List<MaterialSearchDTO>> GetAllAsync();
        Task<MaterialDetailedDTO> GetSingleAsync(int id);
    }
}