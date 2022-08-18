namespace Matedu.Services.Interfaces
{
    public interface IMaterialServices
    {
        Task<List<MaterialSearchDTO>> GetAllAsync();
        Task<MaterialDetailedDTO> GetSingleAsync(int id);
        Task<MaterialEditViewModel> GetViewModelForEditAsync(int id);
        Task UpdateAsync(MaterialEditViewModel model);
    }
}