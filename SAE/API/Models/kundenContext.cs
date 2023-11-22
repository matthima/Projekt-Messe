using Microsoft.EntityFrameworkCore;

namespace MesseAPI.Models
{
    public class kundenContext : DbContext
    {
        public kundenContext(DbContextOptions<kundenContext> options)
            : base(options)
        {
        }

        public DbSet<kundenKarte> kundenKarte { get; set; } = null!;
    }
}

