using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model.policy
{
    [Serializable]
    public class PolicyModel
    {

        public PolicyModel()
        {

        }
        #region Model
        private int _policyId;
        private string _loginname;
        private string _chineseintroduced;
        private string _englishintroduction;
        private DateTime _createdate;
        private int _clicks;
        private string _htmlUrl;
        public string htmlUrl
        {
            set { _htmlUrl = value; }
            get { return _htmlUrl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int policyId
        {
            set { _policyId = value; }
            get { return _policyId; }
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
        public string Chineseintroduced
        {
            set { _chineseintroduced = value; }
            get { return _chineseintroduced; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Englishintroduction
        {
            set { _englishintroduction = value; }
            get { return _englishintroduction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createdate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Clicks
        {
            set { _clicks = value; }
            get { return _clicks; }
        }
        #endregion Model
    }
}
