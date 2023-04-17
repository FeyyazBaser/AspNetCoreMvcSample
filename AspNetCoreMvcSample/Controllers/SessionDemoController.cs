using AspNetCoreMvcSample.Entities;
using AspNetCoreMvcSample.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcSample.Controllers
{
    public class SessionDemoController : Controller
    {
        public string SetSessions()
        {
            HttpContext.Session.SetInt32("age", 28);
            HttpContext.Session.SetString("name", "Feyyaz Başer");
            HttpContext.Session.SetObject("student", new Student { FirstName = "Feyyaz", LastName = "Başer", Email = "feyaz12@hotmail.com" });
            return "Session setted";
        }

        public string GetSessions()
        {

            return string.Format("Welcome {0},You are {1} , Student is {2} ",HttpContext.Session.GetString("name"),HttpContext.Session.GetInt32("age"), HttpContext.Session.GetObject<Student>("student").FirstName);
        }
    }
}
