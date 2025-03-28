using Microsoft.EntityFrameworkCore;
using nguyenthiyennhi_2122110579_buoi2.Model;

namespace nguyenthiyennhi_2122110579_buoi2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
