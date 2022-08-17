using Entiy;
using Entiy.Dtos;
using Entiy.Tools;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace StorehouseSys.Controllers
{
    public class RoleInfoController : Controller
    {
        IRoleInfoBll _IRoleInfoBll;
        IR_UserInfo_RoleInfoBll _IR_UserInfo_RoleInfoBll;
        public RoleInfoController(IRoleInfoBll iRoleInfoBll, IR_UserInfo_RoleInfoBll iR_UserInfo_RoleInfoBll)
        {
            _IRoleInfoBll = iRoleInfoBll;
            _IR_UserInfo_RoleInfoBll = iR_UserInfo_RoleInfoBll;
        }

        /// <summary>
        /// 角色管理主页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 角色添加页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddRoleInfoView()
        {
            return View();
        }

        /// <summary>
        /// 角色修改页面
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateRoleInfoView()
        {
            return View();
        }

        /// <summary>
        /// 添加角色绑定
        /// </summary>
        /// <returns></returns>
        public IActionResult AddUserInfo_RoleInfoView()
        {
            return View();
        }




        //--------------------------------------------功能-------------------------------


        /// <summary>
        /// 获取角色表数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IActionResult GetRoleInfo(string roleName, int page, int limit)
        {
            IQueryable<RoleInfoDtos> roleInfo = _IRoleInfoBll.GetRoleInfo();

            //搜索
            if (!string.IsNullOrEmpty(roleName))
            {
                roleInfo = roleInfo.Where(a => a.RoleName.Contains(roleName));
            }
            //分页
            List<RoleInfoDtos> roleInfos = roleInfo.Skip((page - 1) * limit).Take(limit).ToList();
            int Count = roleInfos.Count();
            return Json(new
            {
                Data = roleInfos,
                code = 0,
                Msg = "部门数据",
                count = Count,

            });
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DalRoleInfo(string[] IdList)
        {
            string msg;
            bool result = _IRoleInfoBll.DalRoleInfo(IdList, out msg);
            if (result)
            {
                return Json(
                    new AjaxResult {

                        code = 0,
                        Msg = msg,
                        Ses = true
                    });
            }
            return Json(
                    new AjaxResult
                    {

                        code = 400,
                        Msg = msg,
                        Ses = false
                    });

        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roleInfoDtos"></param>
        /// <returns></returns>
        public IActionResult AddRoleInfo(RoleInfoDtos roleInfoDtos)
        {
            if (string.IsNullOrEmpty(roleInfoDtos.RoleName))
            {
                return Json(new AjaxResult {

                    Msg = "角色名不能为空",
                });
            }

            string msg;
            bool res = _IRoleInfoBll.AddRoleInfo(roleInfoDtos, out msg);
            if (res)
            {
                return Json(
                    new AjaxResult
                    {

                        code = 0,
                        Msg = msg,
                        Ses = true
                    });
            }
            return Json(
                    new AjaxResult
                    {

                        code = 400,
                        Msg = msg,
                        Ses = false
                    });

        }


        /// <summary>
        /// 角色修改
        /// </summary>
        /// <param name="roleInfoDtos"></param>
        /// <returns></returns>
        public IActionResult UpdateRoleInfo(RoleInfoDtos roleInfoDtos) {

            string msg;
            bool res = _IRoleInfoBll.UpdateRoleInfo(roleInfoDtos, out msg);

            if (res)
            {
                return Json(
                    new AjaxResult
                    {

                        code = 0,
                        Msg = msg,
                        Ses = true
                    });
            }
            return Json(
                    new AjaxResult
                    {

                        code = 400,
                        Msg = msg,
                        Ses = false
                    });
        }


        /// <summary>
        /// 根据ID获取角色数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult GetRoleInfoById(string id)
        {
            RoleInfo roleInfo =_IRoleInfoBll.GetRoleInfoById(id);
            return Json(new AjaxResult
            {
                code = 0,
                Msg = "修改用户数据",
                Data = roleInfo,


            }); 
        }


        public IActionResult GetUser_Role() {
              _IR_UserInfo_RoleInfoBll.GetRoleInfo();
            return null;
        }
    }
    
}
