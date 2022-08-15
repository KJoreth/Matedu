using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Matedu.Data.Context
{
    public class MateduContext : IdentityDbContext<IdentityUser>
    {
        public MateduContext(DbContextOptions<MateduContext> options) : base(options) { }
    }
}
