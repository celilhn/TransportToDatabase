using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class DidTheyPlayTogetherDbContext : DbContext
    {
        public DidTheyPlayTogetherDbContext(DbContextOptions<DidTheyPlayTogetherDbContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<KnownFor> KnownFors { get; set; }
        public DbSet<SocialMediaID> socialMediaIDs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(b => b.InsertionDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Person>().Property(b => b.UpdateDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Person>().Property(b => b.Status).HasDefaultValueSql("1");
            modelBuilder.Entity<Crew>().Property(b => b.InsertionDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Crew>().Property(b => b.UpdateDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Cast>().Property(b => b.InsertionDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Cast>().Property(b => b.UpdateDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<KnownFor>().Property(b => b.InsertionDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<KnownFor>().Property(b => b.UpdateDate).HasDefaultValueSql("getdate()");
        }
    }
}
