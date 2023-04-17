using AspNetCoreMvcSample.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcSample.Controllers
{
    public class FilterController : Controller
    {
        [CustomFilter]
        public IActionResult Index()
        {
            return View();
        }
    }
}
