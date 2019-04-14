using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.advertise;
using Tz888.IDAL.advertise;
using Tz888.DALFactory;
namespace Tz888.BLL.advertise
{
     
   public class AdvisitInfoManager
    {
       private readonly IAdvisitInfo dal = DataAccess.CreateAdvisitInfo();
       #region IAdvisitInfo ��Ա
       /// <summary>
       /// ��ӷ�����
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public int Add(int adv,string name,string time)
       {
           return dal.Add(adv,name,time);
       }
       /// <summary>
       /// ����IDɾ��һ����¼
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public int DeleteDlaunchInfo(int id)
       {
           return dal.DeleteDlaunchInfo(id);
       }
       /// <summary>
       /// �޸�һ����¼
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public int UpdateAdvisitInfo(AdvisitInfo model)
       {
           return dal.UpdateAdvisitInfo(model); 
       }
       /// <summary>
       /// ����ID��ѯ
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public AdvisitInfo GetAllAdvisitInfoById(int Id)
       {
           return dal.GetAllAdvisitInfoById(Id);
       }

       #endregion
    }
}
