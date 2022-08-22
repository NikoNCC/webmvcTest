using Entiy;
using Entiy.Dtos;
using Entiy.Tools;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace StorehouseSys.Controllers
{
    public class MenuInfoController : Controller
    {
        IMenuInfoBll _iMenuInfoBll;

        public MenuInfoController(IMenuInfoBll iMenuInfoBll)
        {
            _iMenuInfoBll = iMenuInfoBll;
        }

        public IActionResult MenuInfoView()
        {
            return View();
        }


        public IActionResult AddMenuInfoView()
        {
            return View();
        }

        public IActionResult UpdateMenuInfoView()
        {
            return View();
        }







        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IActionResult GetMenuInfo(int page, int limit)
        {
            List<MenuInfo> menulist= _iMenuInfoBll.GetMenuInfo().Skip((page - 1) * limit).Take(limit).ToList(); ;

            int Count = menulist.Count();
            return Json(
            
                new
                {
                    Data = menulist,
                    code = 0,
                    Msg = "菜单数据",
                    count = Count,

                

            });
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        public IActionResult AddMenuInfo(MenuInfoDtos menuInfo)
        {
         AjaxResult result = new AjaxResult();

            if (menuInfo == null)
            {
                result.Msg = "不能为空";
            }
         string msg;
         //添加菜单
         bool res =  _iMenuInfoBll.AddMenuInfo(menuInfo,out msg);


            return Json(result);

        }

        /// <summary>
        /// 获取修改菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult GetUpdateMenuInfo(string id)
        {
            AjaxResult result = new AjaxResult();
            if (string.IsNullOrEmpty(id))
            {
                result.Msg = "选中菜单不能为空";
                return Json(result);
            }
            string msg;
            MenuInfo menuInfo = _iMenuInfoBll.GetUpdateMenuInfo(id,out msg);

            result.Msg= msg;
            result.Data = menuInfo;
            result.code = 0;
            result.Ses = true;
            return Json(result);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="menuInfoDtos"></param>
        /// <returns></returns>
        public IActionResult UpdateMenuInfo(MenuInfoDtos menuInfoDtos)
        {
            AjaxResult result = new AjaxResult();
            if (menuInfoDtos.Id == null)
            {
                result.Msg = "选中的菜单不能为空";
                return Json(result);
            }
            string msg;
            bool res = _iMenuInfoBll.UpdateMenuInfo(menuInfoDtos, out msg);

            result.Ses = true;
            result.code = 200;
            result.Msg = msg;
            return Json(result);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IActionResult DelMenuInfo(string[] ids)
        {
            string msg;
            bool res = _iMenuInfoBll.DelMenuInfo(ids, out msg);

            return Json(new AjaxResult {
                code = 0,
                Msg =msg,
                Ses =res,
            
            });

        }
    }
}
