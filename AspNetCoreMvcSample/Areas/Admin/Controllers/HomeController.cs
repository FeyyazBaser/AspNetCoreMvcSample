using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcSample.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]   // https://localhost:7184/admin ile gidilebilir 
        public IActionResult Index()  
        {
            return View();
        }
    }
}
