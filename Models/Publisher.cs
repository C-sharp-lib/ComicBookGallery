using System.ComponentModel.DataAnnotations;

namespace ComicBookGallery.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        public string Name { get; set; }
    }
}
