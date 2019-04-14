using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
 using Tz888.Model.MyHome;

namespace Tz888.IDAL.MyHome
{
   public interface IHomeLink
    {
       /// <summary>
       /// ��ȡ��ҳ�б�
       /// </summary>
       /// <returns></returns>
       MyHomeLink GetAllhome();
       /// <summary>
       /// ��ȡ��ҳ�б�
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
       DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount);
       /// <summary>
       /// ����IDɾ����Ϣ
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       int deleteMyHome(int Id);
    }
}
