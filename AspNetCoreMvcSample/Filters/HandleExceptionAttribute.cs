using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AspNetCoreMvcSample.Filters
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public string ViewName { get; set; } = "Error";
        public Type ExceptionType { get; set; } = null;
        public override void OnException(ExceptionContext context)
        {
            if (ExceptionType != null)
            {
                if (context.Exception.GetType() == ExceptionType) // uygulamanın fırlattığı hata ile attribute e yazdığımız hata aynı olursa
                {
                    var result = new ViewResult { ViewName = ViewName };
                    var modelDataProvider = new EmptyModelMetadataProvider();
                    result.ViewData = new ViewDataDictionary(modelDataProvider, context.ModelState);
                    result.ViewData.Add("HandleException", context.Exception);
                    context.Result = result;
                    context.ExceptionHandled = true;
                }
            }
           
        }
    }
}
