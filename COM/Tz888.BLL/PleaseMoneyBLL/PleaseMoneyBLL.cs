using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.PleaseMoneyBLL
{
   public class PleaseMoneyBLL
    {
       Tz888.SQLServerDAL.PleaseMoneyDal.PleaseMoney dal = new Tz888.SQLServerDAL.PleaseMoneyDal.PleaseMoney();
       /// <summary>
       /// 根据用户名查找所对应的余额
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       public string SelUserMoney(string name)
       {
           return dal.SelUserMoney( name);
       }
       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Tz888.Model.PleaseMoneyModel.PleaseMoneyModel GetModel(int atmId)
       {
           return dal.GetModel(atmId);
       }
           /// <summary>
       /// 更新一条数据
       /// </summary>
       public int Update(Tz888.Model.PleaseMoneyModel.PleaseMoneyModel model)
       {
           return dal.Update(model);
       }
    }
}
