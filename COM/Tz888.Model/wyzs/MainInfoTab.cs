using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.wyzs
{
    //����
    public class MainInfoTab
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
        /// ��ԱID
        /// </summary>
        private string _MemberId;
        public string MemberId { get { return _MemberId; } set { _MemberId = value; } }

        /// <summary>
        /// ����(1->����,2->����,3->����,4->����)
        /// </summary>
        private int _Types;
        public int Types { get { return _Types; } set { _Types = value; } }

        /// <summary>
        /// ״̬(1->����,2->������)
        /// </summary>
        private int _State;
        public int State { get { return _State; } set { _State = value; } }

        /// <summary>
        /// ��̬ҳ���ַ
        /// </summary>
        private string _Htmlurl;
        public string Htmlurl { get { return _Htmlurl; } set { _Htmlurl = value; } }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        private DateTime _PublishTime;
        public DateTime PublishTime { get { return _PublishTime; } set { _PublishTime = value; } }
    }
}
