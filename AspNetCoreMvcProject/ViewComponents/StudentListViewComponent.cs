using AspNetCoreMvcSample.Entities;
using AspNetCoreMvcSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AspNetCoreMvcSample.ViewComponents
{
    public class StudentListViewComponent : ViewComponent
    {
        private SchoolContext _schoolContext;
        public StudentListViewComponent(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }
        public ViewViewComponentResult Invoke(string filter)
        {
            filter = HttpContext.Request.Query["filter"];   // ViewComponent da query string ile çalışabilmek için yazmamız gerekiyor
            return View(new StudentListWiewModel
            {
                Students = _schoolContext.Students.Where(x => x.FirstName.ToLower().Contains(filter)).ToList()
            });
        }
    }
}
