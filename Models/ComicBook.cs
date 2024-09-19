using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;

namespace ComicBookGallery.Models
{
    public class ComicBook
    {
        [Key]
        public int ComicBookId { get; set; }
        public int IssueNo { get; set; }
        public string SeriesTitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
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