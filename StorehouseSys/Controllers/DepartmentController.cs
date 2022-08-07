using Bll;
using Entiy;
using Entiy.Dtos;
using Entiy.Tools;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace StorehouseSys.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentInfoBll _departmentInfoBll;
        public DepartmentController(IDepartmentInfoBll departmentInfoBll)
        {
            _departmentInfoBll = departmentInfoBll;
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
        public IActionResult GetDepartment(string departmentName,int page, int limit)
        {

            List<DepartmentInfoDtos> departmentInfoDtos = _departmentInfoBll.GetDepartment();
            if (departmentName!= null)
            {
                departmentInfoDtos= departmentInfoDtos.Where(a => a.DepartmentName.Contains(departmentName)).ToList();
            }
            //判断用户是否删除
            departmentInfoDtos = departmentInfoDtos.Where(a => a.IsDelete == false).Skip((page - 1) * limit).Take(limit).ToList();
            int Count = departmentInfoDtos.Count;
            return Json(new
            {
                Data = departmentInfoDtos,
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
        /// 修改用户
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
        /// 添加功能
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
    }
}
