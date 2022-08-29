using Bll;
using Comm;
using Entiy.Tools;
using IBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StorehouseSys.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 注册BLL
        /// </summary>
        IUserInfoBLL _userInfoBLL;

        public LoginController(IUserInfoBLL userInfoBLL)
        {
            _userInfoBLL = userInfoBLL;
        }

       /// <summary>
       /// 登录页面
       /// </summary>
       /// <returns></returns>
        public IActionResult LoginView()
        {
            return View();
        }
        /// <summary>
        /// 登录功能
        /// </summary>
        /// <param name="account"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(string account, string passWord)
        {
            if (string.IsNullOrEmpty(account))
            {
                return Json(new AjaxResult { 
                
                    Msg = "账号不能为空",
                });
            }
            if (string.IsNullOrEmpty(passWord))
            {
                return Json(new AjaxResult
                {

                    Msg = "密码不能为空",
                });
            }
            string msg;
            string userName;
            string Id;
            bool result = _userInfoBLL.Login(account, passWord, out msg, out userName, out Id);
            if (result)
            {
                HttpContext.Session.SetString("UserName", userName);
                HttpContext.Session.SetString("Id", Id);
                return Json(new AjaxResult
                {
                    code = 200,
                    Msg = msg,
                    Data= new {
                        userName,
                        Id
                    },
                    Ses = true,

                });
                
            }
            else {

                return Json(new AjaxResult
                {
                    Msg = msg,

                });

            }
        }
    }
}
