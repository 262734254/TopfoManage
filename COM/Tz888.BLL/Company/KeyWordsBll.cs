using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.Company;
using Tz888.SQLServerDAL.Company;

namespace Tz888.BLL.Company
{
   public class KeyWordsBll
    {
       KeyWordsDal dal = new KeyWordsDal();
       public int Add(KeyWords model)
       {
           try
           {
               return dal.Add(model);
           }
           catch (Exception)
           {

               return 0;
           }
       }
       /// <summary>
        /// 更新一条数据
        /// </summary>
       public void Update(KeyWords model)
       {
           try
           {
               dal.Update(model);
           }
           catch (Exception ex )
           {
               
               throw;
           }
       }
       public bool Exists(int RoseID,string UserName)
       {
           return dal.Exists(RoseID,UserName);
       }

       public KeyWords GetModel(int RoseId, string UserName)
       {
           return dal.GetModel(RoseId, UserName);
       }
    }
}
