using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.Picture
{
    public class PictureDAL:Tz888.IDAL.Picture.IPicture
    {
        #region IPicture 成员

        private readonly Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();

        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="picture"></param>  
        /// <returns></returns>
        public bool AddPicture(Tz888.Model.Picture.PictureInfo Picture)
        {
            string sql = "insert into PictureInfo(Title,ImgUrl,Target,SourceId,IsRecommend,ShowId,Remarks,TypeId) values(@Title,@ImgUrl,@Target,@SourceId,@IsRecommend,@ShowId,@Remarks,@TypeId)";
                SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Title",SqlDbType.VarChar,100),
                new SqlParameter("@ImgUrl",SqlDbType.VarChar,200),
                new SqlParameter("@Target",SqlDbType.VarChar,200),
                new SqlParameter("@SourceId",SqlDbType.Int,4),
                new SqlParameter("@IsRecommend",SqlDbType.Int,4),
                new SqlParameter("@ShowId",SqlDbType.Int,4),
                new SqlParameter("@Remarks",SqlDbType.VarChar,200),
                new SqlParameter("@TypeId",SqlDbType.Int,4)
            };
                Paras[0].Value = Picture.Title;
                Paras[1].Value = Picture.ImgUrl;
                Paras[2].Value = Picture.Target;
                Paras[3].Value = Picture.SourceId;
                Paras[4].Value = Picture.IsRecommend;
                Paras[5].Value = Picture.ShowId;
                Paras[6].Value = Picture.Remarks;
                Paras[7].Value = Picture.TypeId;

                int row = crm.ExecuteSql(sql, Paras); 
                if (row > 0)
                    return true;
                else
                    return false;
        }

        /// <summary>
        /// 修改图片
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        public bool ModfiyPicture(Tz888.Model.Picture.PictureInfo Picture)
        {
            string sql = "update PictureInfo set Title=@Title,ImgUrl=@ImgUrl,SourceId=@SourceId,IsRecommend=@IsRecommend,ShowId=@ShowId,Remarks=@Remarks,Target=@Target,TypeId=@TypeId where Id=@Id";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Title",SqlDbType.VarChar,100),
                new SqlParameter("@ImgUrl",SqlDbType.VarChar,200),
                new SqlParameter("@SourceId",SqlDbType.Int,4),
                new SqlParameter("@IsRecommend",SqlDbType.Int,4),
                new SqlParameter("@ShowId",SqlDbType.Int,4),
                new SqlParameter("@Id",SqlDbType.Int,4),
                new SqlParameter("@Target",SqlDbType.VarChar,200),
                new SqlParameter("@Remarks",SqlDbType.VarChar,200),
                new SqlParameter("@TypeId",SqlDbType.Int,4)
            };

            Paras[0].Value = Picture.Title;
            Paras[1].Value = Picture.ImgUrl;
            Paras[2].Value = Picture.SourceId;
            Paras[3].Value = Picture.IsRecommend;
            Paras[4].Value = Picture.ShowId;
            Paras[5].Value = Picture.Id;
            Paras[6].Value = Picture.Target;
            Paras[7].Value = Picture.Remarks;
            Paras[8].Value = Picture.TypeId;

            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="PictureId">PictureId</param>
        /// <returns></returns>
        public bool DelPictureById(string PictureId)
        {
            string Sql = "delete PictureInfo where Id=@Id";
            SqlParameter[] Paras = new SqlParameter[] { 
               new SqlParameter("@Id",SqlDbType.Int,4)
            };
            Paras[0].Value = PictureId;

            int row = crm.ExecuteSql(Sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        public bool DelPictureByIds(string PictureIds)
        {
            string Sql = "delete PictureInfo where Id in(@Id)";
            SqlParameter[] Paras = new SqlParameter[] { 
               new SqlParameter("@Id",SqlDbType.Int,4)
            };
            Paras[0].Value = PictureIds;

            int row = crm.ExecuteSql(Sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 图片详情
        /// </summary>
        /// <param name="PictureId">PictureId</param>
        /// <returns></returns>
        public DataTable GetPictureDetail(string PictureId)
        {
            string Sql = "select * from PictureInfo where Id=@PictureId";
            SqlParameter[] Paras = new SqlParameter[] { 
               new SqlParameter("@PictureId",SqlDbType.Int,4)
            };
            Paras[0].Value = PictureId;

            return crm.GetDataSet(Sql, Paras);
        }

        /// <summary>
        /// 图片列表
        /// </summary>
        /// <param name="ObjectName">表/视图</param>
        /// <param name="Key">主键</param>
        /// <param name="ShowFiled">显示字段</param>
        /// <param name="Where">条件</param>
        /// <param name="OrderFiled">排序字段</param>
        /// <param name="PageCurrent">当前页</param>
        /// <param name="PageSize">页码大小</param>
        /// <param name="TotalCount">总条数</param>
        /// <returns></returns>
        public DataTable GetPictureList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
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

            parameters[0].Value = ObjectName;
            parameters[1].Value = Key;
            parameters[2].Value = ShowFiled;
            parameters[3].Value = Where;
            parameters[4].Value = OrderFiled;
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = PageCurrent;
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
                    TotalCount = Convert.ToInt32(parameters[7].Value);
                    PageCurrent = Convert.ToInt32(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt32(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        PageCurrent = 1;
                    }
                    else
                    {
                        PageCurrent = 0;
                    }
                }
            }
            return dt;
        }

        #endregion
    }
}
