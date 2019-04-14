using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.Link;
using Tz888.IDAL.Link;
using Tz888.DBUtility;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL.Link
{
    /// <summary>
    /// 页面频道
    /// </summary>
    public class LinkChannelType:ILinkChannelType
    {
        #region ILinkChannelType 成员

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
        /// 删除频道
        /// </summary>
        /// <param name="ChannelId">跑到ID</param>
        /// <returns></returns>
        public bool DelChannelById(string ChannelId)
        {
            string sql = "delete LinkChannelType where ChannelId=@ChannelId";
            SqlParameter[] Paras = new SqlParameter[] { 
               new SqlParameter("@ChannelId",SqlDbType.Int,4)
            };
            Paras[0].Value = ChannelId;
            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="Channel">频道</param>
        /// <returns></returns>
        public bool UpdateChannelById(Tz888.Model.Link.LinkChannelType Channel)
        {
            string sql = "update LinkChannelType set ChannelName=@ChannelName,CheckId=@CheckId,Remarks=@Remarks where ChannelId=@ChannelId";
            SqlParameter[] Paras = new SqlParameter[] { 
               new SqlParameter("@ChannelId",SqlDbType.Int,4),
               new SqlParameter("@ChannelName",SqlDbType.VarChar,50),
               new SqlParameter("@CheckId",SqlDbType.Int,4),
               new SqlParameter("@Remarks",SqlDbType.NVarChar,100)
            };
            Paras[0].Value = Channel.ChannelId;
            Paras[1].Value = Channel.ChannelName;
            Paras[2].Value = Channel.CheckId;
            Paras[3].Value = Channel.Remarks;
            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据频道Id获取对应的频道
        /// </summary>
        /// <param name="ChannelId">频道ID</param>
        /// <returns></returns>
        public DataTable GetChannelById(string ChannelId)
        {
            string sql = "select ChannelName,CheckId,Remarks from LinkChannelType where ChannelId=@ChannelId";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@ChannelId",ChannelId)
            };
            return crm.GetDataSet(sql, Paras);
        }

        /// <summary>
        /// 添加频道
        /// </summary>
        /// <param name="Channel">频道</param>
        /// <returns></returns>
        public bool AddChannel(Tz888.Model.Link.LinkChannelType Channel)
        {
            string sql = "insert into LinkChannelType(ChannelName,CheckId,Remarks) values(@ChannelName,@CheckId,@Remarks)";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@ChannelName",SqlDbType.VarChar,50),
                new SqlParameter("@CheckId",SqlDbType.Int,4),
                new SqlParameter("@Remarks",SqlDbType.NVarChar,100)
            };
            Paras[0].Value = Channel.ChannelName;
            Paras[1].Value = Channel.CheckId;
            Paras[2].Value = Channel.Remarks;
            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 频道列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetChannelList()
        {
            string sql = "select ChannelId,ChannelName from LinkChannelType where CheckId=1";
            return crm.GetDataSet(sql);
        }

        #endregion
    }
}
