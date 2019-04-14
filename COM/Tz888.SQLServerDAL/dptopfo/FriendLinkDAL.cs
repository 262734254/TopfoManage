using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace GZS.DAL
{
   public class FriendLinkDAL
    {
        string MerchantTmpPathTo = ConfigurationManager.AppSettings["DKNewsSuccsePath"].ToString(); //成功案例生成页面存放位置
        string CasesTem = ConfigurationManager.AppSettings["DKFriendLink"].ToString(); //其他成功案例模版存放位置
        string merchantimage = ConfigurationManager.AppSettings["Upimagecn001"].ToString();
        /// <summary>
        ///创建首页友情链接静态页面
        /// </summary>
        public int StaticHtml(string loginname)
        {

            try
            {
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容

                string TempSoure = Tem;
                GZS.DAL.product.CommStatic dal = new GZS.DAL.product.CommStatic();
                TempSoure = TempSoure.Replace("$cntex$", dal.GetListFriend(loginname));
                //string[] html = htmlFile.Split('/');


                //string[] nn = html[2].Split('_');
                //string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo + loginname + "/";

                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);


                }
                string htmlpaths = MerchantTmpPathTo + loginname + "/FriendLink.htm";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }

        }
        /// <summary>
        /// 作用：添加友情链接
        /// 参数：实体对象
        /// 作者：颜品庄
        /// 2011-05-09
        /// </summary>
       public int Add(FriendLink model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into FriendLink(");
           strSql.Append("Linkname,Linkurl,loginName,linkdate)");
           strSql.Append(" values (");
           strSql.Append("@Linkname,@Linkurl,@loginName,@linkdate)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@Linkname", SqlDbType.NVarChar,100),
					new SqlParameter("@Linkurl", SqlDbType.NVarChar,200),
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@linkdate", SqlDbType.DateTime)};
           parameters[0].Value = model.Linkname;
           parameters[1].Value = model.Linkurl;
           parameters[2].Value = model.loginName;
           parameters[3].Value = model.linkdate;

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
       /// 作用：更改友情链接
       /// 参数：实体对象
       /// 作者：颜品庄
       /// 2011-05-09
       /// </summary>
       public int Update(FriendLink model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update FriendLink set ");
           strSql.Append("Linkname=@Linkname,");
           strSql.Append("Linkurl=@Linkurl,");
           strSql.Append("loginName=@loginName,");
           strSql.Append("linkdate=@linkdate");
           strSql.Append(" where Linkid=@Linkid ");
           SqlParameter[] parameters = {
					new SqlParameter("@Linkid", SqlDbType.Int,4),
					new SqlParameter("@Linkname", SqlDbType.NVarChar,100),
					new SqlParameter("@Linkurl", SqlDbType.NVarChar,200),
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@linkdate", SqlDbType.DateTime)};
           parameters[0].Value = model.Linkid;
           parameters[1].Value = model.Linkname;
           parameters[2].Value = model.Linkurl;
           parameters[3].Value = model.loginName;
           parameters[4].Value = model.linkdate;

           return DBHelper.ExecuteCommand(strSql.ToString(), parameters);
       }
       public int Updates(FriendLink model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update FriendLink set ");
           strSql.Append("Linkname=@Linkname,");
           strSql.Append("Linkurl=@Linkurl ");
           strSql.Append(" where Linkid=@Linkid ");
           SqlParameter[] parameters = {
					new SqlParameter("@Linkid", SqlDbType.Int,4),
					new SqlParameter("@Linkname", SqlDbType.NVarChar,100),
					new SqlParameter("@Linkurl", SqlDbType.NVarChar,200)};
           parameters[0].Value = model.Linkid;
           parameters[1].Value = model.Linkname;
           parameters[2].Value = model.Linkurl;

           return DBHelper.ExecuteCommand(strSql.ToString(), parameters);
       }
       public int Delete(int Linkid)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from FriendLink ");
           strSql.Append(" where Linkid=@Linkid ");
           SqlParameter[] parameters = {
					new SqlParameter("@Linkid", SqlDbType.Int,4)};
           parameters[0].Value = Linkid;

           return DBHelper.ExecuteCommand(strSql.ToString(), parameters);
       }

       public FriendLink GetModel(int Linkid)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 Linkid,Linkname,Linkurl,loginName,linkdate from FriendLink ");
           strSql.Append(" where Linkid=@Linkid ");
           SqlParameter[] parameters = {
					new SqlParameter("@Linkid", SqlDbType.Int,4)};
           parameters[0].Value = Linkid;

           FriendLink model = new FriendLink();
           DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["Linkid"].ToString() != "")
               {
                   model.Linkid = int.Parse(ds.Tables[0].Rows[0]["Linkid"].ToString());
               }
               model.Linkname = ds.Tables[0].Rows[0]["Linkname"].ToString();
               model.Linkurl = ds.Tables[0].Rows[0]["Linkurl"].ToString();
               model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
               if (ds.Tables[0].Rows[0]["linkdate"].ToString() != "")
               {
                   model.linkdate = ds.Tables[0].Rows[0]["linkdate"].ToString();
               }
               return model;
           }
           else
           {
               return null;
           }
       }

       public List<FriendLink> GetModelList(string loginName)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select Linkid,Linkname,Linkurl,loginName,linkdate from FriendLink ");
           strSql.Append(" where loginName=@loginName order by Linkid desc");
           SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.VarChar,50)};
           parameters[0].Value = loginName;

           List<FriendLink> list = new List<FriendLink>();
           DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
           foreach(DataRow row in ds.Tables [0].Rows)
           {
               FriendLink model = new FriendLink();
               if (row["Linkid"].ToString() != "")
               {
                   model.Linkid = int.Parse(row["Linkid"].ToString());
               }
               model.Linkname =row["Linkname"].ToString();
               model.Linkurl = row["Linkurl"].ToString();
               model.loginName = row["loginName"].ToString();
               if (row["linkdate"].ToString() != "")
               {
                   model.linkdate =row["linkdate"].ToString();
               }
               list.Add(model);
           }
           return list;
       }
    }
}
