using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Link
{
    /// <summary>
    /// �����������
    /// </summary>
    public class LinkTypeTab
    {
        private int _LinkId;//����
        private string _LinkName;//��������
        private int _CheckId;//�Ƿ����
        private string _Remarks;//��ע

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
