using Microsoft.AspNetCore.Mvc;

namespace CRMSystem.Client.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}