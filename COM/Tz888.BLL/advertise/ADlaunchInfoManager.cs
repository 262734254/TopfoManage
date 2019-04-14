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
        #region ���һ����Ϣ

      public int Add(Tz888.Model.advertise.ADlaunchInfo model)
        {
            return dal.Add(model);
        }
        #endregion
        #region ����IDɾ��һ����Ϣ
        public int DeleteDlaunchInfo(int id)
        {
            return dal.DeleteDlaunchInfo(id);
        }
        #endregion
        #region �޸���Ϣ
      public int UpdatechannelInfo(Tz888.Model.advertise.ADlaunchInfo model)
        {
            return dal.UpdatechannelInfo(model);
        }
        #endregion
        #region ����ID��ѯ
      public Tz888.Model.advertise.ADlaunchInfo GetAllDlaunchInfoById(int Id)
        {
            return dal.GetAllDlaunchInfoById(Id);
        }

        #endregion
        /// <summary>
        /// �Ƿ���ڸü�¼
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
