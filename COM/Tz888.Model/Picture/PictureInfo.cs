using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Picture
{
    public class PictureInfo
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
        /// Ŀ���ַ
        /// </summary>
        private string _Target;
        public string Target { get { return _Target; } set { _Target = value; } }

        /// <summary>
        /// ��Դ
        /// </summary>
        private int _SourceId;
        public int SourceId { get { return _SourceId; } set { _SourceId = value; } }

        /// <summary>
        /// �Ƿ��Ƽ�
        /// </summary>
        private int _IsRecommend;
        public int IsRecommend { get { return _IsRecommend; } set { _IsRecommend = value; } }

        /// <summary>
        /// ��ʾλ��
        /// </summary>
        private int _ShowId;
        public int ShowId { get { return _ShowId; } set { _ShowId = value; } }

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
        /// ���(0->ͼƬչʾ,1->Ʒ���ƹ�)
        /// </summary>
        private int _TypeId;
        public int TypeId { get { return _TypeId; } set { _TypeId = value; } }
    }
}
