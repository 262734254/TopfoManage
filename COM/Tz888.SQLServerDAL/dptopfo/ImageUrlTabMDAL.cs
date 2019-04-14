using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace GZS.DAL
{
   public class ImageUrlTabMDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GZS .Model .ImageUrlTabM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ImageUrlTab(");
            strSql.Append("Imageid,Imagepath,imgexplain)");
            strSql.Append(" values (");
            strSql.Append("@Imageid,@Imagepath,@imgexplain)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Imageid", SqlDbType.Int,4),
					new SqlParameter("@Imagepath", SqlDbType.NVarChar,400),
					new SqlParameter("@imgexplain", SqlDbType.NVarChar,400)};
            parameters[0].Value = model.Imageid;
            parameters[1].Value = model.Imagepath;
            parameters[2].Value = model.imgexplain;

            return DBHelper.ExecuteCommand(strSql.ToString(), parameters);

        }
       //通过相册主表的ID获取从表相册的集合
       public List<GZS.Model.ImageUrlTabM> GetAllByImageIds(int imageid)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select parktypeid,Imageid,Imagepath,imgexplain from ImageUrlTab ");
           strSql.Append(" where Imageid=@parktypeid order by parktypeid desc ");
           SqlParameter[] parameters = {
					new SqlParameter("@parktypeid", SqlDbType.Int,4)};
           parameters[0].Value = imageid;


           DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
           List<GZS.Model.ImageUrlTabM> list = new List<GZS.Model.ImageUrlTabM>();
           foreach (DataRow row in ds.Tables[0].Rows)
           {
               GZS.Model.ImageUrlTabM model = new GZS.Model.ImageUrlTabM();
               if (row["parktypeid"].ToString() != "")
               {
                   model.parktypeid = int.Parse(row["parktypeid"].ToString());
               }
               if (row["Imageid"].ToString() != "")
               {
                   model.Imageid = int.Parse(row["Imageid"].ToString());
               }
               model.Imagepath = row["Imagepath"].ToString();
               model.imgexplain = row["imgexplain"].ToString();
               list.Add(model);
           }
           return list;
       }
       public List<GZS.Model.ImageUrlTabM> GetAllByImageId(int imageid)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select parktypeid,Imageid,Imagepath,imgexplain from ImageUrlTab ");
           strSql.Append(" where Imageid=@parktypeid order by parktypeid asc ");
           SqlParameter[] parameters = {
					new SqlParameter("@parktypeid", SqlDbType.Int,4)};
           parameters[0].Value = imageid;


           DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
           List<GZS.Model.ImageUrlTabM> list = new List<GZS.Model.ImageUrlTabM>();
           foreach (DataRow row in ds.Tables[0].Rows)
           {
               GZS.Model.ImageUrlTabM model = new GZS.Model.ImageUrlTabM();
               if (row["parktypeid"].ToString() != "")
               {
                   model.parktypeid = int.Parse(row["parktypeid"].ToString());
               }
               if (row["Imageid"].ToString() != "")
               {
                   model.Imageid = int.Parse(row["Imageid"].ToString());
               }
               model.Imagepath = row["Imagepath"].ToString();
               model.imgexplain =row["imgexplain"].ToString();
               list.Add(model);
           }
           return list;
       }
       //用于生成静态页面根据主表的用户名去查询相册从表相对应的相片集合
       public List<GZS.Model.ImageUrlTabM> GetAlls(string loginname)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select distinct(ImageUrlTab.Imageid),imagename from ImageUrlTab inner join imagetab on imagetab.imageid=imageurltab.imageid where LoginName=@loginname order by ImageUrlTab.Imageid desc");

           DataSet ds = DBHelper.Query(strSql.ToString(), new SqlParameter("@loginname",loginname));
           List<GZS.Model.ImageUrlTabM> list = new List<GZS.Model.ImageUrlTabM>();
           foreach (DataRow row in ds.Tables[0].Rows)
           {
               GZS.Model.ImageUrlTabM model = new GZS.Model.ImageUrlTabM();
               if (row["Imageid"].ToString() != "")
               {
                   model.Imageid = int.Parse(row["Imageid"].ToString());
               }
               if (row["imagename"].ToString().Trim() != "")
               {
                   model.imgexplain = row["imagename"].ToString();
               }
               list.Add(model);
           }
           return list;
       }
       //删除相册的从表的一条记录
       public int Delete(int parktypeid)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from ImageUrlTab ");
           strSql.Append(" where parktypeid=@parktypeid ");
           SqlParameter[] parameters = {
					new SqlParameter("@parktypeid", SqlDbType.Int,4)};
           parameters[0].Value = parktypeid;

           return DBHelper.ExecuteCommand(strSql.ToString(), parameters);
       }
       public int DeleteByImageid(int Imageid)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from ImageUrlTab ");
           strSql.Append(" where Imageid=@Imageid ");
           SqlParameter[] parameters = {
					new SqlParameter("@Imageid", SqlDbType.Int,4)};
           parameters[0].Value = Imageid;

           return DBHelper.ExecuteCommand(strSql.ToString(), parameters);
       }
    }

}
