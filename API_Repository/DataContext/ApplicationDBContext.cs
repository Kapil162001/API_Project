using API_Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Repository.DataContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Register> Registers { get; set; }
    }
}
