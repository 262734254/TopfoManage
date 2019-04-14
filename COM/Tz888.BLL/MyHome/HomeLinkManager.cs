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
       /// ��ѯ��ҳ�б�
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
       /// ��test���ݿ�
       /// </summary>
       /// <param name="TableViewName">����</param>
       /// <param name="Key">����</param>
       /// <param name="SelectStr">��ѯ�ֶ�</param>
       /// <param name="Criteria">����</param>
       /// <param name="Sort">�����ֶ�</param>
       /// <param name="CurrentPage">��ǰҳ</param>
       /// <param name="PageSize">ҳ��С</param>
       /// <param name="TotalCount">�ܼ�¼</param>
       /// <returns></returns>
       public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
           ref long CurrentPage, long PageSize, ref long TotalCount)
       {
           return dal.GetListT(TableViewName, Key, SelectStr, Criteria, Sort,
           ref CurrentPage, PageSize, ref TotalCount);
       }


       /// <summary>
       /// ��test���ݿ�
       /// </summary>
       /// <param name="TableViewName">����</param>
       /// <param name="Key">����</param>
       /// <param name="SelectStr">��ѯ�ֶ�</param>
       /// <param name="Criteria">����</param>
       /// <param name="Sort">�����ֶ�</param>
       /// <param name="CurrentPage">��ǰҳ</param>
       /// <param name="PageSize">ҳ��С</param>
       /// <param name="TotalCount">�ܼ�¼</param>
       /// <returns></returns>
       public DataTable GetListCrm(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
           ref long CurrentPage, long PageSize, ref long TotalCount)
       {
           return dal.GetListCrm(TableViewName, Key, SelectStr, Criteria, Sort,
           ref CurrentPage, PageSize, ref TotalCount);
       }
       #region ��ҳ��ѯ
       /// <summary>
       /// ��test���ݿ�
       /// </summary>
       /// <param name="TableViewName">����</param>
       /// <param name="Key">����</param>
       /// <param name="SelectStr">��ѯ�ֶ�</param>
       /// <param name="Criteria">����</param>
       /// <param name="Sort">�����ֶ�</param>
       /// <param name="CurrentPage">��ǰҳ</param>
       /// <param name="PageSize">ҳ��С</param>
       /// <param name="TotalCount">�ܼ�¼</param>
       /// <returns></returns>
       public DataTable GetListTS(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
           ref long CurrentPage, long PageSize, ref long TotalCount)
       { 
           return dal.GetListTS(TableViewName, Key, SelectStr, Criteria, Sort,
           ref CurrentPage, PageSize, ref TotalCount);
       } 
       #endregion
       #region ɾ����Ϣ
       /// <summary>
       /// ɾ����Ϣ
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
