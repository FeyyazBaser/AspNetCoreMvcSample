using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AspNetCoreMvcSample.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppIdentityUser, AppIdentiyRole, string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {

        }
    }
}
