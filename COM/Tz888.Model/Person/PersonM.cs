using System;
namespace GZS.Model.Person
{
	/// <summary>
	/// PersonM:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PersonM
	{
		public PersonM()
		{}
		#region Model
		private int _id;
		private string _name;
		private DateTime _createtime;
		private DateTime _birthday;
		private string _signature;
		private string _description;
		private string _address;
		private string _img;
        private string _loginName;
        /// <summary>
        /// 
        /// </summary>
        public string LoginName
        {
            set { _loginName = value; }
            get { return _loginName; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime createTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime birthDay
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string signature
		{
			set{ _signature=value;}
			get{return _signature;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img
		{
			set{ _img=value;}
			get{return _img;}
		}
		#endregion Model

	}
}

