using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Filters
{
    public class Isconnected : ActionFilterAttribute
    {
        public string? Role { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Id") == null)
            {
                context.Result = new RedirectResult("/Authentication/SignInBasic");
            }
            else if(context.HttpContext.Session.GetString("Role") != Role)
            {
                context.Result = new RedirectResult("/Error/Errors404Basic");
            }
        }
    }
}
