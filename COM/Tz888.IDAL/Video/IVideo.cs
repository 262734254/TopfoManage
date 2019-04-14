using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Video;
using System.Data;

namespace Tz888.IDAL.Video
{
    public interface IVideo
    {
        /// <summary>
        /// 添加视频
        /// </summary>
        /// <param name="video">video</param>
        /// <returns></returns>
        bool AddVideo(VideoInfo Video);

        /// <summary>
        /// 修改视频
        /// </summary>
        /// <param name="video">video</param>
        /// <returns></returns>
        bool ModfiyVideo(VideoInfo Video);

        /// <summary>
        /// 删除视频
        /// </summary>
        /// <param name="VideoId">VideoId</param>
        /// <returns></returns>
        bool DelVideoById(string VideoId);

        /// <summary>
        /// 视频详情
        /// </summary>
        /// <param name="VideoId">VideoId</param>
        /// <returns></returns>
        DataTable GetVideoDetailById(string VideoId);

        /// <summary>
        /// 视频列表
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
        DataTable GetVideoList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled,
          ref int PageCurrent, int PageSize, ref int TotalCount);
    }
}
