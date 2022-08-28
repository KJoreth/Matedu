namespace Matedu.MapperProfiles
{
    public class ReviewProfiles : Profile
    {
        public ReviewProfiles()
        {
            CreateMap<Review, ReviewSimpleDTO>();
            CreateMap<Review, ReviewDetailedDTO>();
        }
    }
}
