using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Company
{
    public class CompanyMadeModel
    {
        #region Model
        private int _madeid;//编号 主键
        private string _companyid;//广告编号    
        private string _price;//广告所对应的价格
        private string _sumprice;//总价格
        private string _username;//用户名
        private DateTime? _createdate;//发布时间
        private DateTime? _begintime;//广告开始时间
        private DateTime? _endtime;//广告结束时间   
        private string _linkname;//联系人姓名   
        private string _telphone;//电话号码
        private string _email;//邮箱
        private int? _audit;//审核状态
        private string _auditname;//审核人
        private int? _hit;//点击率  
        private int? _visithit;//浏览次数
        private string _remark;//备注

        /// <summary>
        /// 编号 主键
        /// </summary>
        public int MadeID
        {
            set { _madeid = value; }
            get { return _madeid; }
        }
        /// <summary>
        /// 广告编号
        /// </summary>
        public string CompanyID
        {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// 广告所对应的价格
        /// </summary>
        public string Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 总价格
        /// </summary>
        public string SumPrice
        {
            set { _sumprice = value; }
            get { return _sumprice; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 广告开始时间
        /// </summary>
        public DateTime? BeginTime
        {
            set { _begintime = value; }
            get { return _begintime; }
        }
        /// <summary>
        /// 广告结束时间
        /// </summary>
        public DateTime? EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LinkName
        {
            set { _linkname = value; }
            get { return _linkname; }
        }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string TelPhone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int? Audit
        {
            set { _audit = value; }
            get { return _audit; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string AuditName
        {
            set { _auditname = value; }
            get { return _auditname; }
        }
        /// <summary>
        /// 点击率
        /// </summary>
        public int? Hit
        {
            set { _hit = value; }
            get { return _hit; }
        }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int? VisitHit
        {
            set { _visithit = value; }
            get { return _visithit; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        #endregion Model
    }
}
