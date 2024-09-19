namespace ComicBookGallery.Models
{
    public class ComicBookPublishers
    {
        public int ComicBookId { get; set; }
        public ComicBook ComicBook { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
