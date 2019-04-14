using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Video
{
    public class VideoInfo
    {
        /// <summary>
        /// ����
        /// </summary>
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        /// <summary>
        /// ����
        /// </summary>
        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }

        /// <summary>
        /// ͼƬ·��
        /// </summary>
        private string _ImgUrl;
        public string ImgUrl { get { return _ImgUrl; } set { _ImgUrl = value; } }

        /// <summary>
        /// ��Ƶ/ר��·��
        /// </summary>
        private string _VideoUrl;
        public string VodeoUrl { get { return _VideoUrl; } set { _VideoUrl = value; } }

        /// <summary>
        /// ��Ƶ/ר������
        /// </summary>
        private int _VideoType;
        public int VideoType { get { return _VideoType; } set { _VideoType = value; } }

        /// <summary>
        /// �Ƿ��Ƽ�
        /// </summary>
        private int _IsRecommend;
        public int IsRecommend { get { return _IsRecommend; } set { _IsRecommend = value; } }

        /// <summary>
        /// չʾλ��
        /// </summary>
        private int _ShowId;
        public int ShowId { get { return _ShowId; } set { _ShowId = value; } }

        /// <summary>
        /// ����
        /// </summary>
        private int _SortId;
        public int SortId { get { return _SortId; } set { _SortId = value; } }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        private DateTime _DateTimes;
        public DateTime DateTimes { get { return _DateTimes; } set { _DateTimes = value; } }

        /// <summary>
        /// ����
        /// </summary>
        private string _Remarks;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }

        /// <summary>
        /// ���(0-->��Ƶ,1-->ר��)
        /// </summary>
        private int _Type;
        public int Type { get { return _Type; } set { _Type = value; } }
    }
}
