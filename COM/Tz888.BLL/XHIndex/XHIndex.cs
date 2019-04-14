using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DBUtility;
using System.Data;
namespace GZS.BLL.XHIndex
{
    public class XHIndex
    {
        /// <summary>
        /// ���̣�Ͷ�ʣ�����
        /// </summary>
        /// <param name="type"></param>
        /// <param name="topNum"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public DataSet GetProject(string type, int topNum, int statu, string loginName)
        {
            string sql = "select top " + topNum + " title,htmlFile,infoid  from MainInfoTab where AuditingStatus=" + statu + " and infotypeid='" + type + "' and loginName='" + loginName + "' order by newid() desc";// publishT
            return DbHelperSQL.Query(sql);
        }
        /// <summary>
        /// �����ղ�
        /// </summary>
        /// <param name="topNum"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public DataSet GetCollection(int topNum, string loginName)
        {
            //select top "+topNum+" ID,LoginName,Title,WorthPoint,InfoTypeName,HtmlFile,InfoOverdueTime,InfoTypeID,PublishMan,MainPointCount from InfoViewCollectionVIW";
            string sql = "select  top " + topNum + "  Title,HtmlFile,auditingStatus from InfoViewCollectionVIW where auditingStatus=1 and loginName='" + loginName + "'  order by newid() desc";// publishT
            return DbHelperSQL.Query(sql);
        }
        /// <summary>
        /// �Ƽ���Դ
        /// </summary>
        /// <param name="topNum"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public DataSet GetRecommResoure(int topNum, string loginName)
        {
            string sql = "select top " + topNum + " * from recommResource where RecommToUser='" + loginName + "' order by newid() desc";//recommdate
            CrmDBHelper topfocrm = new CrmDBHelper();
            return topfocrm.Query(sql);
        }
        /// <summary>
        /// רҵ����
        /// </summary>
        /// <param name="topNum"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public DataSet GetProfessional(int topNum, string loginName)
        {
            string sql = "SELECT top " + topNum + " titel,htmlURL,LoginName,typetId  FROM ProfessionalinfoTab WHERE typetId<>3 and auditid=1 and LOGINName='" + loginName + "' order by newid() desc";//createDate
            return DbHelperSQL.Query(sql);
        }
    }
}
