using Entiy;
using IBLL;
using IDal;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Bll
{
    /// <summary>
    /// WorkFlow_ModelBll
    /// </summary>
    public class WorkFlow_ModelBll: IWorkFlow_ModelBll
    {
        IWorkFlow_ModelDal _IWorkFlow_ModelDal;

        public WorkFlow_ModelBll(IWorkFlow_ModelDal iWorkFlow_ModelDal)
        {
            _IWorkFlow_ModelDal = iWorkFlow_ModelDal;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool AddWorkFlow_Model(string title, string description,out string msg)
        {
            //模板是否存在
          var titleList =  _IWorkFlow_ModelDal.GetEntity().Where(a => a.Title == title).ToList();
            if (titleList.Count > 0)
            {
                msg = "模板已存在";
                return false;
            }
            //创建表对象
            WorkFlow_Model workFlow_Model = new WorkFlow_Model();
            workFlow_Model.Title = title;   
            workFlow_Model.CreateTime = DateTime.Now;
            workFlow_Model.Description = description;
            workFlow_Model.Id = Guid.NewGuid().ToString();
            msg = "添加失败";
          bool res = _IWorkFlow_ModelDal.AddEntity(workFlow_Model);
            if (res)
            {
                msg = "添加成功";
                
            }
            
            return res;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteWorkFlow_Model(string[] ids, out string msg)
        {   
            List<WorkFlow_Model> workFlow_ModelList = new List<WorkFlow_Model>();
            foreach (var i in ids)
            {
                WorkFlow_Model workFlow_Model = _IWorkFlow_ModelDal.FindEntity(i);
                if (workFlow_Model == null)
                {
                    msg = "选中模板不存在";
                    return false;
                }
                workFlow_Model.IsDelete = true;
                workFlow_Model.DeleteTime = DateTime.Now;
                workFlow_ModelList.Add(workFlow_Model);
            
            }
            msg = "删除失败";
            bool res = _IWorkFlow_ModelDal.DelEntity(workFlow_ModelList);
            if (res)
            {
                msg = "删除成功";
            }
            return res;
        }

        /// <summary>
        /// 获取工作实列数据
        /// </summary>
        /// <returns></returns>
        public List<WorkFlow_Model> GetWorkFlow_ModelList()
        {
            List<WorkFlow_Model> listWorkFlow_Models =_IWorkFlow_ModelDal.GetEntity().Where(a => !a.IsDelete).ToList();
            return listWorkFlow_Models;
        }

        /// <summary>
        /// 获取工作流模板ByID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public WorkFlow_Model GetWorkFlow_ModelListById(string id, out string msg)
        {
            WorkFlow_Model workFlow_Model= _IWorkFlow_ModelDal.FindEntity(id);
            //判断模板是否存在
            if (workFlow_Model != null)
            {
                msg = "模板数据";
                return workFlow_Model;
            }
            msg = "模板不存在";
            return null;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateWorkFlow_Model(string title, string description, string id, out string msg)
        {
            msg = "失败";
            WorkFlow_Model workFlow_Model = _IWorkFlow_ModelDal.FindEntity(id);
            if (workFlow_Model == null)
            {
                msg = "模板不存在";
                return false;
            }
            workFlow_Model.Description = description;
            workFlow_Model.Title = title;
         bool res =   _IWorkFlow_ModelDal.UpdateEntiry(workFlow_Model);
            if(res)
            {

                msg = "修改成功";
            }
            return res;
        }
    }
}
