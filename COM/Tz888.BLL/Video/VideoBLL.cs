using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.Video;
using Tz888.SQLServerDAL.Video;

namespace Tz888.BLL.Video
{
    public class VideoBLL
    {
        private readonly VideoDAL dal = new VideoDAL();

        /// <summary>
        /// �����Ƶ
        /// </summary>
        /// <param name="Video">Video</param>
        /// <returns></returns>
        public bool AddVideo(VideoInfo Video)
        {
            return dal.AddVideo(Video);
        }

        /// <summary>
        /// �޸���Ƶ
        /// </summary>
        /// <param name="Video">Video</param>
        /// <returns></returns>
        public bool ModfiyVideo(VideoInfo Video)
        {
            return dal.ModfiyVideo(Video);
        }

        /// <summary>
        /// ɾ����Ƶ
        /// </summary>
        /// <param name="VideoId">VideoId</param>
        /// <returns></returns>
        public bool DelVideoById(string VideoId)
        {
            return dal.DelVideoById(VideoId);
        }

        /// <summary>
        /// ɾ����Ƶ�б�
        /// </summary>
        /// <param name="VideoIds"></param>
        /// <returns></returns>
        public bool DelVideoByIds(string VideoIds)
        {
            return dal.DelVideoByIds(VideoIds);
        }

        /// <summary>
        /// ��Ƶ����
        /// </summary>
        /// <param name="VideoId">VideoId</param>
        /// <returns></returns>
        public DataTable GetVideoDetailById(string VideoId)
        {
            return dal.GetVideoDetailById(VideoId);
        }

        /// <summary>
        /// ��Ƶ�б�
        /// </summary>
        /// <param name="ObjectName">��/��ͼ</param>
        /// <param name="Key">����</param>
        /// <param name="ShowFiled">��ʾ�ֶ�</param>
        /// <param name="Where">��ѯ����</param>
        /// <param name="PageCurrnt">��ǰҳ</param>
        /// <param name="PageSize">ҳ���С</param>
        /// <param name="TotalCount">��ҳ��</param>
        /// <returns></returns>
        public DataTable GetVideoList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
        {
            return dal.GetVideoList(ObjectName, Key, ShowFiled, Where, OrderFiled, ref PageCurrent, PageSize, ref TotalCount);
        }

        /// <summary>
        /// ������Ƶ
        /// </summary>
        /// <returns></returns>
        public DataTable GetHotVideo(int number, int type)
        {
            return dal.GetHotVideo(number, type);
        }

        /// <summary>
        /// ������Ƶ/ר���б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetHotVideoList(int number, int type)
        {
            return dal.GetHotVideoList(number, type);
        }

        /// <summary>
        /// ������Ƶ
        /// </summary>
        /// <returns></returns>
        public DataTable GetZsVideo(int number, int type)
        {
            return dal.GetZsVideo(number, type);
        }

        /// <summary>
        /// ������Ƶ�б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetZsVideoList(int number, int type)
        {
            return dal.GetZsVideoList(number, type);
        }

        /// <summary>
        /// ������Ƶ
        /// </summary>
        /// <returns></returns>
        public DataTable GetRzVideo(int number, int type)
        {
            return dal.GetRzVideo(number, type);
        }

        /// <summary>
        /// ������Ƶ�б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetRzVideoList(int number, int type)
        {
            return dal.GetRzVideoList(number, type);
        }

        /// <summary>
        /// Ͷ����Ƶ
        /// </summary>
        /// <returns></returns>
        public DataTable GetTzVideo(int number, int type)
        {
            return dal.GetTzVideo(number, type);
        }

        /// <summary>
        /// Ͷ����Ƶ�б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetTzVideoList(int number, int type)
        {
            return dal.GetTzVideoList(number, type);
        }

        /// <summary>
        /// չ����Ƶ/ר��
        /// </summary>
        /// <returns></returns>
        public DataTable GetZhVideo(int number, int type)
        {
            return dal.GetZhVideo(number, type);
        }

        /// <summary>
        /// չ����Ƶ/ר���б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetZhVideoList(int number, int type)
        {
            return dal.GetZhVideoList(number, type);
        }

        /// <summary>
        /// �ʽ������Ƶ/ר��
        /// </summary>
        /// <returns></returns>
        public DataTable GetZjdkVideo(int number, int type)
        {
            return dal.GetZjdkVideo(number, type);
        }

        /// <summary>
        /// �ʽ������Ƶ/ר���б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetZjdkVideoList(int number, int type)
        {
            return dal.GetZjdkVideoList(number, type);
        }
    }
}
