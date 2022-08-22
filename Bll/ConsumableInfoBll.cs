using IBLL;
using IDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bll
{
    /// <summary>
    /// 耗材管理Bll
    /// </summary>
    public class ConsumableInfoBll: IConsumableInfoBll
    {
        IConsumableInfoDal _IConsumableInfoDal;
        public ConsumableInfoBll(IConsumableInfoDal iConsumableInfoDal)
        {
            _IConsumableInfoDal = iConsumableInfoDal;
        }
    }
}
