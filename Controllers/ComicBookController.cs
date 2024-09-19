using ComicBookGallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ComicBookGallery.Controllers
{
    public class ComicBookController : Controller
    {
        private readonly ILogger<ComicBookController> _logger;
        private readonly ComicBookGalleryContext _context;

        public ComicBookController(ILogger<ComicBookController> logger, ComicBookGalleryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            var comicBooks = _context.ComicBook
                .Include(cb => cb.ComicBookAuthors).ThenInclude(ca => ca.Author)
                .Include(cb => cb.ComicBookPublishers).ThenInclude(cp => cp.Publisher)
                .ToList();
            return View(comicBooks);
        }
        [HttpGet("ComicBookDetails/{id}")]
        public IActionResult ComicBookDetails(int id)
        {
            var comicBook = _context.ComicBook
                .Include(cb => cb.ComicBookAuthors).ThenInclude(ca => ca.Author)
                .Include(cp => cp.ComicBookPublishers).ThenInclude(cp => cp.Publisher)
                .FirstOrDefault(cb => cb.ComicBookId == id);
            if (comicBook == null)
            {
                return NotFound();
            }
            return View(comicBook);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
