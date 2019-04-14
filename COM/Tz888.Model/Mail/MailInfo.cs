using System;
namespace Tz888.Model.Mail
{
	/// <summary>
	/// 实体类M_MailInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class MailInfo
	{
		public MailInfo()
		{}
		#region Model
		private int _userid;
		private string _loginname;
		private string _username;
		private string _panyname;
		private int? _positionid;
		private string _address;
		private string _linkurl;
		private int? _audit;
        private string _phone;
        private int provinceId;

        public int ProvinceId
        {
            get { return provinceId; }
            set { provinceId = value; }
        }
		private int? _cityid;
		private int? _industry;
		private string _mial;
		private string _mobile;
		private int? _typeid;
		private int? _groupid;
		private string _remark;
		private string _mdatetime;
		/// <summary>
		/// 
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PanyName
		{
			set{ _panyname=value;}
			get{return _panyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PositionId
		{
			set{ _positionid=value;}
			get{return _positionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LinkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? audit
		{
			set{ _audit=value;}
			get{return _audit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CityId
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? industry
		{
			set{ _industry=value;}
			get{return _industry;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mial
		{
			set{ _mial=value;}
			get{return _mial;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? typeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? groupID
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mdatetime
		{
			set{ _mdatetime=value;}
			get{return _mdatetime;}
		}

        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

		#endregion Model

	}
}

