using Entity;
using Entiy.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBLL
{
    /// <summary>
    /// 耗材管理Bll接口
    /// </summary>
    public interface IConsumableInfoBll
    {
        bool AddConsumableInfo(ConsumableInfoDtos consumableInfoDtos,out string msg);
        bool DeleteConsumableInfo(string[] ids, out string msg);
        List<Category> GetCategoryOptions();
        List<ConsumableInfo> GetConsumableInfos();
        ConsumableInfo GetUpdateConsumableInfo(string id,out string msg);
        bool UpdateConsumableInfo(ConsumableInfo consumableInfo, out string msg);
    }
}
