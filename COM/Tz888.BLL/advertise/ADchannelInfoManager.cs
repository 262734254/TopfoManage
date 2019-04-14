using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.advertise;
using Tz888.DALFactory;
using System.Data;
namespace Tz888.BLL.advertise
{
   public class ADchannelInfoManager
    {
       private readonly IADchannelInfo dal = DataAccess.CreateADchannelInfo();
       #region 添加频道
       /// <summary>
       /// 添加频道
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public int Add(Tz888.Model.advertise.ADchannelInfo model)
       {
           return dal.Add(model);
       }

       #endregion
       #region 删除频道

       /// <summary>
       /// 删除频道
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public int DeletechannelInfo(int id)
       {
           return dal.DeletechannelInfo(id);
       }



       #endregion
       #region 修改频道
       /// <summary>
       /// 修改频道
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public int UpdatechannelInfo(Tz888.Model.advertise.ADchannelInfo model)
       {
           return dal.UpdatechannelInfo(model);
       }
       #endregion
       
       #region 查看详细信息
       /// <summary>
       /// 根据ID查看详细信息
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public Tz888.Model.advertise.ADchannelInfo GetAllchannelInfoById(int Id)
       {

           return dal.GetAllchannelInfoById(Id);
       } 
       #endregion
    }
}
