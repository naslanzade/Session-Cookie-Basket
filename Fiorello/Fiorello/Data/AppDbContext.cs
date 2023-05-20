using Fiorello.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opttion) : base(opttion)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderInfo> SlidersInfo { get; set;}
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogDetail> BlogsDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Start> Starts { get; set; }
        public DbSet<Instagram> Instagrams { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Slider>().HasQueryFilter(m => !m.SoftDeleted);


           modelBuilder.Entity<Customer>().HasData(
           new Customer
           {
               Id = 1,
               FullName = "Rasul Hasanov",
               Age = 16
           });

           modelBuilder.Entity<Customer>().HasData(
           new Customer
           {
              Id = 2,
              FullName = "Novrasta Aslanzade",
              Age = 25
           });

           modelBuilder.Entity<Customer>().HasData(
           new Customer
           {
              Id = 3,
              FullName = "Musa Afandiyev",
              Age = 19
           });

        }
    }
}
