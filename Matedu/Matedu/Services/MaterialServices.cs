
using Matedu.ViewModels.MaterialViewModels;

namespace Matedu.Services
{
    public class MaterialServices : IMaterialServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MaterialServices(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MaterialSearchDTO>> GetAllAsync()
        {
            var materials = await _unitOfWork.MaterialRepository.GetAllWithAuthorAndTypeAsync();
            return _mapper.Map<List<MaterialSearchDTO>>(materials);
        }

        public async Task<MaterialDetailedDTO> GetSingleAsync(int id)
        {
            var material = await _unitOfWork.MaterialRepository.GetSingleWithAllFieldsByIdAsync(id);
            return _mapper.Map<MaterialDetailedDTO>(material);
        }

        public async Task<MaterialEditViewModel> GetViewModelForEditAsync(int id)
        {
            MaterialEditViewModel model = new();
            var material = await _unitOfWork.MaterialRepository.GetSingleWithAllFieldsByIdAsync(id);
            var authors = await _unitOfWork.AuthorRepository.GetAllAsync();
            var types = await _unitOfWork.TypeRepository.GetAllAsync();
            model.Author = material.Author.Id;
            model.Type = material.Type.Id;
            authors.ForEach(x => model.Authors.Add(new SelectListItem { Text = x.Name, Value = x.Id.ToString()}));
            types.ForEach(x => model.Types.Add(new SelectListItem { Text = x.Name, Value =  x.Id.ToString()}));
            model.MaterialId = id;
            model.MaterialTitle = material.Title;
            model.MaterialLocation = material.Location;
            return model;
        }

        public async Task UpdateAsync(MaterialEditViewModel model)
        {
            var material = await _unitOfWork.MaterialRepository.GetSingleWithAllFieldsByIdAsync(model.MaterialId);
            var author = await _unitOfWork.AuthorRepository.GetSingleWithAllFieldsByIdAsync(model.Author);
            var type = await _unitOfWork.TypeRepository.GetSingleWithAllFieldsByIdAsync(model.Type);
            material.Author = author;
            material.Type = type;
            material.Title = model.MaterialTitle;
            material.Location = model.MaterialLocation;
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task<MaterialCreateViewModel> GetViewModelForCreateAsync()
        {
            MaterialCreateViewModel model = new();
            var authors = await _unitOfWork.AuthorRepository.GetAllAsync();
            var types = await _unitOfWork.TypeRepository.GetAllAsync();
            authors.ForEach(x => model.Authors.Add(new SelectListItem { Text = x.Name, Value = x.Id.ToString() }));
            types.ForEach(x => model.Types.Add(new SelectListItem { Text = x.Name, Value = x.Id.ToString() }));
            return model;
        }

        public async Task CreateAsync(MaterialCreateViewModel model)
        {
            Material material = new()
            {
                Title = model.MaterialTitle,
                Location = model.MaterialLocation,
                AuthorId = model.Author,
                TypeId = model.Type
            };
            await _unitOfWork.MaterialRepository.AddAsync(material);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var material = await _unitOfWork.MaterialRepository.GetSingleByIdAsync(id);
            await _unitOfWork.MaterialRepository.RemoveAsync(material);
            await _unitOfWork.CompleteUnitAsync();
        }
    }
}
