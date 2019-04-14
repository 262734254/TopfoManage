using System;
namespace Tz888.Model.Sys
{
    /// <summary>
    /// 实体类EmployeeInfoTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class EmployeeInfoTab
    {
        public EmployeeInfoTab()
        { }
        #region Model
        private int _employeeid;
        private string _loginname;
        private string _employeename;
        private bool _sex;
        private string _nickname;
        private DateTime _birthday;
        private string _certificateid;
        private string _certificatenumber;
        private string _countrycode;
        private string _provinceid;
        private string _cityid;
        private string _countyid;
        private string _address;
        private string _postcode;
        private string _tel;
        private string _mobile;
        private string _fax;
        private string _email;
        private string _deptid;
        private string _worktype;
        private string _degreeid;
        private bool _enable;
        private byte[] _password;
        /// <summary>
        /// 
        /// </summary>
        public int EmployeeID
        {
            set { _employeeid = value; }
            get { return _employeeid; }
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
        public string EmployeeName
        {
            set { _employeename = value; }
            get { return _employeename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CertificateID
        {
            set { _certificateid = value; }
            get { return _certificateid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CertificateNumber
        {
            set { _certificatenumber = value; }
            get { return _certificatenumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CountryCode
        {
            set { _countrycode = value; }
            get { return _countrycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CountyID
        {
            set { _countyid = value; }
            get { return _countyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
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
        public string FAX
        {
            set { _fax = value; }
            get { return _fax; }
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
        public string DeptID
        {
            set { _deptid = value; }
            get { return _deptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkType
        {
            set { _worktype = value; }
            get { return _worktype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DegreeID
        {
            set { _degreeid = value; }
            get { return _degreeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Enable
        {
            set { _enable = value; }
            get { return _enable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Password
        {
            set { _password = value; }
            get { return _password; }
        }


        //用于搜索用
        //角色
        private string _ssRole;
        private string _ssStatus;

        public string sRole
        {
            set { _ssRole = value; }
            get { return _ssRole; }
        }
        public string sStatus
        {
            set { _ssStatus = value; }
            get { return _ssStatus; }
        }

        #endregion Model

    }
}

