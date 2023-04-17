using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcSample.Controllers
{
    public class CommonController : Controller
    {
        [Route("/error")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
