using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Link
{
    /// <summary>
    /// 友情链接类别
    /// </summary>
    public class LinkTypeTab
    {
        private int _LinkId;//主键
        private string _LinkName;//类型名称
        private int _CheckId;//是否审核
        private string _Remarks;//备注

        public int LinkId
        {
            get { return _LinkId; }
            set { _LinkId = value; }
        }

        public string LinkName
        {
            get { return _LinkName; }
            set { _LinkName = value; }
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
