using Entity;
using Entiy.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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
        bool UploadConsumableInfo(IFormFile formFile, string userId, out string msg);
        FileStream OutOfStockBll();
    }
}
