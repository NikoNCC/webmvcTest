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

       
        public IActionResult LoginView()
        {
            return View();
        }

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
            bool result = _userInfoBLL.Login(account,passWord,out msg,out userName);
            if (result)
            {
                HttpContext.Session.SetString("UserName", userName);
                return Json(new AjaxResult
                {
                    code = 200,
                    Msg = msg,
                    Data= userName,
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
