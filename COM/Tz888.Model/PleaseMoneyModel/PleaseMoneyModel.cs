using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.PleaseMoneyModel
{
    /// <summary>
    /// 实体类M_PleaseMoney 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PleaseMoneyModel
    {
        public PleaseMoneyModel()
        { }
        #region Model
        private int _atmid;
        private decimal _atmcount;
        private string _bankname;
        private string _banknumber;
        private string _depositbank;
        private string _accountname;
        private string _loginname;
        private DateTime _createtime;
        private DateTime _enddate;
        private int _stateid;
        private string _description;
        private string _mobile;
        private string _auditname;
        /// <summary>
        /// 
        /// </summary>
        public int atmId
        {
            set { _atmid = value; }
            get { return _atmid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal atmcount
        {
            set { _atmcount = value; }
            get { return _atmcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankNumber
        {
            set { _banknumber = value; }
            get { return _banknumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DepositBank
        {
            set { _depositbank = value; }
            get { return _depositbank; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AccountName
        {
            set { _accountname = value; }
            get { return _accountname; }
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
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Enddate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StateID
        {
            set { _stateid = value; }
            get { return _stateid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditName
        {
            set { _auditname = value; }
            get { return _auditname; }
        }
        #endregion Model
    }
}
