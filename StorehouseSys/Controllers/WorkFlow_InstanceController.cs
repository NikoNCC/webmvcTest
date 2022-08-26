
using IBLL;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Entiy.Tools;
using Entiy.Dtos;
using System.Collections.Generic;

namespace StorehouseSys.Controllers
{
    public class WorkFlow_InstanceController : Controller
    {

        /// <summary>
        /// 构造
        /// </summary>
        IWorkFlow_InstanceBll _IWorkFlow_InstanceBll;
        public WorkFlow_InstanceController(IWorkFlow_InstanceBll iWorkFlow_InstanceBll)
        {
            _IWorkFlow_InstanceBll = iWorkFlow_InstanceBll;
        }

        public IActionResult WorkFlow_InstanceView()
        {
            return View();
        }

        public IActionResult AddWorkFlow_InstanceView() => View();



        /// <summary>
        /// 展示
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IActionResult GetWorkFlow_Instance(int page, int limit)
        {
            AjaxResult res = new AjaxResult();
            int count;
            var list = _IWorkFlow_InstanceBll.GetWorkFlow_Instance(page, limit, out count);

            res.code = 0;
            res.Data = list;
            res.Ses = true;
            res.Msg = "工作表实例数据";

            return Json(res);

        }
        /// <summary>
        /// 添加页面下拉框
        /// </summary>
        /// <returns></returns>
        public IActionResult AddWorkFlow_InstanceOptins()
        {
            AjaxResult res = new AjaxResult();
            var selectslist = _IWorkFlow_InstanceBll.AddWorkFlow_InstanceOptins();
            if (selectslist != null)
            {
                res.code = 0;
                res.Data = selectslist;
                res.Ses = true;
            }

            return Json(res);

        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public IActionResult AddWorkFlow_Instance(string modelId,string description,string outNum,string consumableId, string Reason)
        {
            return null;
        }
    }
}
