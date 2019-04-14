using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.Video
{
    public class VideoDAL:Tz888.IDAL.Video.IVideo
    {
        private readonly Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();

        /// <summary>
        /// �����Ƶ
        /// </summary>
        /// <param name="Video">Video</param>
        /// <returns></returns>
        public bool AddVideo(Tz888.Model.Video.VideoInfo Video)
        {
            string sql = "insert into VideoInfo(Title,ImgUrl,VideoUrl,VideoType,IsRecommend,ShowId,SortId,Remarks,[Type]) " +
            "values(@Title,@ImgUrl,@VideoUrl,@VideoType,@IsRecommend,@ShowId,@SortId,@Remarks,@Type)";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Title",SqlDbType.VarChar,100),
                new SqlParameter("@ImgUrl",SqlDbType.VarChar,200),
                new SqlParameter("@VideoUrl",SqlDbType.VarChar,200),
                new SqlParameter("@VideoType",SqlDbType.Int,4),
                new SqlParameter("@IsRecommend",SqlDbType.Int,4),
                new SqlParameter("@ShowId",SqlDbType.Int,4),
                new SqlParameter("@SortId",SqlDbType.Int,4),
                new SqlParameter("@Remarks",SqlDbType.VarChar,200),
                new SqlParameter("@Type",SqlDbType.Int,4)
            };
            Paras[0].Value = Video.Title;
            Paras[1].Value = Video.ImgUrl;
            Paras[2].Value = Video.VodeoUrl;
            Paras[3].Value = Video.VideoType;
            Paras[4].Value = Video.IsRecommend;
            Paras[5].Value = Video.ShowId;
            Paras[6].Value = Video.SortId;
            Paras[7].Value = Video.Remarks;
            Paras[8].Value = Video.Type;

            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// �޸���Ƶ
        /// </summary>
        /// <param name="Video">Video</param>
        /// <returns></returns>
        public bool ModfiyVideo(Tz888.Model.Video.VideoInfo Video)
        {
            string sql = "update VideoInfo set Title=@Title,ImgUrl=@ImgUrl,VideoUrl=@VideoUrl,VideoType=@VideoType,IsRecommend=@IsRecommend,ShowId=@ShowId,SortId=@SortId,Remarks=@Remarks,[Type]=@Type where Id=@Id";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Title",SqlDbType.VarChar,100),
                new SqlParameter("@ImgUrl",SqlDbType.VarChar,200),
                new SqlParameter("@VideoUrl",SqlDbType.VarChar,200),
                new SqlParameter("@VideoType",SqlDbType.Int,4),
                new SqlParameter("@IsRecommend",SqlDbType.Int,4),
                new SqlParameter("@ShowId",SqlDbType.Int,4),
                new SqlParameter("@SortId",SqlDbType.Int,4),
                new SqlParameter("@Remarks",SqlDbType.VarChar,200),
                new SqlParameter("@Type",SqlDbType.Int,4),
                new SqlParameter("@Id",SqlDbType.Int,4)
            };
            Paras[0].Value = Video.Title;
            Paras[1].Value = Video.ImgUrl;  
            Paras[2].Value = Video.VodeoUrl;
            Paras[3].Value = Video.VideoType;
            Paras[4].Value = Video.IsRecommend;
            Paras[5].Value = Video.ShowId;
            Paras[6].Value = Video.SortId;
            Paras[7].Value = Video.Remarks;
            Paras[8].Value = Video.Type;
            Paras[9].Value = Video.Id;

            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// ɾ����Ƶ
        /// </summary>
        /// <param name="VideoId">VideoId</param>
        /// <returns></returns>
        public bool DelVideoById(string VideoId)
        {
            string sql = "delete VideoInfo where Id=@Id";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int,4)
            };
            Paras[0].Value = VideoId;

            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        public bool DelVideoByIds(string VideoIds)
        {
            string sql = "delete VideoInfo where Id in(@Id)";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int,4)
            };
            Paras[0].Value = VideoIds;

            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// ��ȡ��Ƶ����
        /// </summary>
        /// <param name="VideoId">VideoId</param>
        /// <returns></returns>
        public DataTable GetVideoDetailById(string VideoId)
        {
            string sql = "select * from VideoInfo Where Id=@Id";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int,4)
            };
            Paras[0].Value = VideoId;

            return crm.GetDataSet(sql, Paras);
        }

        /// <summary>
        /// ��Ƶ�б�
        /// </summary>
        /// <param name="ObjectName">��/��ͼ</param>
        /// <param name="Key">����</param>
        /// <param name="ShowFiled">��ʾ�ֶ�</param>
        /// <param name="Where">��ѯ����</param>
        /// <param name="OrderFiled">�����ֶ�</param>
        /// <param name="PageCurrent">��ǰҳ��</param>
        /// <param name="PageSize">ҳ���С</param>
        /// <param name="TotalCount">��ҳ��</param>
        /// <returns></returns>
        public DataTable GetVideoList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
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

        /// <summary>
        /// ������Ƶ/ר��
        /// </summary>
        /// <returns></returns>
        public DataTable GetHotVideo(int number, int type)
        {
            string sql = "select top " + number + " Title,VideoUrl,ImgUrl from VideoInfo Where IsRecommend=1 and [Type]=" + type + " order by DateTimes desc";
            return crm.GetDataSet(sql);
        }

        /// <summary>
        /// ������Ƶ/ר���б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetHotVideoList(int number, int type)
        {
            string sql = "select top " + number + " Title,VideoUrl from VideoInfo Where IsRecommend=1 and [Type]=" + type + " order by DateTimes desc";
            return crm.GetDataSet(sql);
        }

        /// <summary>
        /// ������Ƶ/ר��
        /// </summary>
        /// <returns></returns>
        public DataTable GetZsVideo(int number, int type)
        {
            string sql = "select top " + number + " Title,ImgUrl,VideoUrl from VideoInfo Where VideoType=0 and [Type]=" + type + " and IsRecommend=1 order by DateTimes desc";
            return crm.GetDataSet(sql);
        }

        /// <summary>
        /// ������Ƶ/ר���б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetZsVideoList(int number, int type)
        {
            string sql = "select top " + number + " Title,VideoUrl from VideoInfo Where VideoType=0 and [Type]=" + type + " order by DateTimes desc";
            return crm.GetDataSet(sql);
        }

        /// <summary>
        /// ������Ƶ/ר��
        /// </summary>
        /// <returns></returns>
        public DataTable GetRzVideo(int number, int type)
        {
            string sql = "select top " + number + " Title,ImgUrl,VideoUrl from VideoInfo Where VideoType=2 and IsRecommend=1 and [Type]=" + type + " order by DateTimes desc";
            return crm.GetDataSet(sql);
        }

        /// <summary>
        /// ������Ƶ/ר���б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetRzVideoList(int number, int type)
        {
            string sql = "select top " + number + " Title,VideoUrl from VideoInfo Where VideoType=2 and [Type]=" + type + " order by DateTimes desc";
            return crm.GetDataSet(sql);
        }

        /// <summary>
        /// Ͷ����Ƶ/ר��
        /// </summary>
        /// <returns></returns>
        public DataTable GetTzVideo(int number, int type)
        {
            string sql = "select top " + number + " Title,ImgUrl,VideoUrl from VideoInfo Where VideoType=1 and IsRecommend=1 and [Type]=" + type + " order by DateTimes desc";
            return crm.GetDataSet(sql);
        }

        /// <summary>
        /// Ͷ����Ƶ/ר���б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetTzVideoList(int number, int type)
        {
            string sql = "select top " + number + " Title,VideoUrl from VideoInfo Where VideoType=1 and [Type]=" + type + " order by DateTimes desc";
            return crm.GetDataSet(sql);
        }

        /// <summary>
        /// չ����Ƶ/ר��
        /// </summary>
        /// <returns></returns>
        public DataTable GetZhVideo(int number, int type)
        {
            string sql = "select top " + number + " Title,ImgUrl,VideoUrl from VideoInfo Where VideoType=3 and IsRecommend=1 and [Type]=" + type + " order by DateTimes desc";
            return crm.GetDataSet(sql);
        }

        /// <summary>
        /// չ����Ƶ/ר���б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetZhVideoList(int number, int type)
        {
            string sql = "select top " + number + " Title,VideoUrl from VideoInfo Where VideoType=3 and [Type]=" + type + " order by DateTimes desc";
            return crm.GetDataSet(sql);
        }

        /// <summary>
        /// �ʽ������Ƶ/ר��
        /// </summary>
        /// <returns></returns>
        public DataTable GetZjdkVideo(int number, int type)
        {
            string sql = "select top " + number + " Title,ImgUrl,VideoUrl from VideoInfo Where VideoType=4 and IsRecommend=1 and [Type]=" + type + " order by DateTimes desc";
            return crm.GetDataSet(sql);
        }

        /// <summary>
        /// �ʽ������Ƶ/ר���б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetZjdkVideoList(int number, int type)
        {
            string sql = "select top " + number + " Title,VideoUrl from VideoInfo Where VideoType=4 and [Type]=" + type + " order by DateTimes desc";
            return crm.GetDataSet(sql);
        }
    }
}
