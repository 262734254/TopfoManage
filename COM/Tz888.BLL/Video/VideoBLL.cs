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
        /// 添加视频
        /// </summary>
        /// <param name="Video">Video</param>
        /// <returns></returns>
        public bool AddVideo(VideoInfo Video)
        {
            return dal.AddVideo(Video);
        }

        /// <summary>
        /// 修改视频
        /// </summary>
        /// <param name="Video">Video</param>
        /// <returns></returns>
        public bool ModfiyVideo(VideoInfo Video)
        {
            return dal.ModfiyVideo(Video);
        }

        /// <summary>
        /// 删除视频
        /// </summary>
        /// <param name="VideoId">VideoId</param>
        /// <returns></returns>
        public bool DelVideoById(string VideoId)
        {
            return dal.DelVideoById(VideoId);
        }

        /// <summary>
        /// 删除视频列表
        /// </summary>
        /// <param name="VideoIds"></param>
        /// <returns></returns>
        public bool DelVideoByIds(string VideoIds)
        {
            return dal.DelVideoByIds(VideoIds);
        }

        /// <summary>
        /// 视频详情
        /// </summary>
        /// <param name="VideoId">VideoId</param>
        /// <returns></returns>
        public DataTable GetVideoDetailById(string VideoId)
        {
            return dal.GetVideoDetailById(VideoId);
        }

        /// <summary>
        /// 视频列表
        /// </summary>
        /// <param name="ObjectName">表/视图</param>
        /// <param name="Key">主键</param>
        /// <param name="ShowFiled">显示字段</param>
        /// <param name="Where">查询条件</param>
        /// <param name="PageCurrnt">当前页</param>
        /// <param name="PageSize">页码大小</param>
        /// <param name="TotalCount">总页码</param>
        /// <returns></returns>
        public DataTable GetVideoList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
        {
            return dal.GetVideoList(ObjectName, Key, ShowFiled, Where, OrderFiled, ref PageCurrent, PageSize, ref TotalCount);
        }

        /// <summary>
        /// 热门视频
        /// </summary>
        /// <returns></returns>
        public DataTable GetHotVideo(int number, int type)
        {
            return dal.GetHotVideo(number, type);
        }

        /// <summary>
        /// 热门视频/专题列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetHotVideoList(int number, int type)
        {
            return dal.GetHotVideoList(number, type);
        }

        /// <summary>
        /// 招商视频
        /// </summary>
        /// <returns></returns>
        public DataTable GetZsVideo(int number, int type)
        {
            return dal.GetZsVideo(number, type);
        }

        /// <summary>
        /// 招商视频列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetZsVideoList(int number, int type)
        {
            return dal.GetZsVideoList(number, type);
        }

        /// <summary>
        /// 融资视频
        /// </summary>
        /// <returns></returns>
        public DataTable GetRzVideo(int number, int type)
        {
            return dal.GetRzVideo(number, type);
        }

        /// <summary>
        /// 融资视频列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetRzVideoList(int number, int type)
        {
            return dal.GetRzVideoList(number, type);
        }

        /// <summary>
        /// 投资视频
        /// </summary>
        /// <returns></returns>
        public DataTable GetTzVideo(int number, int type)
        {
            return dal.GetTzVideo(number, type);
        }

        /// <summary>
        /// 投资视频列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTzVideoList(int number, int type)
        {
            return dal.GetTzVideoList(number, type);
        }

        /// <summary>
        /// 展会视频/专题
        /// </summary>
        /// <returns></returns>
        public DataTable GetZhVideo(int number, int type)
        {
            return dal.GetZhVideo(number, type);
        }

        /// <summary>
        /// 展会视频/专题列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetZhVideoList(int number, int type)
        {
            return dal.GetZhVideoList(number, type);
        }

        /// <summary>
        /// 资金贷款视频/专题
        /// </summary>
        /// <returns></returns>
        public DataTable GetZjdkVideo(int number, int type)
        {
            return dal.GetZjdkVideo(number, type);
        }

        /// <summary>
        /// 资金贷款视频/专题列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetZjdkVideoList(int number, int type)
        {
            return dal.GetZjdkVideoList(number, type);
        }
    }
}
