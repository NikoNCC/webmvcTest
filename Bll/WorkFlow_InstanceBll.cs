using Entiy.Dtos;
using IBLL;
using IDal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dal;
using Entiy;

namespace Bll
{
    /// <summary>
    /// 工作实例表Bll
    /// </summary>

    public class WorkFlow_InstanceBll : IWorkFlow_InstanceBll
    {
        IWorkFlow_InstanceDal _IWorkFlow_InstanceDal;
        IUserInfoDal _IUserInfoDal;
        IWorkFlow_ModelDal _IWorkFlow_ModelDal;
        IConsumableInfoDal _IConsumableInfoDal;
        public WorkFlow_InstanceBll(IWorkFlow_InstanceDal iWorkFlow_InstanceDal, IUserInfoDal iUserInfoDal, IWorkFlow_ModelDal iWorkFlow_ModelDal, IConsumableInfoDal iConsumableInfoDal)
        {
            _IWorkFlow_InstanceDal = iWorkFlow_InstanceDal;
            _IUserInfoDal = iUserInfoDal;
            _IWorkFlow_ModelDal = iWorkFlow_ModelDal;
            _IConsumableInfoDal = iConsumableInfoDal;
        }
        /// <summary>
        /// 下拉框
        /// </summary>
        /// <returns></returns>
        public object AddWorkFlow_InstanceOptins()
        {
            List<SelectOptions> cmList = _IConsumableInfoDal.GetEntity().Where(a => !a.IsDelete).Select(a => new SelectOptions()
            {
                Title = a.ConsumableName,
                Value = a.Id

            }).ToList();
            List<SelectOptions> ModelList = _IWorkFlow_ModelDal.GetEntity().Where(a => !a.IsDelete).Select(a => new SelectOptions()
            {
                Title =a.Title,
                Value =a.Id

            }).ToList();
            return new {
                 cmList,
                ModelList
            };
        }
        /// <summary>
        /// 展示
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<WorkFlow_InstanceDtos> GetWorkFlow_Instance(int page, int limit, out int count)
        {
            var workFlow_InstanceLs = (from a in _IWorkFlow_InstanceDal.GetEntity()
                                       join u in _IUserInfoDal.GetEntity().Where(a => !a.IsDelete)
                                       on a.Creator equals u.Id
                                       join wm in _IWorkFlow_ModelDal.GetEntity().Where(a => !a.IsDelete)
                                       on a.ModelId equals wm.Id
                                       join cmInfo in _IConsumableInfoDal.GetEntity().Where(a => !a.IsDelete)
                                       on a.OutGoodsId equals cmInfo.Id
                                       select new
                                       {
                                           Creator = u.Id,
                                           UserName = u.UserName,
                                           Description = a.Description,
                                           Reason = a.Reason,
                                           CreateTime = a.CreateTime,
                                           Title = wm.Title,
                                           Id = a.Id,
                                           ModelId = wm.Id,
                                           OutGoodsId = cmInfo.Id,
                                           ConsumableName = cmInfo.ConsumableName,
                                           OutNum = a.OutNum,
                                           Status = a.Status
                                       });
            //获取总条数
            count = workFlow_InstanceLs.Count();
            List<WorkFlow_InstanceDtos> list = workFlow_InstanceLs.Skip((page - 1) * limit).Take(limit).ToList().Select(a => new WorkFlow_InstanceDtos()
            {
                Creator = a.Id,
                UserName = a.UserName,
                Description = a.Description,
                Reason = a.Reason,
                CreateTime = a.CreateTime.ToString("yyyy--MM--dd HH"),
                Title = a.Title,
                Id = a.Id,
                ModelId = a.Id,
                OutGoodsId = a.Id,
                ConsumableName = a.ConsumableName,
                OutNum = a.OutNum,
              Status = (WorkFlow_InstanceEnum)a.Status
            }).ToList();


            return list;
        }
    }
}
