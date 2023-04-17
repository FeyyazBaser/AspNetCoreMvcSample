using AspNetCoreMvcSample.Entities;

namespace AspNetCoreMvcSample.Models
{
    public class EmployeeListViewModel
    {
        public List<Employee> Employees { get; set; }
        public List<string> cities { get; set; }
    }
}                                          