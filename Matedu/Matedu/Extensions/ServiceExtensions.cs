
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

        public static void AddRoles(this IServiceCollection service)
            => service.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MateduContext>();
        public static void AddServices(this IServiceCollection service)
        {
            service.AddScoped<IAuthorServices, AuthorServices>();
            service.AddScoped<ITypeServices, TypeServices>();
        }
    }
}
