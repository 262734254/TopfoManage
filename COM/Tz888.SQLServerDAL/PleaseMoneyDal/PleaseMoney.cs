using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL.PleaseMoneyDal
{

   public class PleaseMoney
   {
       Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();
       /// <summary>
       /// 根据用户名查找所对应的余额
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       public string SelUserMoney(string name)
       {

           string sql = "select MoneyCount from CompanyShow where UserName=@name and Roleid=3";
           SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
           para[0].Value = name;
           DataSet ds = crm.Querys(sql, para);
           if (ds != null & ds.Tables[0].Rows.Count > 0)
           {
               string money = ds.Tables[0].Rows[0]["MoneyCount"].ToString();

               return money;
           }
           else
           {
               return null;
           }
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public int Update(Tz888.Model.PleaseMoneyModel.PleaseMoneyModel model)
       {
           int num;
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update PleaseMoney set ");
           strSql.Append("atmcount=@atmcount,");
           strSql.Append("BankName=@BankName,");
           strSql.Append("BankNumber=@BankNumber,");
           strSql.Append("DepositBank=@DepositBank,");
           strSql.Append("AccountName=@AccountName,");
           strSql.Append("LoginName=@LoginName,");
           strSql.Append("CreateTime=@CreateTime,");
           strSql.Append("Enddate=@Enddate,");
           strSql.Append("StateID=@StateID,");
           strSql.Append("Description=@Description,");
           strSql.Append("Mobile=@Mobile,");
           strSql.Append("AuditName=@AuditName");
           strSql.Append(" where atmId=@atmId ");
           SqlParameter[] parameters = {
					new SqlParameter("@atmId", SqlDbType.Int,4),
					new SqlParameter("@atmcount", SqlDbType.Decimal,9),
					new SqlParameter("@BankName", SqlDbType.VarChar,20),
					new SqlParameter("@BankNumber", SqlDbType.VarChar,50),
					new SqlParameter("@DepositBank", SqlDbType.VarChar,100),
					new SqlParameter("@AccountName", SqlDbType.VarChar,20),
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Enddate", SqlDbType.DateTime),
					new SqlParameter("@StateID", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.VarChar,100),
					new SqlParameter("@Mobile", SqlDbType.VarChar,100),
					new SqlParameter("@AuditName", SqlDbType.VarChar,20)};
           parameters[0].Value = model.atmId;
           parameters[1].Value = model.atmcount;
           parameters[2].Value = model.BankName;
           parameters[3].Value = model.BankNumber;
           parameters[4].Value = model.DepositBank;
           parameters[5].Value = model.AccountName;
           parameters[6].Value = model.LoginName;
           parameters[7].Value = model.CreateTime;
           parameters[8].Value = model.Enddate;
           parameters[9].Value = model.StateID;
           parameters[10].Value = model.Description;
           parameters[11].Value = model.Mobile;
           parameters[12].Value = model.AuditName;

          num= crm.ExecuteSqls(strSql.ToString(), parameters);
          return num;
       }
       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Tz888.Model.PleaseMoneyModel.PleaseMoneyModel GetModel(int atmId)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 atmId,atmcount,BankName,BankNumber,DepositBank,AccountName,LoginName,CreateTime,Enddate,StateID,Description,Mobile,AuditName from PleaseMoney ");
           strSql.Append(" where atmId=@atmId ");
           SqlParameter[] parameters = {
					new SqlParameter("@atmId", SqlDbType.Int,4)};
           parameters[0].Value = atmId;

           Tz888.Model.PleaseMoneyModel.PleaseMoneyModel model = new Tz888.Model.PleaseMoneyModel.PleaseMoneyModel();
           DataSet ds = crm.Querys(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["atmId"].ToString() != "")
               {
                   model.atmId = int.Parse(ds.Tables[0].Rows[0]["atmId"].ToString());
               }
               if (ds.Tables[0].Rows[0]["atmcount"].ToString() != "")
               {
                   model.atmcount = decimal.Parse(ds.Tables[0].Rows[0]["atmcount"].ToString());
               }
               model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
               model.BankNumber = ds.Tables[0].Rows[0]["BankNumber"].ToString();
               model.DepositBank = ds.Tables[0].Rows[0]["DepositBank"].ToString();
               model.AccountName = ds.Tables[0].Rows[0]["AccountName"].ToString();
               model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
               if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
               {
                   model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
               }
               if (ds.Tables[0].Rows[0]["Enddate"].ToString() != "")
               {
                   model.Enddate = DateTime.Parse(ds.Tables[0].Rows[0]["Enddate"].ToString());
               }
               if (ds.Tables[0].Rows[0]["StateID"].ToString() != "")
               {
                   model.StateID = int.Parse(ds.Tables[0].Rows[0]["StateID"].ToString());
               }
               model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
               model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
               model.AuditName = ds.Tables[0].Rows[0]["AuditName"].ToString();
               return model;
           }
           else
           {
               return null;
           }
       }
     
    }
}
