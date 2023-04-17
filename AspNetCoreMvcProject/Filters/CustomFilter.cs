using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreMvcSample.Filters
{
    public class CustomFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)  // önce burası sonra View sonrada OnActionExecuted çalışır        
        {
            string message = "Executing...";
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string message = "Executed!..";
        }

       
    }
}
