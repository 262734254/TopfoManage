using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Link
{
    /// <summary>
    /// 友情链接
    /// </summary>
    public class LinkInfoTab:Tz888.IDAL.Link.ILinkInfoTab
    {
        #region LinkInfoTab 成员
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
        /// 获取友情链接详情
        /// </summary>
        /// <param name="LinkInfoId">LinkInfoId</param>
        /// <returns></returns>
        public DataTable GetLinkById(string LinkInfoId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select a.LinkInfoId,a.Sort,a.ChannelId,a.LinkId,b.ChannelName,c.LinkName,a.LinkInfoName,a.LinkUrl");
            sb.Append(",a.Logo,a.Remarks from LinkInfoTab as a left join LinkChannelType as b on");
            sb.Append(" a.ChannelId=b.ChannelId left join LinkTypeTab as c on");
            sb.Append(" a.LinkId=c.LinkId where a.LinkInfoId=@LinkInfoId");
            SqlParameter[] Paras = new SqlParameter[] {
                new SqlParameter("@LinkInfoId",SqlDbType.Int,4)
            };
            Paras[0].Value = LinkInfoId;
            return crm.GetDataSet(sb.ToString(), Paras);
        }

        /// <summary>
        /// 添加友情链接
        /// </summary>
        /// <param name="LinkInfoTab">LinkInfoTab</param>
        /// <returns></returns>
        public bool AddLink(Tz888.Model.Link.LinkInfoTab Type)
        {
            string sql = "insert into LinkInfoTab(ChannelId,LinkId,LinkInfoName,LinkUrl,Sort,Logo,Remarks) " +
                "values(@ChannelId,@LinkId,@LinkInfoName,@LinkUrl,@Sort,@Logo,@Remarks)";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@ChannelId",SqlDbType.Int,4),
                new SqlParameter("@LinkId",SqlDbType.Int,4),
                new SqlParameter("@LinkInfoName",SqlDbType.NVarChar,100),
                new SqlParameter("@LinkUrl",SqlDbType.NVarChar,200),
                new SqlParameter("@Sort",SqlDbType.Int,4),
                new SqlParameter("@Logo",SqlDbType.NVarChar,200),
                new SqlParameter("@Remarks",SqlDbType.NVarChar,200)
            };
            Paras[0].Value = Type.ChannelId;
            Paras[1].Value = Type.LinkId;
            Paras[2].Value = Type.LinkInfoName;
            Paras[3].Value = Type.LinkUrl;
            Paras[4].Value = Type.Sort;
            Paras[5].Value = Type.Logo;
            Paras[6].Value = Type.Remarks;
            int row = crm.ExecuteSql(sql, Paras);

            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改友情链接
        /// </summary>
        /// <param name="LinkInfo">Model</param>
        /// <returns></returns>
        public bool ModfiyLink(Tz888.Model.Link.LinkInfoTab LinkInfo)
        {
            string sql = "update LinkInfoTab set ChannelId=@ChannelId,LinkId=@LinkId,LinkInfoName=@LinkInfoName,LinkUrl=@LinkUrl,Sort=@Sort,Logo=@Logo,Remarks=@Remarks where LinkInfoId=@LinkInfoId";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@ChannelId",SqlDbType.Int,4),
                new SqlParameter("@LinkId",SqlDbType.Int,4),
                new SqlParameter("@LinkInfoName",SqlDbType.NVarChar,100),
                new SqlParameter("@LinkUrl",SqlDbType.NVarChar,200),
                new SqlParameter("@Sort",SqlDbType.Int,4),
                new SqlParameter("@Logo",SqlDbType.NVarChar,200),
                new SqlParameter("@Remarks",SqlDbType.NVarChar,200),
                new SqlParameter("@LinkInfoId",SqlDbType.Int,4)
            };
            Paras[0].Value = LinkInfo.ChannelId;
            Paras[1].Value = LinkInfo.LinkId;
            Paras[2].Value = LinkInfo.LinkInfoName;
            Paras[3].Value = LinkInfo.LinkUrl;
            Paras[4].Value = LinkInfo.Sort;
            Paras[5].Value = LinkInfo.Logo;
            Paras[6].Value = LinkInfo.Remarks;
            Paras[7].Value = LinkInfo.LinkInfoId;
            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }


        public bool DelLinkById(string LinkInfoId)
        {
            string sql = "delete LinkInfoTab where LinkInfoId=@LinkInfoId";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@LinkInfoId",SqlDbType.Int,4)
            };
            Paras[0].Value = LinkInfoId;
            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}
