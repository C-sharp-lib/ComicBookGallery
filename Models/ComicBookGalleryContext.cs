using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ComicBookGallery.Models
{
    public class ComicBookGalleryContext : DbContext
    {
        public ComicBookGalleryContext(DbContextOptions<ComicBookGalleryContext> options) : base(options)
        {

        }
        public DbSet<ComicBook> ComicBooks { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
    }
}
