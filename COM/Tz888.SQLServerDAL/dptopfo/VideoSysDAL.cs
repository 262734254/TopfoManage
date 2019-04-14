using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace GZS.DAL
{
    public class VideoSysDAL
    {
        //添加视频信息
        public int Insert(GZS.Model.VideoSysM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into VideoSys(");
            strSql.Append("loginName,videotitle,Title,Keywords,Description,htmlurl,Paytimes,smallimg,bigimg,introduction,path,form,hits,audit,sort,createdate,VidoiName,ImageNames)");
            strSql.Append(" values (");
            strSql.Append("@loginName,@videotitle,@Title,@Keywords,@Description,@htmlurl,@Paytimes,@smallimg,@bigimg,@introduction,@path,@form,@hits,@audit,@sort,@createdate,@VidoiName,@ImageNames)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.NVarChar,200),
					new SqlParameter("@videotitle", SqlDbType.NVarChar,100),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Keywords", SqlDbType.NVarChar,100),
					new SqlParameter("@Description", SqlDbType.NVarChar,100),
					new SqlParameter("@htmlurl", SqlDbType.NVarChar,100),
					new SqlParameter("@Paytimes", SqlDbType.Int,4),
					new SqlParameter("@smallimg", SqlDbType.VarChar,100),
					new SqlParameter("@bigimg", SqlDbType.VarChar,100),
					new SqlParameter("@introduction", SqlDbType.NVarChar,3000),
					new SqlParameter("@path", SqlDbType.NVarChar,200),
					new SqlParameter("@form", SqlDbType.VarChar,50),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@audit", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@createdate", SqlDbType.DateTime),
                    new SqlParameter ("@VidoiName",SqlDbType.NVarChar,200),
                    new SqlParameter ("@ImageNames",SqlDbType.NVarChar,200)
            };
            parameters[0].Value = model.loginName;
            parameters[1].Value = model.videotitle;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Keywords;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.htmlurl;
            parameters[6].Value = model.Paytimes;
            parameters[7].Value = model.smallimg;
            parameters[8].Value = model.bigimg;
            parameters[9].Value = model.introduction;
            parameters[10].Value = model.path;
            parameters[11].Value = model.form;
            parameters[12].Value = model.hits;
            parameters[13].Value = model.audit;
            parameters[14].Value = model.sort;
            parameters[15].Value = model.createdate;
            parameters[16].Value = model.VidoiName;
            parameters[17].Value = model.ImageName;

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
        //获取一个视频的实体对象
        public GZS .Model .VideoSysM GetModel(int videoid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 videoid,loginName,videotitle,Title,Keywords,Description,htmlurl,Paytimes,smallimg,bigimg,VidoiName,introduction,path,form,hits,audit,sort,createdate,ImageNames from VideoSys ");
            strSql.Append(" where videoid=@videoid ");
            SqlParameter[] parameters = {
					new SqlParameter("@videoid", SqlDbType.Int,4)};
            parameters[0].Value = videoid;

            GZS.Model.VideoSysM model = new GZS.Model.VideoSysM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["videoid"].ToString() != "")
                {
                    model.videoid = int.Parse(ds.Tables[0].Rows[0]["videoid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                model.videotitle = ds.Tables[0].Rows[0]["videotitle"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.htmlurl = ds.Tables[0].Rows[0]["htmlurl"].ToString();
                if (ds.Tables[0].Rows[0]["Paytimes"].ToString() != "")
                {
                    model.Paytimes = int.Parse(ds.Tables[0].Rows[0]["Paytimes"].ToString());
                }
                model.smallimg = ds.Tables[0].Rows[0]["smallimg"].ToString();
                model.bigimg = ds.Tables[0].Rows[0]["bigimg"].ToString();
                model.introduction = ds.Tables[0].Rows[0]["introduction"].ToString();
                model.path = ds.Tables[0].Rows[0]["path"].ToString();
                model.form = ds.Tables[0].Rows[0]["form"].ToString();
                model.VidoiName = ds.Tables[0].Rows[0]["VidoiName"].ToString();
                model.ImageName = ds.Tables[0].Rows[0]["ImageNames"].ToString();
                if (ds.Tables[0].Rows[0]["hits"].ToString() != "")
                {
                    model.hits = int.Parse(ds.Tables[0].Rows[0]["hits"].ToString());
                }
                if (ds.Tables[0].Rows[0]["audit"].ToString() != "")
                {
                    model.audit = int.Parse(ds.Tables[0].Rows[0]["audit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort"].ToString() != "")
                {
                    model.sort = int.Parse(ds.Tables[0].Rows[0]["sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["createdate"].ToString() != "")
                {
                    model.createdate =ds.Tables[0].Rows[0]["createdate"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        //通过用户名获取视频集合
        public List<GZS.Model.VideoSysM> GetAllModel(string loginname)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select videoid,loginName,videotitle,Title,Keywords,Description,htmlurl,Paytimes,smallimg,bigimg,introduction,path,form,hits,audit,sort,createdate from VideoSys ");
            strSql.Append(" where loginName=@loginName ");
            List<GZS.Model.VideoSysM> list = new List<GZS.Model.VideoSysM>();
            DataSet ds = DBHelper.Query(strSql.ToString(), new SqlParameter("@loginName", loginname));
            foreach(DataRow row in ds.Tables [0].Rows)
            {
                GZS.Model.VideoSysM model = new GZS.Model.VideoSysM();
                if (row["videoid"].ToString() != "")
                {
                    model.videoid = int.Parse(row["videoid"].ToString());
                }
                model.loginName = row["loginName"].ToString();
                model.videotitle = row["videotitle"].ToString();
                model.Title = row["Title"].ToString();
                model.Keywords = row["Keywords"].ToString();
                model.Description = row["Description"].ToString();
                model.htmlurl =row["htmlurl"].ToString();
                if (row["Paytimes"].ToString() != "")
                {
                    model.Paytimes = int.Parse(row["Paytimes"].ToString());
                }
                model.smallimg = row["smallimg"].ToString();
                model.bigimg =row["bigimg"].ToString();
                model.introduction = row["introduction"].ToString();
                model.path = row["path"].ToString();
                model.form = row["form"].ToString();
                if (row["hits"].ToString() != "")
                {
                    model.hits = int.Parse(row["hits"].ToString());
                }
                if (row["audit"].ToString() != "")
                {
                    model.audit = int.Parse(row["audit"].ToString());
                }
                if (row["sort"].ToString() != "")
                {
                    model.sort = int.Parse(row["sort"].ToString());
                }
                if (row["createdate"].ToString() != "")
                {
                    model.createdate = row["createdate"].ToString();
                }
                list.Add(model);
            }
            return list;
        }
        //作用：用户生成静态页面显示视频的底部用；
           public List<GZS.Model.VideoSysM> GetTopModel(string loginname)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 7 videoid,loginName,videotitle,Title,Keywords,Description,htmlurl,Paytimes,smallimg,bigimg,VidoiName,introduction,path,form,hits,audit,sort,createdate,ImageNames from VideoSys ");
            strSql.Append(" where loginName=@loginName order by videoid desc");
            List<GZS.Model.VideoSysM> list = new List<GZS.Model.VideoSysM>();
            DataSet ds = DBHelper.Query(strSql.ToString(), new SqlParameter("@loginName", loginname));
            foreach(DataRow row in ds.Tables [0].Rows)
            {
                GZS.Model.VideoSysM model = new GZS.Model.VideoSysM();
                if (row["videoid"].ToString() != "")
                {
                    model.videoid = int.Parse(row["videoid"].ToString());
                }
                model.loginName = row["loginName"].ToString();
                model.videotitle = row["videotitle"].ToString();
                model.Title = row["Title"].ToString();
                model.Keywords = row["Keywords"].ToString();
                model.Description = row["Description"].ToString();
                model.htmlurl =row["htmlurl"].ToString();
                model.ImageName = row["ImageNames"].ToString();
                if (row["Paytimes"].ToString() != "")
                {
                    model.Paytimes = int.Parse(row["Paytimes"].ToString());
                }
                model.smallimg = row["smallimg"].ToString();
                model.bigimg =row["bigimg"].ToString();
                model.introduction = row["introduction"].ToString();
                model.path = row["path"].ToString();
                model.form = row["form"].ToString();
                if (row["hits"].ToString() != "")
                {
                    model.hits = int.Parse(row["hits"].ToString());
                }
                if (row["audit"].ToString() != "")
                {
                    model.audit = int.Parse(row["audit"].ToString());
                }
                if (row["sort"].ToString() != "")
                {
                    model.sort = int.Parse(row["sort"].ToString());
                }
                if (row["createdate"].ToString() != "")
                {
                    model.createdate = row["createdate"].ToString();
                }
                list.Add(model);
            }
            return list;
        }
        //更新视频对象
        public int Update(GZS .Model .VideoSysM  model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VideoSys set audit=1, ");
            strSql.Append("videotitle=@videotitle,");
            strSql.Append("VidoiName=@VidoiName,");
            strSql.Append("introduction=@introduction,");
            strSql.Append("form=@form, ");
            strSql.Append("htmlurl=@htmlurl, ");
            strSql.Append("ImageNames=@ImageNames ");
            strSql.Append(" where videoid=@videoid ");
            SqlParameter[] parameters = {
					new SqlParameter("@videoid", SqlDbType.Int,4),
					new SqlParameter("@videotitle", SqlDbType.NVarChar,100),
                    new SqlParameter("@VidoiName", SqlDbType.NVarChar,100),
					new SqlParameter("@introduction", SqlDbType.NVarChar,3000),
					new SqlParameter("@form", SqlDbType.VarChar,50),
                new SqlParameter("@htmlurl", SqlDbType.NVarChar,100),
                new SqlParameter("@ImageNames", SqlDbType.NVarChar,200)
            };
            parameters[0].Value = model.videoid;
            parameters[1].Value = model.videotitle;
            parameters[2].Value = model.VidoiName;
            parameters[3].Value = model.introduction;
            parameters[4].Value = model.form;
            parameters[5].Value = model.htmlurl;
            parameters[6].Value = model.ImageName;
            return DBHelper.ExecuteCommand(strSql.ToString(), parameters);
        }
        //更新视频的HTML地址通过ID
        public int UpdateHtml(string htmlurl,int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VideoSys set audit=1, ");
            strSql.Append("htmlurl=@htmlurl ");
            strSql.Append(" where videoid=@videoid ");
            SqlParameter[] parameters = {
					new SqlParameter("@videoid", SqlDbType.Int,4),
                new SqlParameter("@htmlurl", SqlDbType.NVarChar,100)
            };
            parameters[0].Value = id;
            parameters[1].Value = htmlurl;
            return DBHelper.ExecuteCommand(strSql.ToString(), parameters);
        }
        //更新视频的HTML地址根据用户名用户生成多个静态页面时 更新原来生成的静态页面
        public int UpdateHtmls(string htmlurl, string loginname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VideoSys set audit=1, ");
            strSql.Append("htmlurl=@htmlurl ");
            strSql.Append(" where loginName=@loginName ");
            SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.NVarChar,200),
                new SqlParameter("@htmlurl", SqlDbType.NVarChar,100)
            };
            parameters[0].Value = loginname;
            parameters[1].Value = htmlurl;
            return DBHelper.ExecuteCommand(strSql.ToString(), parameters);
        }
        //删除视频
        public int Delete(int id)
        {
            string sql = "delete VideoSys where videoid=@vidid";
            int resut = DBHelper.ExecuteCommand(sql, new SqlParameter("vidid", id));
            return resut;
        }
    }
}
