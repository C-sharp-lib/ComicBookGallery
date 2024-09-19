using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ComicBookGallery.Models
{
    public class ComicBookGalleryContext : DbContext
    {
        public ComicBookGalleryContext(DbContextOptions<ComicBookGalleryContext> options) : base(options)
        {

        }
        public DbSet<ComicBook> ComicBook { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<ComicBookAuthors> ComicBookAuthors { get; set; }
        public DbSet<ComicBookPublishers> ComicBookPublishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComicBookAuthors>()
            .HasKey(ca => new { ca.ComicBookId, ca.AuthorId });

            modelBuilder.Entity<ComicBookAuthors>()
                .HasOne(ca => ca.ComicBook)
                .WithMany(c => c.ComicBookAuthors)
                .HasForeignKey(ca => ca.ComicBookId);

            modelBuilder.Entity<ComicBookAuthors>()
                .HasOne(ca => ca.Author)
                .WithMany(a => a.ComicBookAuthors)
                .HasForeignKey(ca => ca.AuthorId);

            modelBuilder.Entity<ComicBookPublishers>()
                .HasKey(cp => new { cp.ComicBookId, cp.PublisherId });

            modelBuilder.Entity<ComicBookPublishers>()
                .HasOne(cp => cp.ComicBook)
                .WithMany(c => c.ComicBookPublishers)
                .HasForeignKey(cp => cp.ComicBookId);

            modelBuilder.Entity<ComicBookPublishers>()
                .HasOne(cp => cp.Publisher)
                .WithMany(p => p.ComicBookPublishers)
                .HasForeignKey(cp => cp.PublisherId);
        }
    }
}
