using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model.Link
{
    public class TZClickM
    {
        public TZClickM()
        { }
        #region Model
        private int _id;
        private string _loginname;
        private DateTime _createtime;
        private int _clickid;
        private int _pageId;
        public int PageId
        {
            set { _pageId = value; }
            get { return _pageId; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string loginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ClickId
        {
            set { _clickid = value; }
            get { return _clickid; }
        }
        #endregion Model
    }
}
