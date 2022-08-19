using Matedu.ViewModels.MaterialViewModels;

namespace Matedu.Services.Interfaces
{
    public interface IMaterialServices
    {
        Task CreateAsync(MaterialCreateViewModel model);
        Task DeleteAsync(int id);
        Task<List<MaterialSearchDTO>> GetAllAsync();
        Task<MaterialDetailedDTO> GetSingleAsync(int id);
        Task<MaterialCreateViewModel> GetViewModelForCreateAsync();
        Task<MaterialEditViewModel> GetViewModelForEditAsync(int id);
        Task UpdateAsync(MaterialEditViewModel model);
    }
}