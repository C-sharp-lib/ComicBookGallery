using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicBookGallery.Models
{
    public class ComicBookViewModel
    {
        public int ComicBookId { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public ComicBook ComicBook { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
    }
}