using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Brand
{
    /// <summary>
    /// 品牌实体
    /// </summary>
    public class BrandModel
    {
        private int _BrandId;
        private string _Title;
        private string _ImgPath;
        private string _Url;
        private string _ShowPosition;
        private int _Sort;
        private string _Remarks;

        /// <summary>
        /// 主键
        /// </summary>
        public int BrandId
        {
            get { return _BrandId; }
            set { _BrandId = value; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgPath
        {
            get { return _ImgPath; }
            set { _ImgPath = value; }
        }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        /// <summary>
        /// 显示位置
        /// </summary>
        public string ShowPosition
        {
            get { return _ShowPosition; }
            set { _ShowPosition = value; }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            get { return _Sort; }
            set { _Sort = value; }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
    }
}
