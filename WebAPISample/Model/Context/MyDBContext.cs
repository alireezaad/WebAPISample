using Microsoft.EntityFrameworkCore;

namespace WebAPISample.Model.DBContext
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<Twitt> twitts { get; set; }
    }
}
