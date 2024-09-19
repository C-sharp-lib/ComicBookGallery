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
    }
}