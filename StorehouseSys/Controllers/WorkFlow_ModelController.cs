using Entiy;
using Entiy.Tools;
using IBLL;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StorehouseSys.Controllers
{
    public class WorkFlow_ModelController : Controller
    {
        IWorkFlow_ModelBll _IWorkFlow_ModelBll;
        public WorkFlow_ModelController(IWorkFlow_ModelBll workFlow_Model)
        {
            _IWorkFlow_ModelBll = workFlow_Model;
        }


        /// <summary>
        /// 展示
        /// </summary>
        /// <returns></returns>
        public IActionResult WorkFlow_ModelView()
        {
            return View();
        }
        /// <summary>
        /// 添加页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddWorkFlow_ModelView()
        {
            return View();
        }

        /// <summary>
        ///修改工作流模板
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateWorkFlow_ModelView() => View();

        /// <summary>
        /// 获取工作流模板
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetWorkFlow_Model(string title)
        {

            AjaxResult res = new AjaxResult();
            List<WorkFlow_Model> workFlow_ModelList = _IWorkFlow_ModelBll.GetWorkFlow_ModelList();
            //搜索重载
            if (title != null)
            {
                workFlow_ModelList = workFlow_ModelList.Where(a => a.Title.Contains(title)).ToList();

            }
            res.code = 0;
            res.Data = workFlow_ModelList;
            res.Ses = true;
            res.Msg = "工作流模板数据";
            return Json(res);
        }

        /// <summary>
        ///添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddWorkFlow_Model(string title, string description)
        {
            AjaxResult res = new AjaxResult();

            //数据校验
            if (string.IsNullOrEmpty(title))
            {
                res.Msg = "标题不能为空";
                return Json(res);
            }
            if (string.IsNullOrEmpty(description))
            {
                res.Msg = "描述不能为空";
                return Json(res);
            }
            string msg;
            bool result = _IWorkFlow_ModelBll.AddWorkFlow_Model(title, description, out msg);

            res.Msg = msg;
            res.code = 0;
            res.Ses = result;

            return Json(res);
        }

        /// <summary>
        /// 获取修改模板数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetWorkFlow_ModelById(string id)
        {
            AjaxResult res = new AjaxResult();
            if (string.IsNullOrEmpty(id))
            {
                res.Msg = "选中的模板为空";
                return Json(res);
            }

            string msg;
            WorkFlow_Model workFlow_Model = _IWorkFlow_ModelBll.GetWorkFlow_ModelListById(id, out msg);
            res.code = 0;
            res.Data = workFlow_Model;
            res.Msg = msg;
            res.Ses = true;
            return Json(res);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateWorkFlow_Model(string title, string description, string id)
        {
            AjaxResult res = new AjaxResult();
            //数据校验
            if (string.IsNullOrEmpty(title))
            {
                res.Msg = "标题不能为空";
                return Json(res);

            }

            string msg;
            //修改
            bool result = _IWorkFlow_ModelBll.UpdateWorkFlow_Model(title, description, id, out msg);
            if (result)
            {
                res.code = 0;
                res.Ses = true;
                res.Msg = msg;
            }
            return Json(res);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IActionResult DeleteWorkFlow_Model(string[] ids)
        {
            AjaxResult res = new AjaxResult();
            if(ids.Length == 0)
            {
                res.Msg = "选中的模板不能为空";
                return Json(res);

            }
            string msg;
            bool result = _IWorkFlow_ModelBll.DeleteWorkFlow_Model(ids, out msg);
            if (result)
            { 
                res.code=0;
                res.Ses = true;
                res.Msg=msg;
            }
            return Json(res);
         }
    }
}
