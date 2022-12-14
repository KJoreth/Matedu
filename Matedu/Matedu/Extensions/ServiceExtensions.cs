
namespace Matedu.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddDAL(this IServiceCollection service)
        {
            service.AddScoped<IAuthorRepository, AuthorRepository>();
            service.AddScoped<IMaterialRepository, MaterialRepository>();
            service.AddScoped<ITypeRepository, TypeRepository>();
            service.AddScoped<IReviewRepository, ReviewRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddDb(this IServiceCollection service, string connectionString)
            => service.AddDbContext<MateduContext>(options => options.UseSqlServer(connectionString));

        public static void AddIdentity(this IServiceCollection service)
            => service.AddDefaultIdentity<IdentityUser>(o =>
            {
                o.User.RequireUniqueEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MateduContext>();
        public static void AddServices(this IServiceCollection service)
        {
            service.AddScoped<IAuthorServices, AuthorServices>();
            service.AddScoped<ITypeServices, TypeServices>();
            service.AddScoped<IMaterialServices, MaterialServices>();
            service.AddScoped<IReviewServices, ReviewServices>();
            service.AddScoped<IHomeServices, HomeServices>();
        }
    }
}
