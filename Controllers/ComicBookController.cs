using ComicBookGallery.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ComicBookGallery.Controllers
{
    public class ComicBookController : Controller
    {
        private readonly ILogger<ComicBookController> _logger;
        private readonly ComicBookGalleryContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ComicBookController(ILogger<ComicBookController> logger, ComicBookGalleryContext context, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {

            var comicBooks = _context.ComicBook
                .Include(cb => cb.ComicBookAuthors).ThenInclude(ca => ca.Author)
                .Include(cb => cb.ComicBookPublishers).ThenInclude(cp => cp.Publisher)
                .ToList();
            return View(comicBooks);
        }

        public IActionResult GetAuthors()
        {
            var comicBookAuthors = _context.Author
                .Include(ca => ca.ComicBookAuthors).ThenInclude(ca => ca.ComicBook)
                .ToList();
            return View(comicBookAuthors);
        }

        [HttpGet("ComicBookDetails/{id}")]
        public IActionResult ComicBookDetails(int id)
        {
            var comicBook = _context.ComicBook
                .Include(cb => cb.ComicBookAuthors).ThenInclude(ca => ca.Author)
                .Include(cp => cp.ComicBookPublishers).ThenInclude(cp => cp.Publisher)
                .FirstOrDefault(cb => cb.ComicBookId == id);
            ViewBag.ImageUrl = "~/img/" + comicBook?.ImageUrl + ".jpg";
            if (comicBook == null)
            {
                return NotFound();
            }
            return View(comicBook);
        }


        [HttpGet("AuthorDetails/{id}")]
        public IActionResult AuthorDetails(int id)
        {
            var author = _context.Author
                .Include(cb => cb.ComicBookAuthors).ThenInclude(cb => cb.ComicBook)
                .FirstOrDefault(cb => cb.AuthorId == id);
            ViewBag.ImageUrl = "~/img/ProfileImages/" + author?.ImageUrl + ".jpg";
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }


        [HttpGet("PublisherDetails/{id}")]
        public IActionResult PublisherDetails(int id)
        {
            var publisher = _context.Publisher
                .Include(cp => cp.ComicBookPublishers).ThenInclude(cp => cp.ComicBook)
                .FirstOrDefault(cb => cb.PublisherId == id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
