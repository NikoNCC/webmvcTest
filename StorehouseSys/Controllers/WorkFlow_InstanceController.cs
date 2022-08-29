
using IBLL;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Entiy.Tools;
using Entiy.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

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
        [HttpGet]
        public IActionResult GetWorkFlow_Instance(int page, int limit)
        {
            AjaxResult res = new AjaxResult();
            int count;
            var list = _IWorkFlow_InstanceBll.GetWorkFlow_Instance(page, limit, out count);

            

            return Json(new
            {
                Count = count,
                Code = 0,
                Data = list,
                Ses = true,
                Msg = "工作表实例数据",
            });;

        }
        /// <summary>
        /// 添加页面下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet]
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
        [HttpPost]
        public IActionResult AddWorkFlow_Instance(string modelId, string description, int outNum, string consumableId, string Reason)
        {
            AjaxResult res = new AjaxResult();
            //数据校验
            if (string.IsNullOrEmpty(modelId))
            {
                res.Msg = "模板不能为空";
                return Json(res);
            }
            if (string.IsNullOrEmpty(description))
            {
                res.Msg = "描述不能为空";
                return Json(res);
            }
            if (string.IsNullOrEmpty(consumableId))
            {
                res.Msg = "耗材不能为空";
                return Json(res);
            }
            if (outNum <= 0)
            {
                res.Msg = "申请数量不正确";
                return Json(res);
            }

            //Session 当前登录人ID
            string userId = HttpContext.Session.GetString("Id");
            string msg;
            bool result = _IWorkFlow_InstanceBll.AddWorkFlow_Instance(modelId, description, outNum, consumableId, Reason, userId, out msg);

            if (result)
            {
                res.Msg = msg;
                res.code = 0;
                res.Ses = true;

            }
            return Json(res);
        }
    }
}
