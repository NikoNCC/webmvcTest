using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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

            Type type =  context.Controller.GetType();
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.DeclaredOnly;
            MethodInfo[] entity = type.GetMethods(bindingFlags);

            foreach (var i in entity)
            {
              
                bool b = i.IsDefined(typeof(ExcludeLoginAttribute), false);
                if (b)
                {
                    return;
                }
                string newUserName = context.HttpContext.Session.GetString("UserName");
                if (string.IsNullOrEmpty(newUserName))
                {
                    context.Result = new RedirectResult("/Login/LoginView");

                }

            }

            //白名单
            //ArrayList list = new ArrayList() { "/", "/LOGIN/LOGINVIEW", "/LOGIN/LOGIN"};
            //比对输入路径的                                          //输入路径全部大写对标
            //if (!list.Contains(context.HttpContext.Request.Path.ToString().ToUpper()))
            //{


            //}
            // Do something before the action executes.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
       

        }
    }
}
