using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Mail
{
    /// <summary>
    /// 实体类MailLog 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class MailLog
    {
        public MailLog()
        { }
        #region Model
        private int _eid;
        private int? _mailid;
        private string _musername;
        private string _edate;
        /// <summary>
        /// 
        /// </summary>
        public int EID
        {
            set { _eid = value; }
            get { return _eid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MailId
        {
            set { _mailid = value; }
            get { return _mailid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MUserName
        {
            set { _musername = value; }
            get { return _musername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  edate
        {
            set { _edate = value; }
            get { return _edate; }
        }
        #endregion Model

    }
}

