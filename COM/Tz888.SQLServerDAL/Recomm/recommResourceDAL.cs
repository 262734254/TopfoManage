using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL.Recomm;
using Tz888.DBUtility;
using Tz888.Model.Info;
namespace Tz888.SQLServerDAL.Recomm
{
    /// <summary>
    /// ���ݷ�����:recommResourceDAL
    /// </summary>
    public partial class recommResourceDAL : recommResourceIDAL
    {
        CrmDBHelper crm = new CrmDBHelper();
        public recommResourceDAL()
        { }
        #region  Method
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int RecommID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from recommResource");
            strSql.Append(" where RecommID=@RecommID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RecommID", SqlDbType.Int,4)};
            parameters[0].Value = RecommID;

            return crm.Exist(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ��topfocrm���ݿ�
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
            //parameters[7].Value = 1;

            //DataSet ds = Tz888.DBUtility.DbHelperSQL.RunProcedure("GetDataList", parameters, "ds");
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
        /// ����һ������
        /// </summary>
        public int Add(Tz888.Model.Recomm.recommResourceM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into recommResource(");
            strSql.Append("ResourceId,ResourceTitle,ResourceTypeId,ResourceUrl,RecommName,RecommToUser,RecommDate)");
            strSql.Append(" values (");
            strSql.Append("@ResourceId,@ResourceTitle,@ResourceTypeId,@ResourceUrl,@RecommName,@RecommToUser,getdate())");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceId", SqlDbType.BigInt,8),
					new SqlParameter("@ResourceTitle", SqlDbType.VarChar,200),
					new SqlParameter("@ResourceTypeId", SqlDbType.Int,4),
					new SqlParameter("@ResourceUrl", SqlDbType.VarChar,100),
					new SqlParameter("@RecommName", SqlDbType.VarChar,50),
					new SqlParameter("@RecommToUser", SqlDbType.VarChar,50)
					//new SqlParameter("@RecommDate", SqlDbType.DateTime)
            };
            parameters[0].Value = model.ResourceId;
            parameters[1].Value = model.ResourceTitle;
            parameters[2].Value = model.ResourceTypeId;
            parameters[3].Value = model.ResourceUrl;
            parameters[4].Value = model.RecommName;
            parameters[5].Value = model.RecommToUser;
            //parameters[6].Value = model.RecommDate;

            object obj = crm.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// �Ƽ� �������л�ȡ���� title ,url
        /// ���ӵ����ݿⲻͬ
        /// </summary>
        /// <param name="infoid"></param>
        /// <returns>MainInfoModel</returns>
        public DataSet GetTitleAndUrlByInfoId(string infoid)
        {
            string sql = "select title,htmlFile,infoid from MainInfoTab where infoid in(" + infoid + ")";
            //SqlParameter[] parameters = { new SqlParameter("@infoid", SqlDbType.VarChar, 100) };
            MainInfoModel model = new MainInfoModel();
            // parameters[0].Value = infoid;
            DataSet ds = DbHelperSQL.Query(sql.ToString());
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    if (ds.Tables[0].Rows[0]["title"].ToString() != "")
            //    {
            //        model.Title = ds.Tables[0].Rows[0]["title"].ToString();
            //    }
            //    if (ds.Tables[0].Rows[0]["htmlFile"].ToString() != "")
            //    {
            //        model.HtmlFile = ds.Tables[0].Rows[0]["htmlFile"].ToString();
            //    }
            //}
            //return model;
            return ds;

        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Tz888.Model.Recomm.recommResourceM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update recommResource set ");
            strSql.Append("ResourceId=@ResourceId,");
            strSql.Append("ResourceTitle=@ResourceTitle,");
            strSql.Append("ResourceTypeId=@ResourceTypeId,");
            strSql.Append("ResourceUrl=@ResourceUrl,");
            strSql.Append("RecommName=@RecommName,");
            strSql.Append("RecommToUser=@RecommToUser");
            //strSql.Append("RecommDate=@RecommDate");
            strSql.Append(" where RecommID=@RecommID");
            SqlParameter[] parameters = {
					new SqlParameter("@RecommID", SqlDbType.Int,4),
					new SqlParameter("@ResourceId", SqlDbType.BigInt,8),
					new SqlParameter("@ResourceTitle", SqlDbType.VarChar,200),
					new SqlParameter("@ResourceTypeId", SqlDbType.Int,4),
					new SqlParameter("@ResourceUrl", SqlDbType.VarChar,100),
					new SqlParameter("@RecommName", SqlDbType.VarChar,50),
					new SqlParameter("@RecommToUser", SqlDbType.VarChar,50)
					//new SqlParameter("@RecommDate", SqlDbType.DateTime)
        };
            parameters[0].Value = model.RecommID;
            parameters[1].Value = model.ResourceId;
            parameters[2].Value = model.ResourceTitle;
            parameters[3].Value = model.ResourceTypeId;
            parameters[4].Value = model.ResourceUrl;
            parameters[5].Value = model.RecommName;
            parameters[6].Value = model.RecommToUser;
            //parameters[7].Value = model.RecommDate;

            int rows = crm.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int RecommID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from recommResource ");
            strSql.Append(" where RecommID=@RecommID");
            SqlParameter[] parameters = {
					new SqlParameter("@RecommID", SqlDbType.Int,4)
};
            parameters[0].Value = RecommID;

            int rows = crm.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string RecommIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from recommResource ");
            strSql.Append(" where RecommID in (" + RecommIDlist + ")  ");
            int rows = crm.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tz888.Model.Recomm.recommResourceM GetModel(int RecommID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RecommID,ResourceId,ResourceTitle,ResourceTypeId,ResourceUrl,RecommName,RecommToUser,RecommDate from recommResource ");
            strSql.Append(" where RecommID=@RecommID");
            SqlParameter[] parameters = {
					new SqlParameter("@RecommID", SqlDbType.Int,4)
};
            parameters[0].Value = RecommID;

            Tz888.Model.Recomm.recommResourceM model = new Tz888.Model.Recomm.recommResourceM();
            DataSet ds = crm.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RecommID"].ToString() != "")
                {
                    model.RecommID = int.Parse(ds.Tables[0].Rows[0]["RecommID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ResourceId"].ToString() != "")
                {
                    model.ResourceId = long.Parse(ds.Tables[0].Rows[0]["ResourceId"].ToString());
                }
                model.ResourceTitle = ds.Tables[0].Rows[0]["ResourceTitle"].ToString();
                if (ds.Tables[0].Rows[0]["ResourceTypeId"].ToString() != "")
                {
                    model.ResourceTypeId = int.Parse(ds.Tables[0].Rows[0]["ResourceTypeId"].ToString());
                }
                model.ResourceUrl = ds.Tables[0].Rows[0]["ResourceUrl"].ToString();
                model.RecommName = ds.Tables[0].Rows[0]["RecommName"].ToString();
                model.RecommToUser = ds.Tables[0].Rows[0]["RecommToUser"].ToString();
                if (ds.Tables[0].Rows[0]["RecommDate"].ToString() != "")
                {
                    model.RecommDate = DateTime.Parse(ds.Tables[0].Rows[0]["RecommDate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RecommID,ResourceId,ResourceTitle,ResourceTypeId,ResourceUrl,RecommName,RecommToUser,RecommDate ");
            strSql.Append(" FROM recommResource ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return crm.Query(strSql.ToString());
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" RecommID,ResourceId,ResourceTitle,ResourceTypeId,ResourceUrl,RecommName,RecommToUser,RecommDate ");
            strSql.Append(" FROM recommResource ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return crm.Query(strSql.ToString());
        }
        /// <summary>
        /// ��ѯ�����û���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SelCompanyUserName()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select loginName from LoginInfoTab order by registertime desc";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append("'" + row["loginName"].ToString() + "',");
                }
            }
            return sb.ToString();

        }
        /// <summary>
        /// ����������ѯ�Ƿ��������
        /// </summary>
        /// <param name="RecommTypeID">��Դ����1,���̡����ʡ�Ͷ��2,�˲�3,����4, ����</param>
        /// <param name="RecommToUser">�Ƽ��û�</param>
        /// <param name="ResourecId">�Ƽ���ԴID</param>
        /// <returns></returns>
        public int ExistsByWhere(int RecommTypeID, string RecommToUser, long ResourecId)
        {
            string sql = "select recommid FROM RecommResource where ResourceTypeId=@ResourceTypeId and RecommToUser=@RecommToUser and ResourceId=@ResourceId";
            SqlParameter[] para ={ 
                new SqlParameter("@ResourceTypeId",SqlDbType.Int,4),
                new SqlParameter("@RecommToUser",SqlDbType.VarChar,50),
                new SqlParameter("@ResourceId",SqlDbType.BigInt,8)
            };
            para[0].Value = RecommTypeID;
            para[1].Value = RecommToUser;
            para[2].Value = ResourecId;

            DataSet ds = crm.Query(sql, para);
            if ((ds != null) && ds.Tables[0].Rows.Count > 0)
            {
                return int.Parse(ds.Tables[0].Rows[0]["recommid"].ToString());
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// ���������Ѿ��Ƽ�����ֻ�����ʱ��
        /// </summary>
        /// <returns></returns>
        public int UpdateTimeByRecommId(int recommId)
        {
            string sql = "update RecommResource set RecommDate=getdate() where RecommID="+recommId;
            return crm.ExecuteSql(sql);
        }
        #endregion  Method
    }

}

