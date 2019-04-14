using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Link
{
    /// <summary>
    /// 链接类别
    /// </summary>
    public class LinkTypeTab:Tz888.IDAL.Link.ILinkTypeTab
    {
        #region ILinkTypeTab 成员

        CrmDBHelper crm = new CrmDBHelper();

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
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
											new SqlParameter("@Key",SqlDbType.VarChar,50),
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
											new SqlParameter("@Page",SqlDbType.BigInt),
											new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt)
										};

            parameters[0].Value = TableViewName;
            parameters[1].Value = Key;
            parameters[2].Value = SelectStr;
            parameters[3].Value = Criteria;
            parameters[4].Value = Sort;
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = CurrentPage;
            parameters[6].Value = PageSize;
            parameters[7].Direction = ParameterDirection.InputOutput;

            DataSet ds = crm.RunProcedure("GetDataList", parameters, "ds");

            if (ds == null)
                return null;
            dt = ds.Tables["ds"];
            if (dt != null)
            {
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt64(parameters[7].Value);
                    CurrentPage = Convert.ToInt64(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt64(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        CurrentPage = 1;
                    }
                    else
                    {
                        CurrentPage = 0;
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// 根据链接类别Id删除但前类别
        /// </summary>
        /// <param name="TypeId">类别ID</param>
        /// <returns></returns>
        public bool DelTypeById(string TypeId)
        {
                return false;
        }

        /// <summary>
        /// 链接类别审核
        /// </summary>
        /// <param name="LinkInfo">Model.Link.LinkInfoTab</param>
        /// <returns></returns>
        public bool UpdateTypeById(Tz888.Model.Link.LinkTypeTab LinkType)
        {
            string sql = "update LinkTypeTab set LinkName=@LinkName,CheckId=@CheckId,Remarks=@Remarks where LinkId=@LinkId";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@LinkName",SqlDbType.VarChar,50),
                new SqlParameter("@CheckId",SqlDbType.VarChar,50),
                new SqlParameter("@Remarks",SqlDbType.NVarChar,100),
                new SqlParameter("@LinkId",SqlDbType.Int,4)
            };
            Paras[0].Value = LinkType.LinkName;
            Paras[1].Value = LinkType.CheckId;
            Paras[2].Value = LinkType.Remarks;
            Paras[3].Value = LinkType.LinkId;
            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据链接类别
        /// </summary>
        /// <param name="TypeId">类别ID</param>
        /// <returns></returns>
        public DataTable GetTypeById(string TypeId)
        {
            string sql = "select LinkName,CheckId,Remarks from LinkTypeTab where LinkId=@TypeId";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@TypeId",SqlDbType.Int,4)
            };
            Paras[0].Value = TypeId;
            return crm.GetDataSet(sql, Paras);
        }

        /// <summary>
        /// 添加链接类别
        /// </summary>
        /// <param name="LinkTypeTab">类别</param>
        /// <returns></returns>
        public bool AddType(Tz888.Model.Link.LinkTypeTab LinkType)
        {
            string sql = "insert into LinkTypeTab(LinkName,CheckId,Remarks) values(@LinkName,@CheckId,@Remarks)";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@LinkName",SqlDbType.VarChar,50),
                new SqlParameter("@CheckId",SqlDbType.VarChar,50),
                new SqlParameter("@Remarks",SqlDbType.NVarChar,100)
            };
            Paras[0].Value = LinkType.LinkName;
            Paras[1].Value = LinkType.CheckId;
            Paras[2].Value = LinkType.Remarks;
            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 链接类别列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetLinkTypeList()
        {
            string sql = "select LinkId,LinkName from LinkTypeTab  where CheckId=1";
            return crm.GetDataSet(sql);
        }

        #endregion
    }
}
