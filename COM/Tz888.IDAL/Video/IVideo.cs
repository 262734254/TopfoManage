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
        /// �����Ƶ
        /// </summary>
        /// <param name="video">video</param>
        /// <returns></returns>
        bool AddVideo(VideoInfo Video);

        /// <summary>
        /// �޸���Ƶ
        /// </summary>
        /// <param name="video">video</param>
        /// <returns></returns>
        bool ModfiyVideo(VideoInfo Video);

        /// <summary>
        /// ɾ����Ƶ
        /// </summary>
        /// <param name="VideoId">VideoId</param>
        /// <returns></returns>
        bool DelVideoById(string VideoId);

        /// <summary>
        /// ��Ƶ����
        /// </summary>
        /// <param name="VideoId">VideoId</param>
        /// <returns></returns>
        DataTable GetVideoDetailById(string VideoId);

        /// <summary>
        /// ��Ƶ�б�
        /// </summary>
        /// <param name="ObjectName">��/��ͼ</param>
        /// <param name="Key">����</param>
        /// <param name="ShowFiled">��ʾ�ֶ�</param>
        /// <param name="Where">����</param>
        /// <param name="OrderFiled">�����ֶ�</param>
        /// <param name="PageCurrent">��ǰҳ</param>
        /// <param name="PageSize">ҳ���С</param>
        /// <param name="TotalCount">������</param>
        /// <returns></returns>
        DataTable GetVideoList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled,
          ref int PageCurrent, int PageSize, ref int TotalCount);
    }
}
