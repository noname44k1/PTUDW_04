using Microsoft.AspNetCore.Mvc;

namespace PTUDW_04.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
