using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comm
{
    public class LoginFiter : Attribute,IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("之前");
            // Do something before the action executes.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("之后");
            // Do something after the action executes.
        }
    }
}
