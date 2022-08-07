using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Comm
{
    public class LoginFiter : Attribute,IActionFilter
    {
        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //白名单
            ArrayList list = new ArrayList() { "/", "/LOGIN/LOGINVIEW", "/LOGIN/LOGIN"};
                 //比对输入路径的                                          //输入路径全部大写对标
            if (!list.Contains(context.HttpContext.Request.Path.ToString().ToUpper()))
            {
                string newUserName = context.HttpContext.Session.GetString("UserName");
                if (string.IsNullOrEmpty(newUserName))
                {
                    context.Result = new RedirectResult("/Login/LoginView");

                }

            }
            // Do something before the action executes.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
       

        }
    }
}
