using AspNetCoreMvcSample.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreMvcSample.Models
{
    public class EmployeeAddViewModel
    {
        public Employee Employee { get; set; }
        public List<SelectListItem> Cities { get; internal set; }

        public List<Employee> Employees = new List<Employee>();
       

    }
}