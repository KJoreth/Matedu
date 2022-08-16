namespace Matedu.MapperProfiles
{
    public class AuthorProfiles : Profile
    {
        public AuthorProfiles()
        {
            CreateMap<Author, AuthorSimpleDTO>();
            CreateMap<Author, AuthorDetailedDTO>();
        }
    }
}
