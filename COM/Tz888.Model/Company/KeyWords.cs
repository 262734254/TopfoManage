using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Company
{
    /// <summary>
    /// 实体类M_KeyWords 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class KeyWords
    {
        public KeyWords()
        { }
        #region Model
        private int _id;
        private string _webtitle;
        private string _webkeyword;
        private string _description;
        private int? _roseid;
        private string _username;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WebTitle
        {
            set { _webtitle = value; }
            get { return _webtitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WebKeyWord
        {
            set { _webkeyword = value; }
            get { return _webkeyword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RoseID
        {
            set { _roseid = value; }
            get { return _roseid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        #endregion Model

    }
}

