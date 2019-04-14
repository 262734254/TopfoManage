using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Company
{
    public class CompanyShow
    {
        #region Model
        private int _companyid;//编号
        private string _username;//用户名   
        private byte[] _userpwd;//密码
        private string _telphone;//电话号码
        private string _mobile;//手机号码
        private string _email;//电子邮箱
        private int _audit;//审核状态
        private DateTime _starttime;//发布时间
        private int _valid;//有效期
        private string _typename;//类型
        private int _hit;//点击率
        private int _roleId;
        private string _countrycode;//国家
        private string _provinceid;//省
        private string _cityid;//市
        private string _countyid;//区域
        private int _orderId;//排序
        private string _recomm; //推荐
        private string companyName;

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        private string industry;

        public string Industry
        {
            get { return industry; }
            set { industry = value; }
        }
        /// <summary>
        /// 国家
        /// </summary>
        public string Countrycode
        {
            get { return _countrycode; }
            set { _countrycode = value; }
        }
        /// <summary>
        /// 省
        /// </summary>
        public string Provinceid
        {
            get { return _provinceid; }
            set { _provinceid = value; }
        }
        /// <summary>
        /// 市
        /// </summary>
        public string Cityid
        {
            get { return _cityid; }
            set { _cityid = value; }
        }
        /// <summary>
        /// 区域
        /// </summary>
        public string Countyid
        {
            get { return _countyid; }
            set { _countyid = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        /// <summary>
        /// 推荐
        /// </summary>
        public string Recomm
        {
            get { return _recomm; }
            set { _recomm = value; }
        }

        public int RoleId
        {
            set { _roleId = value; }
            get { return _roleId; }
        }
        
        /// <summary>
        /// 编号
        /// </summary>
        public int CompanyID
        {
            set { _companyid = value; }
            get { return _companyid; }
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
        /// 密码
        /// </summary>
        public byte[] UserPwd
        {
            set { _userpwd = value; }
            get { return _userpwd; }
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
        /// 手机号码
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
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
        /// 审核
        /// </summary>
        public int Audit
        {
            set { _audit = value; }
            get { return _audit; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 有效期
        /// </summary>
        public int Valid
        {
            set { _valid = value; }
            get { return _valid; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 点击率
        /// </summary>
        public int Hit
        {
            set { _hit = value; }
            get { return _hit; }
        }
        #endregion Model
    }
}
