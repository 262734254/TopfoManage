using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.PleaseMoneyBLL
{
   public class PleaseMoneyBLL
    {
       Tz888.SQLServerDAL.PleaseMoneyDal.PleaseMoney dal = new Tz888.SQLServerDAL.PleaseMoneyDal.PleaseMoney();
       /// <summary>
       /// �����û�����������Ӧ�����
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       public string SelUserMoney(string name)
       {
           return dal.SelUserMoney( name);
       }
       /// <summary>
       /// �õ�һ������ʵ��
       /// </summary>
       public Tz888.Model.PleaseMoneyModel.PleaseMoneyModel GetModel(int atmId)
       {
           return dal.GetModel(atmId);
       }
           /// <summary>
       /// ����һ������
       /// </summary>
       public int Update(Tz888.Model.PleaseMoneyModel.PleaseMoneyModel model)
       {
           return dal.Update(model);
       }
    }
}
