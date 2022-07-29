using Bll;
using Entiy;
using Entiy.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StorehouseSys.Models;
using StorehouseSys.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StorehouseSys.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetUserInfos()
        {
            UserInfoBll userInfoBll = new UserInfoBll();
            var userInfos = userInfoBll.GetUserInfos();
            userInfos = userInfos.Where(a => a.IsDelete == false).ToList();
            return Json(new {
                code = 0,
                msg = "用户数据",
                count = userInfos.Count,
                data = userInfos,
            });
        }


        public IActionResult AddUserView()
        {
            return View();
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfoDtos"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUserInfos(UserInfoDtos userInfoDtos)
        {

            UserInfoBll userInfoBll = new UserInfoBll();
            bool result = userInfoBll.AddUserInfos(userInfoDtos);
            if (result)
            {
                return Json(new AjaxResult
                {
                    code = 0,
                    Msg = "添加成功",
                    Ses = true,
                });

            }
            else {
                return Json(new AjaxResult {
                    code = 500,
                    Msg = "添加失败",
                    Ses = false,
                });
            }

        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DelUserInfo(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                return Json(new AjaxResult
                {
                    
                    Msg = "选中的用户不存在",
                   
                });
            }
            UserInfoBll userInfoBll = new UserInfoBll();
            bool result = userInfoBll.DelUserInfo(ID);
            if (result)
            {
                return Json(new AjaxResult
                {
                    code = 0,
                    Msg = "删除成功",
                    Ses = true,
                });

            }
            else
            {
                return Json(new AjaxResult
                {
                    code = 500,
                    Msg = "删除失败",
                    
                });
            }
        }
    }
}
