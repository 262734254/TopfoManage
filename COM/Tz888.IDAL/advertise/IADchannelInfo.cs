using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.advertise
{
   public  interface IADchannelInfo
    {
        /// <summary>
        ///  ���ӹ��Ƶ��
        /// </summary>
        int Add(Tz888.Model.advertise.ADchannelInfo model);
       /// <summary>
       /// ɾ�����Ƶ��
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       int DeletechannelInfo(int id);
       /// <summary>
       /// �޸Ĺ��Ƶ��
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       int UpdatechannelInfo(Tz888.Model.advertise.ADchannelInfo model);

       Tz888.Model.advertise.ADchannelInfo GetAllchannelInfoById(int Id);
    }
}
