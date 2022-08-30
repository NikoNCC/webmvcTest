using Entity;
using Entiy.Tools;
using IBLL;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Entiy;
using Entiy.Dtos;
using Microsoft.AspNetCore.Http;
using Bll;
using System.IO;

namespace StorehouseSys.Controllers
{
    public class ConsumableInfoController : Controller
    {
        IConsumableInfoBll _IConsumableInfoBll;
        public ConsumableInfoController(IConsumableInfoBll iConsumableInfoBll)
        {
            _IConsumableInfoBll = iConsumableInfoBll;
        }
        public IActionResult ConsumableInfoView()
        {
            return View();
        }

        public IActionResult AddConsumableInfoView()
        {
            return View();
            }

        public IActionResult UpdateConsumableInfoView() => View();
       
        /// <summary>
        /// 获取耗材信息
        /// </summary>
        /// <param name="ConsumableName"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetConsumableInfos(string ConsumableName, int page, int limit)
        {
            
            AjaxResult res = new AjaxResult();
            List<ConsumableInfo> consumableInfos = _IConsumableInfoBll.GetConsumableInfos();
            int Count = consumableInfos.Count;
            if (!string.IsNullOrEmpty(ConsumableName))
            {
                consumableInfos = _IConsumableInfoBll.GetConsumableInfos().Where(x => x.ConsumableName == ConsumableName).ToList();
            }
            consumableInfos = consumableInfos.Where(a => a.IsDelete == false).Skip((page - 1) * limit).Take(limit).ToList();
            res.code = 0;
            res.Data = consumableInfos;
            res.Ses = true;
            res.Msg = "耗材数据";
            return Json(res);
        }
        /// <summary>
        /// 添加耗材
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddConsumableInfo(ConsumableInfoDtos consumableInfoDtos)
        {
            AjaxResult res = new AjaxResult();
           string msg;
           bool result = _IConsumableInfoBll.AddConsumableInfo(consumableInfoDtos,out msg);
            if (result)
            { 
                res.code = 0;
               
                res.Ses = true;
            }
            res.Msg = msg;
            return Json(res);
        }
        /// <summary>
        /// 获取下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCategoryOptions()
        {
            AjaxResult res = new AjaxResult();
            List<Category> list = _IConsumableInfoBll.GetCategoryOptions();
            if (list.Count > 0)
            {
                res.code = 0;
                res.Msg = "下拉框数据";
                res.Ses = true;
                res.Data =list;
            }
            return Json(res);
        }

        /// <summary>
        /// 获取修改数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUpdateConsumableInfo(string id)
        {
             AjaxResult res = new AjaxResult();
            string msg;
            ConsumableInfo consumableInfo = _IConsumableInfoBll.GetUpdateConsumableInfo(id,out msg);
            List<Category> options = _IConsumableInfoBll.GetCategoryOptions();
            if (consumableInfo != null)
            {
                res.code = 0;
                res.Data = new { consumableInfo , options };
                res.Ses = true;
            }

            res.Msg = msg;
            return Json(res);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="consumableInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateConsumableInfo(ConsumableInfo consumableInfo)
        {
            AjaxResult res = new AjaxResult();
            string msg;
            //修改
            bool result = _IConsumableInfoBll.UpdateConsumableInfo(consumableInfo, out msg);
         
            //结果判断
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
        public IActionResult DeleteConsumableInfo(string[] ids)
        {
            AjaxResult res = new AjaxResult();
            string msg;
            //删除
            bool result = _IConsumableInfoBll.DeleteConsumableInfo(ids, out msg);
            if (result)
            { 
                res.code=0;
                res.Ses = true;
               
            }
            res.Msg = msg;
            return Json(res);
        }

        /// <summary>
        /// 上传文件耗材入库
        /// </summary>
        /// <returns></returns>
        public IActionResult Upload(IFormFile formFile)
        {
            AjaxResult res = new AjaxResult();
            // 获取到当前登录用户Id
            string userId = HttpContext.Session.GetString("Id");

            if (string.IsNullOrEmpty(userId))
            {
                res.Msg = "登录已过期";
                return Json(res);
            }
            if (formFile == null)
            {
                res.Msg = "请选择excel文件上传";
                return Json(res);
            }
            string msg;
            bool result = _IConsumableInfoBll.UploadConsumableInfo(formFile, userId, out msg);

            if (result)
            {

                res.code = 0;
                res.Ses = true;
                
            }
            res.Msg = msg;

            return Json(res);
        }

        /// <summary>
        /// 耗材下载
        /// </summary>
        /// <returns></returns>
        public IActionResult DownLoad()
        {
           FileStream file = _IConsumableInfoBll.OutOfStockBll();
            return File(file, "application/octet-stream", "test.xlsx");
        }
    }
}
