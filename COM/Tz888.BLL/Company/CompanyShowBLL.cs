using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DALFactory;
using Tz888.IDAL.Company;
using Tz888.Model.Company;

namespace Tz888.BLL.Company
{
   public  class CompanyShowBLL
    {
       private readonly ICompanyShow dal = DataAccess.CreateCompanyShow();

       /// <summary>
       /// 根据编号查询出所对应的信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public CompanyShow SelAllShow(int id)
       {
           return dal.SelAllShow(id);
       }
        /// <summary>
        /// 根据用户名查询出所对应的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public CompanyShow SelAllShows(string userName)
       {
        return dal.SelAllShows(userName);
       }
         /// <summary>
        /// 根据用户名只查询企业名称
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
       public string GetCompanyNameByLoginName(string loginName)
       {
           return dal.GetCompanyNameByLoginName(loginName);
       }
       
        /// <summary>
        /// 根据用户名查找是否有记录数
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
       public bool ExistsName(string loginName)
       {
           return dal.ExistsName(loginName);
       }
       /// <summary>
       /// 修改展厅信息
       /// </summary>
       /// <param name="model"></param>
       /// <param name="id"></param>
       /// <returns></returns>
       public int ModfiyShow(CompanyShow model, int id)
       {
           return dal.ModfiyShow(model,id);
       }
       /// <summary>
        /// 查询所有ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public string SelCompanyID()
       {
           return dal.SelCompanyID();
       }
       /// <summary>
       /// 删除所对应的展厅信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public int DeleteShow(int id)
       {
           return dal.DeleteShow(id);
       }
         /// <summary>
        /// 查询所有用户名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public string SelCompanyUserName()
       {
           return dal.SelCompanyUserName();
       }
       /// <summary>
       /// 分页
       /// </summary>
       /// <param name="TableViewName"></param>
       /// <param name="Key"></param>
       /// <param name="SelectStr"></param>
       /// <param name="Criteria"></param>
       /// <param name="Sort"></param>
       /// <param name="CurrentPage"></param>
       /// <param name="PageSize"></param>
       /// <param name="TotalCount"></param>
       /// <returns></returns>
       public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount)
       {
           return dal.GetListT(TableViewName,Key,SelectStr,Criteria,Sort,ref CurrentPage,PageSize,ref TotalCount);
       }
       /// <summary>
       /// 点击率
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public int SelHit(int id)
       {
           return dal.SelHit(id);
       }

 


       #region 招商获取行页
       /// <summary>
       /// 根据ID获取行页
       /// </summary>
       /// <returns></returns>
       public string IndustryClassListSelect(string IndustryBID,int roseID)
       {
           string Name = "";
           if (IndustryBID == "")
           {
               return Name;
           }
           string strWhere = "";

           switch (roseID)
           {
               case 1:
                   strWhere = "招商";
                   break;
               case 3:
                   strWhere = "资源联盟";
                   break;
               case 4:
                   strWhere = "融资";
                   break;
               case 5:
                   strWhere = "投资";
                   break;
               default:
                   break;
           }
           string[] num = IndustryBID.Split(',');
           for (int i = 0; i < num.Length - 1; i++)
           {
               string sql = "SELECT * FROM SetIndustryBTab where IndustryBID =@IndustryBID";
               SqlParameter[] para ={
            new SqlParameter("@IndustryBID",SqlDbType.VarChar,20)};
               para[0].Value = num[i];
               DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
               if (ds.Tables[0].Rows.Count > 0)
               {


                   Name += ds.Tables[0].Rows[0]["IndustryBName"].ToString() + strWhere;

               }
               else
               {
                   return null;
               }

           }
           return Name;



       }

       #endregion

    }
}
