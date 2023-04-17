using AspNetCoreMvcSample.Entities;
using AspNetCoreMvcSample.Helpers;
using AspNetCoreMvcSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreMvcSample.Controllers
{
    public class EmployeeController : Controller
    {
        private ICalculate _calculate;

        public EmployeeController(ICalculate calculate)
        {
            _calculate = calculate;
        }
        public IActionResult Add()  // Burdaki action ismi view ismiyle aynı olmalıdır
        {
            var employeeAddViewModel = new EmployeeAddViewModel
            {
                Employee = new Employee(),
                Cities = new List<SelectListItem>
                {
                    new SelectListItem {Text="Ankara",Value="06"},
                    new SelectListItem {Text="İstanbul",Value="34"},
                    new SelectListItem {Text="İzmir",Value="35"}
                }
            };
            return View(employeeAddViewModel);
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            return View();
        }
        public decimal Calculate()
        {
           return _calculate.Calculate(150);
        }
    }
}
