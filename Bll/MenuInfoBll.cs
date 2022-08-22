using Entiy;
using Entiy.Dtos;
using IBLL;
using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    /// <summary>
    /// 菜单管理BLL
    /// </summary>
    public class MenuInfoBll : IMenuInfoBll
    {
        IMenuInfoDal _iMenuInfoDal;
        public MenuInfoBll(IMenuInfoDal iMenuInfoDal)
        {
            _iMenuInfoDal = iMenuInfoDal;
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menuInfoDtos"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool AddMenuInfo(MenuInfoDtos menuInfoDtos, out string msg)
        {
            if (menuInfoDtos == null)
            {
                msg = "数据不能为空";
                return false;

            }
            MenuInfo menuInfo = new MenuInfo()
            {
                CreateTime = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
                Description = menuInfoDtos.Description,
                Href = menuInfoDtos.Href,
                Icon = menuInfoDtos.Icon,
                Level = menuInfoDtos.Level,
                ParentId = menuInfoDtos.ParentId,
                Sort = menuInfoDtos.Sort,
                Target = menuInfoDtos.Target,
                Title = menuInfoDtos.Title,
            };

            bool res = _iMenuInfoDal.AddEntity(menuInfo);
            if (res)
            {
                msg = "添加成功";
                return res;
            }
            else
            {
                msg = "添加失败";
                return res;
            }
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public bool DelMenuInfo(string[] ids, out string msg)
        {
            
            List<MenuInfo> menuInfolist = new List<MenuInfo>();
            foreach (var i in ids)
            {
                MenuInfo menuInfo = _iMenuInfoDal.FindEntity(i);
                if (menuInfo != null)
                {
                    menuInfo.IsDelete = true;
                    menuInfo.DeleteTime = DateTime.Now;
                    menuInfolist.Add(menuInfo);
                }
            }
            //将列表数据进行软删除
            if (_iMenuInfoDal.DelEntity(menuInfolist))
            {
                msg = "删除成功";
                return true;
            }
            else {

                msg = "删除失败";
                return false;
            }

            
        }

        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <returns></returns>
        public List<MenuInfo> GetMenuInfo()
        {
            return _iMenuInfoDal.GetEntity().ToList();
        }

        /// <summary>
        /// 获取修改菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MenuInfo GetUpdateMenuInfo(string id, out string msg)
        {
            MenuInfo menuInfo = _iMenuInfoDal.FindEntity(id);
            if (menuInfo == null)
            {
                msg = "查询不到此菜单";
                return null;
            }
            msg = menuInfo.Title;
            return menuInfo;
        }
        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="menuInfoDtos"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateMenuInfo(MenuInfoDtos menuInfoDtos, out string msg)
        {
            MenuInfo menuInfo = _iMenuInfoDal.FindEntity(menuInfoDtos.Id);
            if(menuInfo == null)
            {
                msg = "选中的菜单不存在";
                return false;
            }

            menuInfo.Description = menuInfoDtos.Description;
            menuInfo.Href = menuInfoDtos.Href;
            menuInfo.Icon = menuInfoDtos.Icon;
            menuInfo.Level = menuInfoDtos.Level;
            menuInfo.ParentId = menuInfoDtos.ParentId;
            menuInfo.Sort = menuInfoDtos.Sort;
            menuInfo.Target = menuInfoDtos.Target;
            menuInfo.Title = menuInfoDtos.Title;
            msg = "修改成功";
            return _iMenuInfoDal.UpdateEntiry(menuInfo);
        }
    }
}
