using Entiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBLL
{
    /// <summary>
    /// IWorkFlow_ModelBll接口
    /// </summary>

    public interface IWorkFlow_ModelBll
    {
        /// <summary>
        /// 添加工作流模板
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        bool AddWorkFlow_Model(string title, string description,out string msg);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool DeleteWorkFlow_Model(string[] ids, out string msg);

        /// <summary>
        /// 获取工作流模板
        /// </summary>
        /// <returns></returns>
        List<WorkFlow_Model> GetWorkFlow_ModelList();
        /// <summary>
        /// 获取工作流模板修改数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        WorkFlow_Model GetWorkFlow_ModelListById(string id, out string msg);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool UpdateWorkFlow_Model(string title, string description, string id, out string msg);
    }
}
