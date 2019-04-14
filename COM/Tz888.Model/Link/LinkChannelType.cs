using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Link
{
    /// <summary>
    /// 页面频道类型表
    /// </summary>
    public class LinkChannelType
    {
        private int _ChannelId;//主键
        public string _ChannelName;//频道名称
        private int _CheckId;//是否审核
        private string _Remarks;//备注

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
