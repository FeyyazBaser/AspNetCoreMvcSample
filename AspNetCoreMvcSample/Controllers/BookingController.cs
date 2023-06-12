using AspNetCoreMvcSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace AspNetCoreMvcSample.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
