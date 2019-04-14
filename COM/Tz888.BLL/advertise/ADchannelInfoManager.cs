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
       #region ���Ƶ��
       /// <summary>
       /// ���Ƶ��
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public int Add(Tz888.Model.advertise.ADchannelInfo model)
       {
           return dal.Add(model);
       }

       #endregion
       #region ɾ��Ƶ��

       /// <summary>
       /// ɾ��Ƶ��
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public int DeletechannelInfo(int id)
       {
           return dal.DeletechannelInfo(id);
       }



       #endregion
       #region �޸�Ƶ��
       /// <summary>
       /// �޸�Ƶ��
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public int UpdatechannelInfo(Tz888.Model.advertise.ADchannelInfo model)
       {
           return dal.UpdatechannelInfo(model);
       }
       #endregion
       
       #region �鿴��ϸ��Ϣ
       /// <summary>
       /// ����ID�鿴��ϸ��Ϣ
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
