using Dal;
using Entity;
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
    public class WorkFlow_InstanceStepBll : IWorkFlow_InstanceStepBll
    {
        IWorkFlow_InstanceDal _IWorkFlow_InstanceDal;
        IUserInfoDal _IUserInfoDal;
        IWorkFlow_ModelDal _IWorkFlow_ModelDal;
        IConsumableInfoDal _IConsumableInfoDal;
        IWorkFlow_InstanceStepDal _IWorkFlow_InstanceStepDal;
        IDepartmentInfoDal _IDepartmentInfoDal;
        IConsumableRecordDal _ConsumableRecordDal;
        StorehouseSysDbContext _dbContext;
        IR_UserInfo_RoleInfoDal _IR_UserInfo_RoleInfoDal;
        IRoleInfoDal _IRoleInfoDal;
        public WorkFlow_InstanceStepBll(IWorkFlow_InstanceDal iWorkFlow_InstanceDal,
            IUserInfoDal iUserInfoDal,
            IWorkFlow_ModelDal iWorkFlow_ModelDal,
            IConsumableInfoDal iConsumableInfoDal,
            IWorkFlow_InstanceStepDal iworkFlow_InstanceStepDal
            , IDepartmentInfoDal idepartmentInfoDal
            , StorehouseSysDbContext db
            , IR_UserInfo_RoleInfoDal ir_UserInfo_RoleInfoDal
            , IRoleInfoDal iroleInfoDal
            , IConsumableRecordDal consumableRecordDal

            )
        {

            _IWorkFlow_InstanceDal = iWorkFlow_InstanceDal;
            _IUserInfoDal = iUserInfoDal;
            _IWorkFlow_ModelDal = iWorkFlow_ModelDal;
            _IConsumableInfoDal = iConsumableInfoDal;
            _IWorkFlow_InstanceStepDal = iworkFlow_InstanceStepDal;
            _IDepartmentInfoDal = idepartmentInfoDal;
            _dbContext = db;
            _IR_UserInfo_RoleInfoDal = ir_UserInfo_RoleInfoDal;
            _IRoleInfoDal = iroleInfoDal;
            _ConsumableRecordDal = consumableRecordDal;
        }
        /// <summary>
        /// 获取要审核数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public WorkFlow_InstanceStepDtos GetWorkFlow_InstanceStepById(string id, out string msg)
        {
            msg = "获取数据失败";


            WorkFlow_InstanceStepDtos data = (from wifs in _IWorkFlow_InstanceStepDal.GetEntity()
                                              join wi in _IWorkFlow_InstanceDal.GetEntity()
                                              on wifs.InstanceId equals wi.Id
                                              into tempwi
                                              from wiwi in tempwi.DefaultIfEmpty()

                                              join wm in _IWorkFlow_ModelDal.GetEntity().Where(a => !a.IsDelete)
                                              on wiwi.ModelId equals wm.Id
                                              into tempwm
                                              from wmwm in tempwm.DefaultIfEmpty()

                                              join user in _IUserInfoDal.GetEntity().Where(u => !u.IsDelete)
                                              on wiwi.Creator equals user.Id
                                              into tmepuser
                                              from user2 in tmepuser.DefaultIfEmpty()

                                              join com in _IConsumableInfoDal.GetEntity().Where(c => !c.IsDelete)
                                              on wiwi.OutGoodsId equals com.Id
                                              into tempcom
                                              from com2 in tempcom.DefaultIfEmpty()

                                              join leader in _IUserInfoDal.GetEntity().Where(l => !l.IsDelete)
                                              on wifs.ReviewerId equals leader.Id
                                              into templeader
                                              from leader2 in templeader.DefaultIfEmpty()
                                              select new WorkFlow_InstanceStepDtos
                                              {
                                                  Id = wifs.Id,
                                                  ConsumableName = com2.ConsumableName,
                                                  OutNum = wiwi.OutNum,
                                                  CreatorName = user2.UserName,
                                                  Reason = wiwi.Reason,
                                                  Title = wmwm.Title,
                                              }
                                              ).FirstOrDefault(a => a.Id == id);


            if (data != null)
            {
                msg = "要修改数据";
            }

            return data;
        }

        /// <summary>
        /// 展示数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="userId"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<WorkFlow_InstanceStepDtos> GetWorkFlow_InstanceStepList(int page, int limit, string userId, out int count)
        {
            //连表查询
            var data = (from wifs in _IWorkFlow_InstanceStepDal.GetEntity().Where(w => w.ReviewerId == userId)
                        join wi in _IWorkFlow_InstanceDal.GetEntity()
                        on wifs.InstanceId equals wi.Id
                        into tempwi
                        from wiwi in tempwi.DefaultIfEmpty()

                        join wm in _IWorkFlow_ModelDal.GetEntity().Where(a => !a.IsDelete)
                        on wiwi.ModelId equals wm.Id
                        into tempwm
                        from wmwm in tempwm.DefaultIfEmpty()

                        join user in _IUserInfoDal.GetEntity().Where(u => !u.IsDelete)
                        on wiwi.Creator equals user.Id
                        into tmepuser
                        from user2 in tmepuser.DefaultIfEmpty()

                        join com in _IConsumableInfoDal.GetEntity().Where(c => !c.IsDelete)
                        on wiwi.OutGoodsId equals com.Id
                        into tempcom
                        from com2 in tempcom.DefaultIfEmpty()

                        join leader in _IUserInfoDal.GetEntity().Where(l => !l.IsDelete)
                        on wifs.ReviewerId equals leader.Id
                        into templeader
                        from leader2 in templeader.DefaultIfEmpty()

                        select new
                        {
                            Id = wifs.Id,
                            ConsumableName = com2.ConsumableName,
                            ReviewerId = leader2.Id,
                            ReviewerName = leader2.UserName,
                            InstanceId = wiwi.Id,
                            OutNum = wiwi.OutNum,
                            ReviewReason = wifs.ReviewReason,
                            Reason = wiwi.Reason,
                            ReviewStatus = wifs.ReviewStatus,
                            ReviewTime = wifs.ReviewTime,
                            Title = wmwm.Title,
                            CreateTime = wifs.CreateTime,
                            Creator = user2.Id,
                            CreatorName = user2.UserName
                        }
                        );
            //总条数
            count = data.Count();
            //分页
            List<WorkFlow_InstanceStepDtos> list = data.Skip((page - 1) * limit).Take(limit).ToList().Select(a => new WorkFlow_InstanceStepDtos()
            {

                Id = a.Id,
                ConsumableName = a.ConsumableName,
                ReviewerId = a.Id,
                ReviewerName = a.ReviewerName,
                InstanceId = a.Id,
                OutNum = a.OutNum,
                ReviewReason = a.ReviewReason,
                ReviewStatus = a.ReviewStatus.ToString(),
                ReviewTime = a.ReviewTime.ToString("yyyy--MM--dd HH:mm:ss"),
                Title = a.Title,
                CreateTime = a.CreateTime.ToString("yyyy--MM--dd HH:mm:ss"),
                Creator = a.Creator,
                CreatorName = a.CreatorName,
                Reason = a.Reason,
            }).ToList();


            return list;
        }

        /// <summary>
        /// 申请审批步骤
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reviewReason"></param>
        /// <param name="status"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdateWorkFlow_InstanceStep(string id, string reviewReason, WorkFlow_InstanceStepStatusEnum status, string userId, out string msg)
        {


            using (var tran = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    WorkFlow_InstanceStep stepData = _IWorkFlow_InstanceStepDal.GetEntity().FirstOrDefault(a => a.Id == id);
                    if (stepData == null)
                    {
                        msg = "选中的申请不存在";
                        return false;
                    }
                    if (status == WorkFlow_InstanceStepStatusEnum.同意)
                    {
                        
                        stepData.ReviewReason = reviewReason;
                        stepData.ReviewStatus = status;
                        stepData.ReviewTime = DateTime.Now;
                        bool res_1 = _IWorkFlow_InstanceStepDal.UpdateEntiry(stepData);
                        if (!res_1)
                        {
                            msg = "无法审批";
                            tran.Rollback();
                            return false;

                        }


                        //部门负责人
                        List<string> leader = (from a in _IR_UserInfo_RoleInfoDal.GetEntity().Where(a => a.UserId == userId)
                                               join b in _IRoleInfoDal.GetRoleInfo().Where(a => !a.IsDelete)
                                               on a.RoleId equals b.Id
                                               select b.RoleName
                                          ).ToList();
                        if (leader.Contains("部门经理"))
                        {
                            List<string> storehouseAdminList = (from r in _IRoleInfoDal.GetRoleInfo().Where(a => !a.IsDelete && a.RoleName == "仓库管理员")
                                                                join ur in _IR_UserInfo_RoleInfoDal.GetEntity()
                                                                on r.Id equals ur.RoleId
                                                                select ur.UserId).ToList();

                            string storehouseAdminId = storehouseAdminList.FirstOrDefault();
                            if (storehouseAdminId == null)
                            {
                                msg = "找不到仓库管理员";
                                tran.Rollback();
                                return false;

                            }

                            WorkFlow_InstanceStep entity = new WorkFlow_InstanceStep()
                            {
                                Id = Guid.NewGuid().ToString(),
                                BeforeStepId = stepData.Id,
                                CreateTime = DateTime.Now,
                                InstanceId = stepData.InstanceId,
                                ReviewerId = storehouseAdminId,
                                ReviewStatus = WorkFlow_InstanceStepStatusEnum.审核中,
                            };
                            //创建工作流步骤
                            bool res_2 = _IWorkFlow_InstanceStepDal.AddEntity(entity);
                            if (!res_2)
                            {
                                msg = "向管理员发送申请失败";
                                tran.Rollback();
                                return res_2;
                            }


                        }
                        else if (leader.Contains("仓库管理员"))
                        {
                            var sfiData = _IWorkFlow_InstanceDal.GetEntity().FirstOrDefault(a => a.Id == stepData.InstanceId);
                            if (sfiData == null)
                            {
                                tran.Rollback();
                                msg = "找不工作流实例";
                                return false;
                            }
                            ConsumableInfo commData = _IConsumableInfoDal.GetEntity().FirstOrDefault(a => a.Id == sfiData.OutGoodsId);
                            if (commData == null)
                            {

                                tran.Rollback();
                                msg = "找不到耗材信息";
                                return false;
                            }
                            //判断耗材库存数量是否足够
                            if (commData.Num < sfiData.OutNum)
                            {
                                tran.Rollback();
                                msg = "库存不足";
                                return false;

                            }
                            //更新耗材
                            commData.Num -= sfiData.OutNum;
                            bool res_2 = _IConsumableInfoDal.UpdateEntiry(commData);
                            if (!res_2)
                            {
                                tran.Rollback();
                                msg = "更新库存失败";
                                return false;
                            }

                            ConsumableRecord consumableInfo = new ConsumableRecord()
                            {
                                Id = Guid.NewGuid().ToString(),
                                ConsumableId = commData.Id,
                                CreateTime = DateTime.Now,
                                Creator = userId,
                                Num = sfiData.OutNum,
                                Type = 2
                            };
                            bool res_3 = _ConsumableRecordDal.AddEntity(consumableInfo);
                            if (!res_3)
                            {
                                tran.Rollback();
                                msg = "更新耗材记录表失败";
                                return false;
                            }
                            //结束工作流实例
                            sfiData.Status = WorkFlow_InstanceEnum.结束;
                            bool res_4 = _IWorkFlow_InstanceDal.UpdateEntiry(sfiData);
                            if (!res_4)
                            {
                                tran.Rollback();
                                msg = "更新工作流实例失败";
                                return false;
                            }
                        }
                        else
                        {
                            tran.Rollback();
                            msg = "审批失败";
                            return false;
                        }
                    }
                    else if (status == WorkFlow_InstanceStepStatusEnum.驳回)
                    {
                        //部门负责人
                        List<string> leader = (from a in _IR_UserInfo_RoleInfoDal.GetEntity().Where(a => a.UserId == userId)
                                               join b in _IRoleInfoDal.GetRoleInfo().Where(a => !a.IsDelete)
                                               on a.RoleId equals b.Id
                                               select b.RoleName
                                          ).ToList();
                        if (leader.Contains("部门经理"))
                        {
                            WorkFlow_InstanceStep stepData2 = new WorkFlow_InstanceStep() { 
                               Id =Guid.NewGuid().ToString(),
                               BeforeStepId = stepData.Id,
                               CreateTime =DateTime.Now,
                               InstanceId =stepData.InstanceId,
                               ReviewerId = stepData.Id,
                               ReviewStatus =WorkFlow_InstanceStepStatusEnum.审核中,
                               
                            };
                            bool res_1 = _IWorkFlow_InstanceStepDal.AddEntity(stepData2);
                            if(!res_1)
                                {
                                msg = "驳回：创建工作流失败";
                                tran.Rollback();
                                return false;
                            }
                            

                        }
                    }

                
                    msg = "批改成功";
                    tran.Commit();

                }
                catch (Exception e)
                {
                    msg = "事务出错";
                    tran.Rollback();
                    return false;
                }

            }
            return false;
        }
    }
}
