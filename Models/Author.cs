using System.ComponentModel.DataAnnotations;

namespace ComicBookGallery.Models
{
    public class Author : IHelperFunctions
    {
        [Key]
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<ComicBookAuthors> ComicBookAuthors { get; set; }

        public string ConvertImageUrlToLower(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path cannot be null or empty", nameof(path));
            }
            return path.ToLower();
        }

        public string TruncateDescription(string description, int wordLimit = 50)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return string.Empty;
            }
            var words = description.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (words.Length <= wordLimit)
            {
                return description;
            }
            return string.Join(" ", words.Take(wordLimit)) + "...";
        }
    }

}
