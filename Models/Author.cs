using System.ComponentModel.DataAnnotations;

namespace ComicBookGallery.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ComicBookAuthors> ComicBookAuthors { get; set; }
    }

}
