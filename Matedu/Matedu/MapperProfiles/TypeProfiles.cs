namespace Matedu.MapperProfiles
{
    public class TypeProfiles : Profile
    {
        public TypeProfiles()
        {
            CreateMap<MaterialType, TypeSimpleDTO>();
            CreateMap<MaterialType, TypeDetailedDTO>();
            CreateMap<MaterialType, TypeEditDTO>().ReverseMap();
            CreateMap<TypeCreateDTO, MaterialType>();
        }
    }
}
