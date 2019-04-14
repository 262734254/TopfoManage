using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.advertise
{
   public  interface IADchannelInfo
    {
        /// <summary>
        ///  增加广告频道
        /// </summary>
        int Add(Tz888.Model.advertise.ADchannelInfo model);
       /// <summary>
       /// 删除广告频道
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       int DeletechannelInfo(int id);
       /// <summary>
       /// 修改广告频道
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       int UpdatechannelInfo(Tz888.Model.advertise.ADchannelInfo model);

       Tz888.Model.advertise.ADchannelInfo GetAllchannelInfoById(int Id);
    }
}
