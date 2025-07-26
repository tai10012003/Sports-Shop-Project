using Microsoft.EntityFrameworkCore;
using WebService.Models;

namespace WebService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.NgayTao)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Product>()
                .Property(p => p.NgayTao)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Category>()
                .HasAlternateKey(c => c.MaDanhMuc);

            modelBuilder.Entity<Product>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(p => p.MaDanhMuc)
                .HasPrincipalKey(c => c.MaDanhMuc);

            modelBuilder.Entity<Brand>()
                .HasAlternateKey(b => b.MaThuongHieu);
                
            modelBuilder.Entity<Product>()
                .HasOne<Brand>()
                .WithMany()
                .HasForeignKey(p => p.MaThuongHieu)
                .HasPrincipalKey(b => b.MaThuongHieu);

            modelBuilder.Entity<Category>()
                .Property(c => c.NgayTao)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Category>()
                .Property(c => c.NgayCapNhat)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Brand>()
                .Property(b => b.NgayTao)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Brand>()
                .Property(b => b.NgayCapNhat)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Product>()
                .HasAlternateKey(p => p.MaSanPham);

            modelBuilder.Entity<ProductImage>()
                .Property(b => b.NgayTao)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<ProductImage>()
                .Property(b => b.NgayCapNhat)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<ProductImage>()
                .HasOne(pi => pi.SanPham)
                .WithMany(p => p.HinhAnh)
                .HasForeignKey(pi => pi.MaSanPham)
                .HasPrincipalKey(p => p.MaSanPham);

            modelBuilder.Entity<ProductReview>()
                .Property(pr => pr.NgayTao)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<ProductReview>()
                .Property(pr => pr.NgayCapNhat)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<ProductReview>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(pr => pr.MaSanPham)
                .HasPrincipalKey(p => p.MaSanPham);

            modelBuilder.Entity<User>()
                .Property(u => u.NgayTao)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<User>()
                .Property(u => u.NgayCapNhat)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
