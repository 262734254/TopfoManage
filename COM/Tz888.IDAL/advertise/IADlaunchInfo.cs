using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.advertise
{
   public interface IADlaunchInfo
    {
        /// <summary>
        ///  增加广告频道
        /// </summary>
        int Add(Tz888.Model.advertise.ADlaunchInfo model);
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
       int UpdatechannelInfo(Tz888.Model.advertise.ADlaunchInfo model);
       /// <summary>
       /// 根据ID查询
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       Tz888.Model.advertise.ADlaunchInfo GetAllDlaunchInfoById(int Id);
       /// <summary>
       /// 处理访问量
       /// </summary>
       /// <param name="id"></param>
       int ModifCount(int id);
      /// <summary>
       ///  是否存在登录名
      /// </summary>
      /// <param name="LoginName"></param>
      /// <returns></returns>
       bool ExistsLoginName(string LoginName);
    }
}
