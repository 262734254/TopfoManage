using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Link
{
    /// <summary>
    /// ҳ��Ƶ�����ͱ�
    /// </summary>
    public class LinkChannelType
    {
        private int _ChannelId;//����
        public string _ChannelName;//Ƶ������
        private int _CheckId;//�Ƿ����
        private string _Remarks;//��ע

        public int ChannelId 
        {
            get { return _ChannelId; }
            set { _ChannelId = value; }
        }

        public string ChannelName
        {
            get { return _ChannelName; }
            set { _ChannelName = value; }
        }

        public int CheckId 
        {
            get { return _CheckId; }
            set { _CheckId = value; }
        }

        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
    }
}
