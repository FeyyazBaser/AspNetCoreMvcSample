using AspNetCoreMvcSample.Entities;
using AspNetCoreMvcSample.Filters;
using AspNetCoreMvcSample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace AspNetCoreMvcSample.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public string Index()
        {
            return "Projemize Hoşgeldiniz";
        }

        [HandleException(ViewName = "DivideByZeroError", ExceptionType =typeof(DivideByZeroException))]
        [HandleException(ViewName = "Error", ExceptionType = typeof(SecurityException))] // hata türüne göre 1den fazla da yazılabilir
        public ViewResult Index2()
        {
            throw new SecurityException();
            return View();
        }

        public ViewResult Index3()
        {
  
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee { Id = 1, FirstName = "Feyyaz", LastName = "Başer", CityId = 06 });
            employees.Add(new Employee { Id = 2, FirstName = "Yusuf", LastName = "Başer", CityId = 55 });
            employees.Add(new Employee { Id = 3, FirstName = "Davut", LastName = "Başer", CityId = 71 });

            List<string> cities = new List<string>() { "İstanbul", "Ankara", "İzmir" };

            var model = new EmployeeListViewModel
            {
                Employees = employees,
                cities = cities
            };

            return View(model);
        }


        public IActionResult Index4()
        {
            return StatusCode(200);
        }

        public IActionResult Index5()
        {
            return BadRequest();
        }
        public RedirectResult Index6()
        {
            return Redirect("/Home/Index3");
        }
        public IActionResult Index7()
        {
            return RedirectToAction("Index2");
        }

        public JsonResult Index8()
        {
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee { Id = 1, FirstName = "Feyyaz", LastName = "Başer", CityId = 06 });
            employees.Add(new Employee { Id = 2, FirstName = "Yusuf", LastName = "Başer", CityId = 55 });
            employees.Add(new Employee { Id = 3, FirstName = "Davut", LastName = "Başer", CityId = 71 });

            return Json(employees);
        }

        public JsonResult Index9(string key)
        {
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee { Id = 1, FirstName = "Feyyaz", LastName = "Başer", CityId = 06 });
            employees.Add(new Employee { Id = 2, FirstName = "Yusuf", LastName = "Başer", CityId = 55 });
            employees.Add(new Employee { Id = 3, FirstName = "Davut", LastName = "Başer", CityId = 71 });

            if (string.IsNullOrEmpty(key))
                return Json(employees);

            var result = employees.Where(x => x.FirstName.ToLower().Contains(key));   // /home/index9?key=a querystring ile arama

            return Json(result);
        }

        public ViewResult Employee()
        {
            return View();
        }


    }
}



// http://feyyazbaser.com/home/index 
// HomeController home =new HomeController();  // böyle çalışır...
// home.Index();
