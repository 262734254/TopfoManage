using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Picture
{
    public class PictureInfo
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
        /// 图片路劲
        /// </summary>
        private string _ImgUrl;
        public string ImgUrl { get { return _ImgUrl; } set { _ImgUrl = value; } }

        /// <summary>
        /// 目标地址
        /// </summary>
        private string _Target;
        public string Target { get { return _Target; } set { _Target = value; } }

        /// <summary>
        /// 来源
        /// </summary>
        private int _SourceId;
        public int SourceId { get { return _SourceId; } set { _SourceId = value; } }

        /// <summary>
        /// 是否推荐
        /// </summary>
        private int _IsRecommend;
        public int IsRecommend { get { return _IsRecommend; } set { _IsRecommend = value; } }

        /// <summary>
        /// 显示位置
        /// </summary>
        private int _ShowId;
        public int ShowId { get { return _ShowId; } set { _ShowId = value; } }

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
        /// 类别(0->图片展示,1->品牌推广)
        /// </summary>
        private int _TypeId;
        public int TypeId { get { return _TypeId; } set { _TypeId = value; } }
    }
}
