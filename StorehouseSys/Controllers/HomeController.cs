using Bll;
using Comm;
using Entiy;
using Entiy.Tools;
using IBLL;
using Microsoft.AspNetCore.Http;
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
        IUserInfoBLL _userInfoBLL;
        IDepartmentInfoBll _departmentInfoBll;
        

        public HomeController(IUserInfoBLL userInfoBLL,IDepartmentInfoBll departmentInfoBll)
        {
            _userInfoBLL = userInfoBLL;
            _departmentInfoBll = departmentInfoBll;
        }

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
            if (string.IsNullOrEmpty(userInfoDtos.DepartmentId))
            {
                return new AjaxResult
                {

                    Msg = "部门不能为空",

                };
            }

            return new AjaxResult {
                
                code = 0
            };

        }

        //-----------------------------页面----------------------------
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 用户管理页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// 添加页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddUserView()
        {
            return View();
        }
        /// <summary>
        /// 修改页面
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateUserView()
        {
            return View();
        }
        /// <summary>
        /// 用户修改密码页面
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateUserPassWordView()
        {
            return View(); 
        }
        //普通用户修改基本信息
        public IActionResult UpdateUserBaseView()
        {
            return View();
        }




        //-------------------------------功能---------------------------
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserInfos(string UserName,int page,int limit)
        {
            List<UserInfoDtos> userInfos = _userInfoBLL.GetUserInfos();          
            //判断用户是否删除
            userInfos = userInfos.Where(a => a.IsDelete == false).Skip((page - 1) * limit).Take(limit).ToList();
            int Count = userInfos.Count;
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
           
            string msg;
            bool result = _userInfoBLL.AddUserInfos(userInfoDtos,out msg);
            
            if (result)
            {
                return Json(new AjaxResult
                {
                    code = 0,
                    Msg =msg,
                    Ses = true,
                });

            }
            else {
                return Json(new AjaxResult {
                    code = 500,
                    Msg = msg,
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
            string msg;
            bool result = _userInfoBLL.DelUserInfo(IdList,out msg);
            if (result)
            {
                return Json(new AjaxResult
                {
                    code = 0,
                    Msg = msg,
                    Ses = true,
                });

            }            
                return Json(new AjaxResult
                {
                    code = 500,
                    Msg = msg,
                    
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

                    Msg = "选中的用户不能为空",

                });
            }
            UserInfoDtos userInfo = _userInfoBLL.GetUserInfoById(id);
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


            bool result = _userInfoBLL.UpdateUserInfo(userInfoDtos);
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

        /// <summary>
        /// 添加用户下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departmentInfoDtos = _departmentInfoBll.GetDepartment().Where(u => u.IsDelete == false).Select(u => new
            {
                u.DepartmentName,
                u.Id,
            }).ToList();

            if (departmentInfoDtos.Count > 0)
            {
                return Json(new AjaxResult
                {
                    Ses = true,
                    Msg = "下拉框数据",
                    Data = departmentInfoDtos
                }); ;
            }
            return Json(new AjaxResult
            {
                Msg = "部门数据不存在",

            });
        }

        /// <summary>
        /// 用户修改密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateUserPassWord(string old_password, string new_password, string again_password)
        {
            //验证数据
           if(new_password != again_password)
            {
                return Json(new AjaxResult
                {
                    code = 400,
                    Msg = "两次密码不一致",
                    Ses = true
                });
            }
           if(string.IsNullOrEmpty(old_password))
            {
                return Json(new AjaxResult
                {
                    code = 400,
                    Msg = "旧密码不能为空",
                    Ses = true

                });
            }
            if (string.IsNullOrEmpty(new_password))
            {
                return Json(new AjaxResult
                {
                    code = 400,
                    Msg = "新密码不能为空",
                    Ses = true
                });
            }
            string userId = HttpContext.Session.GetString("Id");
            string msg;
            bool result = _userInfoBLL.UpdateUserPassWord(old_password,new_password,userId,out msg);
            if (result)
            {
                HttpContext.Session.Remove("UserName");
                return Json(new AjaxResult
                {
                    code = 200,
                    Msg = msg,
                    Ses = true
                });
            }
            return Json(new AjaxResult
            {
                code = 400,
                Msg = msg,
                Ses =true
            });
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExcludeLogin]
        public IActionResult ExitLogin()
        {
            HttpContext.Session.Remove("UserName");
            return Redirect("/Login/LoginView");
        }
    }
}
