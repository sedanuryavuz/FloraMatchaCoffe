using Flora.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flora.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=FloraCoffe;User ID=sa;Password=12345;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }
        public DbSet<About>? Abouts { get; set; }
        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<Discount>? Discounts { get; set; }
        public DbSet<Feature>? Features { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<SocialMedia>? SocialMedias { get; set; }
        public DbSet<Testimonial>? Testimonials { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderDetail>? OrderDetails { get; set; }
        public DbSet<MoneyCase>? MoneyCases { get; set; }
        public DbSet<MenuTable>? MenuTables { get; set; }
    }
}
