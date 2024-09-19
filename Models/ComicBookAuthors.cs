namespace ComicBookGallery.Models
{
    public class ComicBookAuthors
    {
        public int ComicBookId { get; set; }
        public ComicBook ComicBook { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
