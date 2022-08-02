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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StorehouseSys.Controllers
{
    public class HomeController : Controller
    {



        /// <summary>
        /// 添加数据校验
        /// </summary>
        /// <returns></returns>
        public AjaxResult ChackData(UserInfoDtos userInfoDtos)
        {
            if (string.IsNullOrEmpty(userInfoDtos.UserName))
            {
                return new AjaxResult {
                   
                    Msg = "用户名不能为空",

                };
            }
            if (string.IsNullOrEmpty(userInfoDtos.Account))
            {
                return new AjaxResult
                {

                    Msg = "账号不能为空",

                };
            }
            if (string.IsNullOrEmpty(userInfoDtos.PassWord)) {           
                return new AjaxResult
                {
                    
                    Msg = "密码不能为空",

                };
            }
            if (!Regex.IsMatch(userInfoDtos.PhoneNum, @"^[1]+\d{10}"))
            {
                return new AjaxResult
                {

                    Msg = "手机号码格式错误",

                };

            }

            return new AjaxResult {
                
                code = 0
            };

        }

        //-----------------------------页面----------------------------
        //主页
        public IActionResult Index()
        {
            return View();
        }
        //用户管理页面
        public IActionResult Privacy()
        {
            return View();
        }
        //添加页面
        public IActionResult AddUserView()
        {
            return View();
        }
        //修改页面
        public IActionResult UpdateUserView()
        {
            return View();
        }



        UserInfoBll userInfoBll = new UserInfoBll();


        //-------------------------------功能---------------------------
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetUserInfos(string UserName,int page,int limit)
        {
            UserInfoBll userInfoBll = new UserInfoBll();
            var userInfos = userInfoBll.GetUserInfos();
            int Count = userInfos.Count;
            //判断用户是否删除
            userInfos = userInfos.Where(a => a.IsDelete == false).Skip((page - 1) * limit).Take(limit).ToList();
            
            
            //查询用户名
            if (!string.IsNullOrEmpty(UserName))
            {
                userInfos = userInfos.Where(a => a.UserName.Contains(UserName)).ToList();
            }

            return Json(new {
                code = 0,
                msg = "用户数据",
                count =Count,
                data = userInfos,
            });
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfoDtos"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUserInfos(UserInfoDtos userInfoDtos)
        {
            AjaxResult Result = new AjaxResult();
            Result = ChackData(userInfoDtos);

            if (Result.code != 0)
            {
                return Json(Result);
                
            }
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
        public IActionResult DelUserInfo(string[] IdList)
        {
            if (IdList == null)
            {
                return Json(new AjaxResult
                {
                    
                    Msg = "选中的用户不存在",
                   
                });
            }
            UserInfoBll userInfoBll = new UserInfoBll();
            bool result = userInfoBll.DelUserInfo(IdList);
            if (result)
            {
                return Json(new AjaxResult
                {
                    code = 0,
                    Msg = "删除成功",
                    Ses = true,
                });

            }            
                return Json(new AjaxResult
                {
                    code = 500,
                    Msg = "删除失败",
                    
                });
        }


        /// <summary>
        /// 查询修改用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserInfoById(string id)
        {


            if (string.IsNullOrEmpty(id))
            {
                return Json(new AjaxResult
                {

                    Msg = "选中的用户不存在",

                });
            }
            UserInfoDtos userInfo = userInfoBll.GetUserInfoById(id);
             if(userInfo != null)
            {
                return Json(new AjaxResult
                {
                    code = 0,
                    Msg = "查询成功",
                    Ses = true,
                    Data = userInfo
                });

            }
            return Json(new AjaxResult
            {
                code = 500,
                Msg = "查询失败",

            });
        }

        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="userInfoDtos"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateUserInfo(UserInfoDtos userInfoDtos)
        {
            if (userInfoDtos == null)
            {
                return Json(new AjaxResult
                {

                    Msg = "选中的用户不存在",

                });
            }


            bool result =userInfoBll.UpdateUserInfo(userInfoDtos);
            if (result)
            {
                return Json(new AjaxResult
                {
                    code = 0,
                    Msg = "修改成功",
                    Ses = true,
                });

            }

            return Json(new AjaxResult
            {
                code = 500,
                Msg = "查询失败",

            });


        }
    }
}
