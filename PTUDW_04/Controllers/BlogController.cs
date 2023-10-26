using Microsoft.AspNetCore.Mvc;
using PTUDW_04.Models;

namespace PTUDW_04.Controllers
{
    public class BlogController : Controller
    {
        private readonly HarmicContext _context;

        public BlogController(HarmicContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var blogs = _context.TbBlogs.Where(i => (bool)i.IsActive).OrderByDescending(i => i.BlogId).ToList();
            if (blogs == null)
            {
                return NotFound();
            }
            ViewBag.blogComment = _context.TbBlogComments.Where(m => (bool)m.IsActive).ToList();
            return View(blogs);
        }

        [Route("/blog/{alias}-{id}.html")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blog = _context.TbBlogs.Where(i => i.BlogId == id && (bool)i.IsActive).FirstOrDefault();
            ViewBag.blogComment = _context.TbBlogComments.Where(i=>i.BlogId == id && (bool)i.IsActive).ToList();
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }
    }
}
