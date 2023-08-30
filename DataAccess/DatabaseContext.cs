using Microsoft.EntityFrameworkCore;
using SocialConnectAPI.Models;

namespace SocialConnectAPI.DataAccess {
    public class DatabaseContext : DbContext {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                      .HasIndex(u => u.Email)
                      .IsUnique();

            modelBuilder.Entity<Post>().OwnsOne(p => p.Tags);

            // modelBuilder.Entity<User>()
            //         .HasMany<Post>()
            //         .WithOne();

            // modelBuilder.Entity<Post>()
            //         .HasMany<User>()
            //         .WithOne();
        }
    }
}