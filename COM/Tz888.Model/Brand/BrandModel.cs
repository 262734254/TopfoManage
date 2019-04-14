using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Brand
{
    /// <summary>
    /// Ʒ��ʵ��
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
        /// ����
        /// </summary>
        public int BrandId
        {
            get { return _BrandId; }
            set { _BrandId = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        /// <summary>
        /// ͼƬ��ַ
        /// </summary>
        public string ImgPath
        {
            get { return _ImgPath; }
            set { _ImgPath = value; }
        }

        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        /// <summary>
        /// ��ʾλ��
        /// </summary>
        public string ShowPosition
        {
            get { return _ShowPosition; }
            set { _ShowPosition = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public int Sort
        {
            get { return _Sort; }
            set { _Sort = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
    }
}
