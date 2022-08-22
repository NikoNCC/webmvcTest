using Entiy;
using Entiy.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBLL
{
    /// <summary>
    /// 菜单管理BLL接口
    /// </summary>
    public interface IMenuInfoBll
    {
        bool AddMenuInfo(MenuInfoDtos menuInfoDtos,out string msg);
        bool DelMenuInfo(string[] ids, out string msg);

        /// <summary>
        /// 获取菜单数据
        /// </summary>
        List<MenuInfo> GetMenuInfo();
        /// <summary>
        /// 获取修改菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        MenuInfo GetUpdateMenuInfo(string id,out string msg);
        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="menuInfoDtos"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool UpdateMenuInfo(MenuInfoDtos menuInfoDtos, out string msg);
    }
}
