using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model
{
    [Serializable]
    public class FriendLink
    {
        #region Model
        private int _linkid;
        private string _linkname;
        private string _linkurl;
        private string _loginname;
        private string _linkdate;
        /// <summary>
        /// 
        /// </summary>
        public int Linkid
        {
            set { _linkid = value; }
            get { return _linkid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Linkname
        {
            set { _linkname = value; }
            get { return _linkname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Linkurl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
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
        public string linkdate
        {
            set { _linkdate = value; }
            get { return _linkdate; }
        }
        #endregion Model

    }
}

