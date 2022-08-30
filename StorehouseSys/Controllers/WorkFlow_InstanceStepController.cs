using Entiy;
using Entiy.Dtos;
using Entiy.Tools;
using IBLL;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StorehouseSys.Controllers
{
    public class WorkFlow_InstanceStepController : Controller
    {
        IWorkFlow_InstanceStepBll _IWorkFlow_InstanceStepBll;
        public WorkFlow_InstanceStepController(IWorkFlow_InstanceStepBll iWorkFlow_InstanceStepBll)
        {
            _IWorkFlow_InstanceStepBll = iWorkFlow_InstanceStepBll;
        }





        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public IActionResult WorkFlow_InstanceStepView()
        {
            return View();
        }
        /// <summary>
        /// 审核页面
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateWorkFlow_InstanceStepView() => View();
















        //-----------------------------------------

        /// <summary>
        /// 展示
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetWorkFlow_InstanceStepList(string title,int page, int limit)
        {

            AjaxResult res = new AjaxResult();
            string userId = HttpContext.Session.GetString("Id");
            int count;
            List<WorkFlow_InstanceStepDtos> workFlow_InstanceStepList = _IWorkFlow_InstanceStepBll.GetWorkFlow_InstanceStepList(page, limit, userId, out count);

            if (title != null)
            {
                workFlow_InstanceStepList = workFlow_InstanceStepList.Where(a => a.Title.Contains(title)).ToList();
            }

            if (workFlow_InstanceStepList != null)
            {
                return Json(new
                {
                    Data = workFlow_InstanceStepList,
                    code = 0,
                    Ses = true,
                    Msg = "工作流步骤数据",
                    Count = count
                });

            }

            return Json(res);

        }

        /// <summary>
        /// 获取要审核数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetWorkFlow_InstanceStepById(string id)
        {
            AjaxResult res = new AjaxResult();
            string msg;
            if (string.IsNullOrEmpty(id))
            {
                res.Msg = "选中的数据不能为空";
                return Json(res);
            }

            WorkFlow_InstanceStepDtos workFlow = _IWorkFlow_InstanceStepBll.GetWorkFlow_InstanceStepById(id, out msg);

            if (workFlow != null)
            {
                res.code = 0;
                res.Data = workFlow;
                res.Ses = true;
                res.Msg = msg;
            }

            return Json(res);
        }
        /// <summary>
        /// 申请步骤
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reviewReason"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public IActionResult UpdateWorkFlow_InstanceStep(string id, string reviewReason, WorkFlow_InstanceStepStatusEnum status)
        {
            AjaxResult res = new AjaxResult();
            string msg;
            if (string.IsNullOrEmpty(id))
            {
                res.Msg = "选中的步骤不能空";
                return Json(res);
            }
            if (string.IsNullOrEmpty(reviewReason))
            {
                res.Msg = "审核意见不能空";
                return Json(res);

            }
            if (status != WorkFlow_InstanceStepStatusEnum.同意 && status != WorkFlow_InstanceStepStatusEnum.驳回)
            {
                res.Msg = "审核参数有误";
                return Json(res);
            }
            string userId = HttpContext.Session.GetString("Id");
            bool result = _IWorkFlow_InstanceStepBll.UpdateWorkFlow_InstanceStep(id, reviewReason, status, userId, out msg);
            if (result)
            {
                res.code = 0;
              
                res.Ses = true;
            }
            res.Msg = msg;
            return Json(res);
        }
    }
}
