using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Video
{
    public class VideoInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        /// <summary>
        /// 标题
        /// </summary>
        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }

        /// <summary>
        /// 图片路径
        /// </summary>
        private string _ImgUrl;
        public string ImgUrl { get { return _ImgUrl; } set { _ImgUrl = value; } }

        /// <summary>
        /// 视频/专题路径
        /// </summary>
        private string _VideoUrl;
        public string VodeoUrl { get { return _VideoUrl; } set { _VideoUrl = value; } }

        /// <summary>
        /// 视频/专题类型
        /// </summary>
        private int _VideoType;
        public int VideoType { get { return _VideoType; } set { _VideoType = value; } }

        /// <summary>
        /// 是否推荐
        /// </summary>
        private int _IsRecommend;
        public int IsRecommend { get { return _IsRecommend; } set { _IsRecommend = value; } }

        /// <summary>
        /// 展示位置
        /// </summary>
        private int _ShowId;
        public int ShowId { get { return _ShowId; } set { _ShowId = value; } }

        /// <summary>
        /// 排序
        /// </summary>
        private int _SortId;
        public int SortId { get { return _SortId; } set { _SortId = value; } }

        /// <summary>
        /// 发布时间
        /// </summary>
        private DateTime _DateTimes;
        public DateTime DateTimes { get { return _DateTimes; } set { _DateTimes = value; } }

        /// <summary>
        /// 描述
        /// </summary>
        private string _Remarks;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }

        /// <summary>
        /// 类别(0-->视频,1-->专题)
        /// </summary>
        private int _Type;
        public int Type { get { return _Type; } set { _Type = value; } }
    }
}
