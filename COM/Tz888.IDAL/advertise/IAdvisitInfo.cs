using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.advertise
{
   public interface IAdvisitInfo
    {
        /// <summary>
        ///  ���ӹ��Ƶ��
        /// </summary>
       int Add(int adv,string name,string time);
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
       int UpdateAdvisitInfo(Tz888.Model.advertise.AdvisitInfo model);
        /// <summary>
        /// ����ID��ѯ
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
       Tz888.Model.advertise.AdvisitInfo GetAllAdvisitInfoById(int Id);
    }
}
