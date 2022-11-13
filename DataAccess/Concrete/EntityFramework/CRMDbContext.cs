using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    // DbContext: Database tabloları ile proje class'larını ilişkilendirme
    public class CRMDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Trusted_Connection=True: Kullanıcı adı ve parola istemez.
            // User Id=ozbeytullah;Password=123456;
            optionsBuilder.UseSqlServer(@"Server=MonsterPC\SQLEXPRESS;Database=DbCRM;Trusted_Connection=True;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
