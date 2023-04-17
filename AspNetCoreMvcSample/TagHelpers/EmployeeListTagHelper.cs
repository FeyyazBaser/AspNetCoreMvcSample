using AspNetCoreMvcSample.Entities;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace AspNetCoreMvcSample.TagHelpers
{
    [HtmlTargetElement("employee-list")]   // name
    public class EmployeeListTagHelper : TagHelper
    {
        private List<Employee> _employees;
        public EmployeeListTagHelper()
        {

            _employees = new List<Employee>();

            _employees.Add(new Employee { Id = 1, FirstName = "Feyyaz", LastName = "Başer", CityId = 06 });
            _employees.Add(new Employee { Id = 2, FirstName = "Yusuf", LastName = "Başer", CityId = 55 });
            _employees.Add(new Employee { Id = 3, FirstName = "Davut", LastName = "Başer", CityId = 71 });
        }
        private const string ListCountAttributeName = "count";  // parametre oluşturmak için oluşturulan değişkenin sonuna AttributeName eklenir
        [HtmlAttributeName(ListCountAttributeName)]
        public int ListCount { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "div";
            var query = _employees.Take(ListCount);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var employee in query)
            {
                stringBuilder.AppendFormat("<h2><a href='/employee/detail/{0}'>{1} {2}</a></h2>", employee.Id, employee.FirstName, employee.LastName);

            }
            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);
        }

    }
}
