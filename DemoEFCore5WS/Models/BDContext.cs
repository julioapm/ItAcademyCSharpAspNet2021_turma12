using Microsoft.EntityFrameworkCore;

namespace DemoEFCore5WS.Models
{
    public class BDContext : DbContext
    {
        public DbSet<Blog> Blogs {get;set;}
        public DbSet<Post> Posts {get;set;}

        public BDContext(){}
        public BDContext(DbContextOptions<BDContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.Entity<Post>()
                .Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}