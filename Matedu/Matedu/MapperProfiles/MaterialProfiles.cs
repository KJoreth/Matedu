
namespace Matedu.MapperProfiles
{
    public class MaterialProfiles : Profile
    {
        public MaterialProfiles()
        {
            CreateMap<Material, MaterialSimpleDTO>();
        }
    }
}
