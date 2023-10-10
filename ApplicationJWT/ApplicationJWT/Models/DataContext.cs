using Microsoft.EntityFrameworkCore;

namespace ApplicationJWT.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<User>? User { get; set; }

   
    }
}
