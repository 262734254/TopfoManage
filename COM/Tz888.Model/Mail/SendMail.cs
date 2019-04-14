using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Mail
{
    /// <summary>
    /// 实体类M_SendMail 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class SendMail
    {
        public SendMail()
        { }
        #region Model
        private int _mailid;
        private string _loginname;
        private string _emtitle;
        private string _sendcontext;
        private int? _sendcount;
        private int? _sendnumber;
        private string _sendtime;
        /// <summary>
        /// 
        /// </summary>
        public int MailId
        {
            set { _mailid = value; }
            get { return _mailid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EMtitle
        {
            set { _emtitle = value; }
            get { return _emtitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SendContext
        {
            set { _sendcontext = value; }
            get { return _sendcontext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SendCount
        {
            set { _sendcount = value; }
            get { return _sendcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SendNumber
        {
            set { _sendnumber = value; }
            get { return _sendnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SendTime
        {
            set { _sendtime = value; }
            get { return _sendtime; }
        }
        #endregion Model

    }
}

