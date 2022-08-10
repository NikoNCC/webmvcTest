using Bll;
using Entiy;
using Entiy.Dtos;
using Entiy.Tools;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using StorehouseSys.Models.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace StorehouseSys.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentInfoBll _departmentInfoBll;
        IUserInfoBLL _userInfoBLL;
        public DepartmentController(IDepartmentInfoBll departmentInfoBll, IUserInfoBLL iUserInfoBll)
        {
            _departmentInfoBll = departmentInfoBll;
            _userInfoBLL = iUserInfoBll;
        }
        /// <summary>
        /// 检查功能
        /// </summary>
        /// <param name="DepartmentInfoDtos"></param>
        /// <returns></returns>
        public AjaxResult ChackData(DepartmentInfoDtos DepartmentInfoDtos)
        {

            if (string.IsNullOrEmpty(DepartmentInfoDtos.DepartmentName))
            {
                return new AjaxResult
                {

                    Msg = "部门名称不能为空",

                };
            }
            return new AjaxResult
            {

                code = 0
            };

        }


        //---------------视图---------------
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpdateDepartmentView()
        {
            return View();
        }
        public IActionResult AddDepartmentView()
        {
            return View();
        }




        //-----------------功能----------------
        /// <summary>
        /// 获取部门数据
        /// </summary>
        /// <returns></returns>
        /// <param departmentName="部门名字"></param>
        public IActionResult GetDepartment(string departmentName,int page, int limit)
        {

            IQueryable<DepartmentInfoDtos> departmentInfoDtos = _departmentInfoBll.GetDepartment();

            if (departmentName!= null)
            {
                departmentInfoDtos= departmentInfoDtos.Where(a => a.DepartmentName.Contains(departmentName));
            }
            //判断部门是否删除
           List<DepartmentInfoDtos> departmentInfos = departmentInfoDtos.Where(a => a.IsDelete == false).Skip((page - 1) * limit).Take(limit).ToList();
            int Count = departmentInfos.Count;
            return Json(new
            {
                Data = departmentInfos,
                code = 0,
                Msg = "部门数据",
                count = Count,

            });
        }
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IActionResult DalDepartment(string[] ID)
        {

            bool result = _departmentInfoBll.DalDepartment(ID);
            if (result)
            {
                return Json(new AjaxResult
                {
                    code = 0,
                    Msg = "删除成功"
                });
            }
            return Json(new AjaxResult
            {

                Msg = "删除失败"
            });


        }

        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IActionResult UpdateDepartment(DepartmentInfoDtos departmentInfoDtos)
        {
            bool result = _departmentInfoBll.UpdateDepartment(departmentInfoDtos);
            if (result)
            {
                return Json(new AjaxResult
                {
                    code = 0,
                    Ses = true,
                    Msg = "修改成功"
                });

            }
            else {
                return Json(new AjaxResult
                {

                    Msg = "删除失败"
                });
            }
           
        }
        /// <summary>
        /// 获取选中部门数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetDepartmentById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Json(new AjaxResult
                {

                    Msg = "选中的用户不能为空",

                });

            }
            DepartmentInfoDtos departmentInfoDto = _departmentInfoBll.GetDepartmentById(id);
            if (departmentInfoDto != null)
            {
                return Json(new AjaxResult
                {

                    Msg = "选中的用户数据",
                    Data = departmentInfoDto
                });
            }
            return Json(new AjaxResult
            {

                Msg = "选中的用户不存在",

            });
        }
        /// <summary>
        /// 添加部门功能
        /// </summary>
        /// <param name="departmentInfoDtos"></param>
        /// <returns></returns>
        public IActionResult AddDepartment(DepartmentInfoDtos departmentInfoDtos)
        {
            AjaxResult Res = ChackData(departmentInfoDtos);
            if (Res.code != 0)
            {
                return Json(Res);

            }
            bool result=  _departmentInfoBll.AddDepartment(departmentInfoDtos);
            if (result)
            {
                return Json(new AjaxResult
                {
                    code =0,
                    Msg = "添加成功",
                    Ses=true,
                });
             }
            return Json(new AjaxResult
            {

                Msg = "添加失败",

            });
        }
        /// <summary>
        /// 添加页面下拉框
        /// </summary>
        /// <returns></returns>
        public IActionResult GetUserInfo()
        {

            var UserName = _userInfoBLL.GetUserInfos().Where(a => a.IsAdmin=="是").Select(a => new
            {
                    Title= a.UserName,
                    Value =a.Id,
            }
            ).ToList();
           var DepartmentName = _departmentInfoBll.GetDepartment().Where(u => u.IsDelete == false).Select(u => new
                {
               Title =  u.DepartmentName,
               Value =  u.Id,
                }).ToList();

            return Json(new AjaxResult
            {
                Msg = "下拉框数据",
                Data = new {
                    UserName,
                    DepartmentName
                },
                Ses=true,
            }) ;
        }
    }
}
