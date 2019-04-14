using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Link
{
    /// <summary>
    /// 友情链接
    /// </summary>
    public class LinkInfoTab
    {

        private int _LinkInfoId;//主键
        private int _ChannelId;//频道Id
        private int _LinkId;//类型ID
        private string _LinkInfoName;//链接名称
        private string _LinkUrl;//链接地址
        private int _Sort;
        private string _Logo;//Logo
        private string _Remarks;//备注

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
