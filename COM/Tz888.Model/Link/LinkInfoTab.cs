using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Link
{
    /// <summary>
    /// ��������
    /// </summary>
    public class LinkInfoTab
    {

        private int _LinkInfoId;//����
        private int _ChannelId;//Ƶ��Id
        private int _LinkId;//����ID
        private string _LinkInfoName;//��������
        private string _LinkUrl;//���ӵ�ַ
        private int _Sort;
        private string _Logo;//Logo
        private string _Remarks;//��ע

        public int LinkInfoId
        {
            get { return _LinkInfoId; }
            set { _LinkInfoId = value; }
        }

        public int ChannelId
        {
            get { return _ChannelId; }
            set { _ChannelId = value; }
        }

        public int LinkId
        {
            get { return _LinkId; }
            set { _LinkId = value; }
        }

        public string LinkInfoName
        {
            get { return _LinkInfoName; }
            set { _LinkInfoName = value; }
        }

        public string LinkUrl
        {
            get { return _LinkUrl; }
            set { _LinkUrl = value; }
        }

        public int Sort
        {
            get { return _Sort; }
            set { _Sort = value; }
        }

        public string Logo
        {
            get { return _Logo; }
            set { _Logo = value; }
        }

        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
    }
}
