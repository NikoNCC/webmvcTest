using Dal;
using Entity;
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
    /// 耗材管理Bll
    /// </summary>
    public class ConsumableInfoBll: IConsumableInfoBll
    {
        IConsumableInfoDal _IConsumableInfoDal;
        ICategoryDal _ICategoryDal;
        public ConsumableInfoBll(IConsumableInfoDal iConsumableInfoDal, ICategoryDal icategoryDal)
        {
            _IConsumableInfoDal = iConsumableInfoDal;
            _ICategoryDal = icategoryDal;
        }

        /// <summary>
        /// 添加耗材
        /// </summary>
        /// <param name="consumableInfoDtos"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AddConsumableInfo(ConsumableInfoDtos consumableInfoDtos,out string msg)
        {
            ConsumableInfo consumableInfo = new ConsumableInfo() { 
                Id = Guid.NewGuid().ToString(),
                CategoryId = consumableInfoDtos.CategoryId,
                ConsumableName =consumableInfoDtos.ConsumableName,
                CreateTime = DateTime.Now,
                Description = consumableInfoDtos.Description,
                Money =consumableInfoDtos.Money,
                Num =consumableInfoDtos.Num,
                Specification= consumableInfoDtos.Specification,
                Unit = consumableInfoDtos.Unit,
                WarningNum = consumableInfoDtos.WarningNum
            };
            bool res =_IConsumableInfoDal.AddEntity(consumableInfo);
            if (res)
            {
                msg = "添加成功";
                return res;
            }
            msg = "添加失败";
            return res;
        }

        /// <summary>
        /// /删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteConsumableInfo(string[] ids, out string msg)
        {
            List<ConsumableInfo> list = new List<ConsumableInfo>();
            foreach (var i in ids)
            {
                ConsumableInfo consumableInfo = _IConsumableInfoDal.FindEntity(i);
                if (consumableInfo == null)
                {
                    msg = "选中的耗材有误";
                    return false;
                }
                list.Add(consumableInfo);
            }
          
          bool res =  _IConsumableInfoDal.DelEntity(list);
            msg = "删除失败";
            if (res)
            {
                msg = "删除成功";
            }
            return res;
        }

        /// <summary>
        /// 获取耗材下拉框
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategoryOptions()
        {
            List<Category> list = _ICategoryDal.GetEntity().ToList();
            return list;
        }

        /// <summary>
        /// 获取耗材信息
        /// </summary>
        /// <returns></returns>
        public List<ConsumableInfo> GetConsumableInfos( )
        {
            List<ConsumableInfo> list = _IConsumableInfoDal.GetEntity().Where(a => !a.IsDelete).ToList();
            return list;
        }

        /// <summary>
        /// 获取选中耗材数据用于修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ConsumableInfo GetUpdateConsumableInfo(string id,out string msg)
        {   if (string.IsNullOrEmpty(id))
            {
                msg = "选中的耗材不能为空";
                return null;
            }
            ConsumableInfo consumableInfo = _IConsumableInfoDal.FindEntity(id);
            if (consumableInfo == null)
            {
                msg = "选中的耗材不存在";
                return null;

            }
            msg = "选中的数据";
            return consumableInfo;
        }

        /// <summary>
        /// 修改耗材信息
        /// </summary>
        /// <param name="consumableInfo"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdateConsumableInfo(ConsumableInfo consumableInfo, out string msg)
        {
            if (consumableInfo.Id == null)
            {
                msg = "选中的耗材不能为空";
                return false;
            }
            ConsumableInfo list = _IConsumableInfoDal.FindEntity(consumableInfo.Id);
            if(list ==null)
            {
                msg = "选中的耗材不存在";
                return false;
            
             }
            bool res =_IConsumableInfoDal.UpdateEntiry(consumableInfo);
            if (res) {
                msg = "修改成功";
                return res;
            }
            msg = "修改失败";
            return res;
        }
    }
}
