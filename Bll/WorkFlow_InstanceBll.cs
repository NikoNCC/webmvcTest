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
        /// <summary>
        /// 引用Dal
        /// </summary>
        IWorkFlow_InstanceDal _IWorkFlow_InstanceDal;
        IUserInfoDal _IUserInfoDal;
        IWorkFlow_ModelDal _IWorkFlow_ModelDal;
        IConsumableInfoDal _IConsumableInfoDal;
        IWorkFlow_InstanceStepDal _IWorkFlow_InstanceStepDal;
        IDepartmentInfoDal _IDepartmentInfoDal;
        StorehouseSysDbContext _dbContext;
        IR_UserInfo_RoleInfoDal _IR_UserInfo_RoleInfoDal;
        IRoleInfoDal _IRoleInfoDal;


        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iWorkFlow_InstanceDal"></param>
        /// <param name="iUserInfoDal"></param>
        /// <param name="iWorkFlow_ModelDal"></param>
        /// <param name="iConsumableInfoDal"></param>
        /// <param name="db"></param>
        /// <param name="iworkFlow_InstanceStepDal"></param>
        public WorkFlow_InstanceBll(IWorkFlow_InstanceDal iWorkFlow_InstanceDal,
            IUserInfoDal iUserInfoDal, IWorkFlow_ModelDal iWorkFlow_ModelDal,
            IConsumableInfoDal iConsumableInfoDal, StorehouseSysDbContext db,
            IWorkFlow_InstanceStepDal iworkFlow_InstanceStepDal
            , IDepartmentInfoDal idepartmentInfoDal
            , IR_UserInfo_RoleInfoDal ir_UserInfo_RoleInfoDal
            , IRoleInfoDal iroleInfoDal
            )




        //复制
        {
            _IDepartmentInfoDal = idepartmentInfoDal;
            _IWorkFlow_InstanceDal = iWorkFlow_InstanceDal;
            _IUserInfoDal = iUserInfoDal;
            _IWorkFlow_ModelDal = iWorkFlow_ModelDal;
            _IConsumableInfoDal = iConsumableInfoDal;
            _IWorkFlow_InstanceStepDal = iworkFlow_InstanceStepDal;
            _dbContext = db;
            _IR_UserInfo_RoleInfoDal = ir_UserInfo_RoleInfoDal;
            _IRoleInfoDal = iroleInfoDal;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="description"></param>
        /// <param name="outNum"></param>
        /// <param name="consumableId"></param>
        /// <param name="reason"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AddWorkFlow_Instance(string modelId, string description, int outNum, string consumableId, string reason, string userId, out string msg)
        {

            msg = "";

            using (var tran = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //创建工作流实例表
                   WorkFlow_Instance workFlow_Instance = new WorkFlow_Instance()
                    {
                        CreateTime = DateTime.Now,
                        Creator = userId,
                        Id = Guid.NewGuid().ToString(),
                        ModelId = modelId,
                        Description = description,
                        OutGoodsId = consumableId,
                        OutNum = outNum,
                        Reason = reason,
                        Status = WorkFlow_InstanceEnum.审核中
                    };
                    //添加到数据库
                    bool res_1 = _IWorkFlow_InstanceDal.AddEntity(workFlow_Instance);

                    if (!res_1)
                    {
                        msg = "创建工作流实例失败";
                        tran.Rollback();
                        return res_1;
                    }

                    //部门信息
                    UserInfo userInfo = _IUserInfoDal.GetEntity().FirstOrDefault(a => a.Id == userId && !a.IsDelete);
                    //判断登陆人有没有部门
                    if (userInfo == null && userInfo.DepartmentId == null)
                    {
                        msg = "当前登录人没有部门";
                        tran.Rollback();
                        return false;
                    }
                    //部门信息
                    DepartmentInfo departmentInfo = _IDepartmentInfoDal.GetEntity().FirstOrDefault(a => a.Id == userInfo.DepartmentId && !a.IsDelete);
                    if (departmentInfo == null || departmentInfo.LeaderId == null)
                    {
                        msg = "当前登录人没有部门或者领导";
                        tran.Rollback();
                        return false;
                    }
                    //部门负责人
                    int leader = (from a in _IR_UserInfo_RoleInfoDal.GetEntity().Where(a => a.UserId == departmentInfo.LeaderId)
                                       join b in _IRoleInfoDal.GetRoleInfo().Where(a => !a.IsDelete && a.RoleName == "部门经理")
                                       on a.RoleId equals b.Id
                                       select b.Id
                                      ).Count();
                    if(leader<=0)
                    {

                        msg = "该部门领导不具备审核权";
                        tran.Rollback();
                        return false;
                    }

                    //创建工作流步骤
                    WorkFlow_InstanceStep wfis = new WorkFlow_InstanceStep()
                    {
                        CreateTime = DateTime.Now,
                        Id = Guid.NewGuid().ToString(),
                        InstanceId = workFlow_Instance.Id,
                        ReviewStatus = WorkFlow_InstanceStepStatusEnum.审核中,
                        ReviewerId = departmentInfo.LeaderId,
                    };
                    bool res_2 = _IWorkFlow_InstanceStepDal.AddEntity(wfis);
                    if (!res_2)
                    {

                        msg = "创建工作流步骤失败";
                        tran.Rollback();
                        return res_2;
                    }
                    msg ="步骤创建完成";
                    tran.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    msg = "事务错误";
                    tran.Rollback();
                    return false;

                }

            }


           

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
                Title = a.Title,
                Value = a.Id

            }).ToList();
            return new
            {
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
                Status =a.Status.ToString()
            }).ToList();


            return list;
        }
    }
}
