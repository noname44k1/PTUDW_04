using Microsoft.AspNetCore.Mvc;
using PTUDW_04.Models;

namespace PTUDW_04.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly HarmicContext _context;

        public BlogViewComponent(HarmicContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbBlogs.Where(m => (bool)m.IsActive).OrderByDescending(m=>m.BlogId).Take(5).ToList();
            ViewBag.blogComment = _context.TbBlogComments.Where(m=>(bool)m.IsActive).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
