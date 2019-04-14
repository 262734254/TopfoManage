using System;
using System.Collections.Generic;
using GZS.Model.policy;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace GZS.DAL.policy
{
    public class PolicyDAL
    {
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PolicyModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into policyTab(");
            strSql.Append("loginName,Chineseintroduced,Englishintroduction,createdate,Clicks,htmlUrl)");
            strSql.Append(" values (");
            strSql.Append("@loginName,@Chineseintroduced,@Englishintroduction,getdate(),0,@htmlUrl)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@Chineseintroduced", SqlDbType.Text),
					new SqlParameter("@Englishintroduction", SqlDbType.Text),
                    new SqlParameter("@htmlUrl", SqlDbType.VarChar,150)
					//new SqlParameter("@createdate", SqlDbType.DateTime),
					//new SqlParameter("@Clicks", SqlDbType.Int,4)
            };
            parameters[0].Value = model.loginName;
            parameters[1].Value = model.Chineseintroduced;
            parameters[2].Value = model.Englishintroduction;
            parameters[3].Value = model.htmlUrl; ;
            // parameters[3].Value = model.createdate;
            //parameters[3].Value = model.Clicks;

            object obj = DBHelper.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(PolicyModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update policyTab set ");
            //strSql.Append("loginName=@loginName,");
            strSql.Append("Chineseintroduced=@Chineseintroduced,");
            strSql.Append("Englishintroduction=@Englishintroduction,");
            strSql.Append("htmlUrl=@htmlUrl");
            //strSql.Append("Clicks=@Clicks");
            strSql.Append(" where policyId=@policyId");
            SqlParameter[] parameters = {
					new SqlParameter("@policyId", SqlDbType.Int,4),
					//new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@Chineseintroduced", SqlDbType.Text),
					new SqlParameter("@Englishintroduction", SqlDbType.Text),
					new SqlParameter("@htmlUrl", SqlDbType.VarChar,150),
					//new SqlParameter("@Clicks", SqlDbType.Int,4)
            };
            parameters[0].Value = model.policyId;
           // parameters[1].Value = model.loginName;
            parameters[1].Value = model.Chineseintroduced;
            parameters[2].Value = model.Englishintroduction;
            parameters[3].Value = model.htmlUrl;
            //parameters[5].Value = model.Clicks;

            int rows = DBHelper.ExecuteSql(strSql.ToString(), parameters);
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
        /// 根据用户名查找是否有记录数
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool ExistsName(string loginName)
        {

            string sql = "select count(loginname) as loginname from dbo.policyTab where loginname='" + loginName + "'";
            DataSet ds = DBHelper.Query(sql);
            if (int.Parse(ds.Tables[0].Rows[0]["loginname"].ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 访问率
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ModfiyHit(int id)
        {
            int num = 0;
            string sql = "select Clicks from policyTab where policyId=@id";
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int,8)
            };
            para[0].Value = id;
            num = Convert.ToInt32(DBHelper.GetSingle(sql, para).ToString());
            int Hit = num + 1;
            string sqll = "update policyTab set Clicks=@Clicks where policyId=@id";
            SqlParameter[] sqlpara ={ 
                 new SqlParameter("@Clicks",SqlDbType.Int,8),
                new SqlParameter("@id",SqlDbType.Int,8)
            };
            sqlpara[0].Value = Hit;
            sqlpara[1].Value = id;
            int com = Convert.ToInt32(DBHelper.GetSingle(sqll, sqlpara));
            return Hit;
        }
        /// <summary>
        /// by user name get data 
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public PolicyModel GetPolicyByName(string loginName)
        {
            PolicyModel model = new PolicyModel();
            string sql = "select * from dbo.policyTab where loginname='" + loginName + "'";
            DataSet ds= DBHelper.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["policyId"].ToString() != "")
                {
                    model.policyId = int.Parse(ds.Tables[0].Rows[0]["policyId"].ToString());
                }
                model.Chineseintroduced = ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
                model.Englishintroduction = ds.Tables[0].Rows[0]["Englishintroduction"].ToString();
                if (ds.Tables[0].Rows[0]["Clicks"].ToString() != "")
                {
                    model.Clicks = int.Parse(ds.Tables[0].Rows[0]["Clicks"].ToString());
                }
                if (ds.Tables[0].Rows[0]["htmlUrl"].ToString() != "")
                {
                    model.htmlUrl = ds.Tables[0].Rows[0]["htmlUrl"].ToString();
                }
                else
                {
                    model.htmlUrl = "";
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PolicyModel GetModel(int policy)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 policyId,htmlUrl,loginName,Chineseintroduced,Englishintroduction,createdate,Clicks from policyTab ");
            strSql.Append(" where policyId=@policyId");
            SqlParameter[] parameters = {
					new SqlParameter("@policyId", SqlDbType.Int,4)
};
            parameters[0].Value = policy;

            PolicyModel model = new PolicyModel();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["policyId"].ToString() != "")
                {
                    model.policyId = int.Parse(ds.Tables[0].Rows[0]["policyId"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                if (ds.Tables[0].Rows[0]["htmlUrl"].ToString() != "")
                {
                    model.htmlUrl = ds.Tables[0].Rows[0]["htmlUrl"].ToString();
                }
                else
                {
                    model.htmlUrl ="";
                }
                
                model.Chineseintroduced = ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
                model.Englishintroduction = ds.Tables[0].Rows[0]["Englishintroduction"].ToString();
                if (ds.Tables[0].Rows[0]["createdate"].ToString() != "")
                {
                    model.createdate = DateTime.Parse(ds.Tables[0].Rows[0]["createdate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Clicks"].ToString() != "")
                {
                    model.Clicks = int.Parse(ds.Tables[0].Rows[0]["Clicks"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  Method
    }
}
