using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcSample.Controllers
{
    [Route("adminPanel")]  // Controller adı ile değil verdiğimiz route ile çalışır
    public class AdminController : Controller
    {
        [Route("")]  // ("") default route 
        [Route("Save")]
        [Route("~/Save")]  // Controlller adı vermeye gerek kalmadan https://localhost:7184/save bu şekilde çalışır
        public string Save()  
        {
            return "Saved";
        }
        [Route("Update")]
        public string Update()
        {
            return "Updated";
        }
        [Route("Delete/{id?}")]  // Route verirsek action adı ile çalışmıyor
        public string Delete(int id=0)
        {
            return string.Format("Deleted {0}", id.ToString()); 
        }
    }
}
