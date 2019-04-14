using System;
using System.Collections.Generic;
using System.Text;
namespace GZS.Model.Invest
{
    /// <summary>
    /// InvestCost:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class InvestCostM
    {

        #region Model
        private int _costid;
        private string _loginname;
        private string _chineseintroduced;
        private string _englishintroduction;
        private DateTime _createdate;
        private int _hits;
        /// <summary>
        /// 
        /// </summary>
        public int Costid
        {
            set { _costid = value; }
            get { return _costid; }
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
        public int hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        #endregion Model

    }
}

