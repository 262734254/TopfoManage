using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Visit
{
    public class VisitInfoModel
    {
        #region Model
        private int _visitid;
        private string _loginname;//用户名      
        private int? _valid;//是否有效  
        private string _mobile;//手机号码
        private string _email;//电子邮箱
        private string _disposition;//需求意向
        private string _caption;//需求说明
        private string _remark;//回访备注
        private int? _visitnew;//是否回访   
        private DateTime? _visittime;//回访时间
        /// <summary>
        /// 
        /// </summary>
        public int VisitID
        {
            set { _visitid = value; }
            get { return _visitid; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Valid
        {
            set { _valid = value; }
            get { return _valid; }
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
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Disposition
        {
            set { _disposition = value; }
            get { return _disposition; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Caption
        {
            set { _caption = value; }
            get { return _caption; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? VisitNew
        {
            set { _visitnew = value; }
            get { return _visitnew; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? VisitTime
        {
            set { _visittime = value; }
            get { return _visittime; }
        }
        #endregion Model
    }
}
