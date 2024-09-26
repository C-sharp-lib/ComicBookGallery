using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;

namespace ComicBookGallery.Models
{
    public class ComicBook : IHelperFunctions
    {
        [Key]
        public int ComicBookId { get; set; }
        [Required]
        public int IssueNo { get; set; }
        [Required]
        [StringLength(100)]
        public string SeriesTitle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishedOn { get; set; }
        public ICollection<ComicBookAuthors> ComicBookAuthors { get; set; }
        public ICollection<ComicBookPublishers> ComicBookPublishers { get; set; }

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