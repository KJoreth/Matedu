
namespace Matedu.MapperProfiles
{
    public class MaterialProfiles : Profile
    {
        public MaterialProfiles()
        {
            CreateMap<Material, MaterialSimpleDTO>();
            CreateMap<Material, MaterialSearchDTO>();
            CreateMap<Material, MaterialDetailedDTO>();
        }
    }
}
