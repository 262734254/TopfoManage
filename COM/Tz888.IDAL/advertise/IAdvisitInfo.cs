using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.advertise
{
   public interface IAdvisitInfo
    {
        /// <summary>
        ///  增加广告频道
        /// </summary>
       int Add(int adv,string name,string time);
        /// <summary>
        /// 删除广告频道
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteDlaunchInfo(int id);
        /// <summary>
        /// 修改广告频道
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
       int UpdateAdvisitInfo(Tz888.Model.advertise.AdvisitInfo model);
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
       Tz888.Model.advertise.AdvisitInfo GetAllAdvisitInfoById(int Id);
    }
}
