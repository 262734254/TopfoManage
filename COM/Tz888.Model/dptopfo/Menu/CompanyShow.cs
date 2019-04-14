using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model.Menu
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
        private int _levels;
        private string _levelName;
        private string _companyName;
        public string LevelName
        {
            set { _levelName = value; }
            get { return _levelName; }
        }
        public int Levels
        {
            set { _levels = value; }
            get { return _levels; }
        }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string CompanyName
        {
            set { _companyName = value; }
            get { return _companyName; }
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
