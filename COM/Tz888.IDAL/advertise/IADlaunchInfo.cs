using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.advertise
{
   public interface IADlaunchInfo
    {
        /// <summary>
        ///  ���ӹ��Ƶ��
        /// </summary>
        int Add(Tz888.Model.advertise.ADlaunchInfo model);
        /// <summary>
        /// ɾ�����Ƶ��
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       int DeleteDlaunchInfo(int id);
        /// <summary>
        /// �޸Ĺ��Ƶ��
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
       int UpdatechannelInfo(Tz888.Model.advertise.ADlaunchInfo model);
       /// <summary>
       /// ����ID��ѯ
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       Tz888.Model.advertise.ADlaunchInfo GetAllDlaunchInfoById(int Id);
       /// <summary>
       /// ���������
       /// </summary>
       /// <param name="id"></param>
       int ModifCount(int id);
      /// <summary>
       ///  �Ƿ���ڵ�¼��
      /// </summary>
      /// <param name="LoginName"></param>
      /// <returns></returns>
       bool ExistsLoginName(string LoginName);
    }
}
