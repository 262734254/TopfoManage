using System;
namespace GZS.Model.Link
{
	/// <summary>
	/// TZLinkM:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class TZLinkM
	{
		public TZLinkM()
		{}
		#region Model

		private int _linkid;
		private string _name;
		private string _tel;
		private string _phone;
		private string _email;
		private string _othermode;
		private string _address;
		private DateTime _createtime;
        private string _loginName;
        private string _imageMap;
        public string ImageMap
        {
            set { _imageMap = value; }
            get { return _imageMap; }
        }
        public string LoginName

        {
            set { _loginName = value; }
            get { return _loginName; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int linkId
		{
			set{ _linkid=value;}
			get{return _linkid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OtherMode
		{
			set{ _othermode=value;}
			get{return _othermode;}
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
		public DateTime createTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

