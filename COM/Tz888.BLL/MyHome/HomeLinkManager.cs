using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DALFactory;
using Tz888.IDAL;
using Tz888.SQLServerDAL.MyHome;
using Tz888.Model.MyHome;
using Tz888.DBUtility;

namespace Tz888.BLL.MyHome
{
   public class HomeLinkManager
    {
       HomeLinkService dal = new HomeLinkService();
       /// <summary>
       /// 查询主页列表
       /// </summary>
       /// <returns></returns>
       public MyHomeLink GetAllhome()
       {
           try
           {
               return dal.GetAllhome();
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }
       /// <summary>
       /// 用test数据库
       /// </summary>
       /// <param name="TableViewName">表名</param>
       /// <param name="Key">主键</param>
       /// <param name="SelectStr">查询字段</param>
       /// <param name="Criteria">条件</param>
       /// <param name="Sort">排序字段</param>
       /// <param name="CurrentPage">当前页</param>
       /// <param name="PageSize">页大小</param>
       /// <param name="TotalCount">总记录</param>
       /// <returns></returns>
       public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
           ref long CurrentPage, long PageSize, ref long TotalCount)
       {
           return dal.GetListT(TableViewName, Key, SelectStr, Criteria, Sort,
           ref CurrentPage, PageSize, ref TotalCount);
       }


       /// <summary>
       /// 用test数据库
       /// </summary>
       /// <param name="TableViewName">表名</param>
       /// <param name="Key">主键</param>
       /// <param name="SelectStr">查询字段</param>
       /// <param name="Criteria">条件</param>
       /// <param name="Sort">排序字段</param>
       /// <param name="CurrentPage">当前页</param>
       /// <param name="PageSize">页大小</param>
       /// <param name="TotalCount">总记录</param>
       /// <returns></returns>
       public DataTable GetListCrm(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
           ref long CurrentPage, long PageSize, ref long TotalCount)
       {
           return dal.GetListCrm(TableViewName, Key, SelectStr, Criteria, Sort,
           ref CurrentPage, PageSize, ref TotalCount);
       }
       #region 分页查询
       /// <summary>
       /// 用test数据库
       /// </summary>
       /// <param name="TableViewName">表名</param>
       /// <param name="Key">主键</param>
       /// <param name="SelectStr">查询字段</param>
       /// <param name="Criteria">条件</param>
       /// <param name="Sort">排序字段</param>
       /// <param name="CurrentPage">当前页</param>
       /// <param name="PageSize">页大小</param>
       /// <param name="TotalCount">总记录</param>
       /// <returns></returns>
       public DataTable GetListTS(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
           ref long CurrentPage, long PageSize, ref long TotalCount)
       { 
           return dal.GetListTS(TableViewName, Key, SelectStr, Criteria, Sort,
           ref CurrentPage, PageSize, ref TotalCount);
       } 
       #endregion
       #region 删除信息
       /// <summary>
       /// 删除信息
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public int deleteMyHome(int Id)
       {
           try
           {
               return dal.deleteMyHome(Id);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       } 
       #endregion

    }
}
