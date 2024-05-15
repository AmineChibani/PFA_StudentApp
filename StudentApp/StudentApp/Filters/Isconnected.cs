using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Filters
{
    public class Isconnected : ActionFilterAttribute
    {
        //public string? Role { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Id") == null)
            {
                if (context.HttpContext.Session.GetString("Email") == null)
                {
                    context.Result = new RedirectResult("/Authentication/SignInBasic");
                }
                else
                {
                    context.Result = new RedirectResult("/Authentication/LockScreenBasic");
                }
               
            }
        }
    }
}
