using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.advertise;
using Tz888.DALFactory;
namespace Tz888.BLL.advertise
{
  public  class ADlaunchInfoManager
    {
      private readonly IADlaunchInfo dal = DataAccess.CreateADlaunchInfo();
        #region 添加一条信息

      public int Add(Tz888.Model.advertise.ADlaunchInfo model)
        {
            return dal.Add(model);
        }
        #endregion
        #region 根据ID删除一条信息
        public int DeleteDlaunchInfo(int id)
        {
            return dal.DeleteDlaunchInfo(id);
        }
        #endregion
        #region 修改信息
      public int UpdatechannelInfo(Tz888.Model.advertise.ADlaunchInfo model)
        {
            return dal.UpdatechannelInfo(model);
        }
        #endregion
        #region 根据ID查询
      public Tz888.Model.advertise.ADlaunchInfo GetAllDlaunchInfoById(int Id)
        {
            return dal.GetAllDlaunchInfoById(Id);
        }

        #endregion
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsLoginName(string LoginName)
        {
            return dal.ExistsLoginName(LoginName);
        }
      public int ModifCount(int id)
      {
          return dal.ModifCount(id);
      }
    }
}
