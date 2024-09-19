using ComicBookGallery.Models;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
