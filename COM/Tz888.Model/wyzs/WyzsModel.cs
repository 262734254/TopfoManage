using System;
namespace Tz888.Model.wyzs
{
	/// <summary>
	/// WyzsModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WyzsModel
	{
		public WyzsModel()
		{}
		#region Model
		private int _id;
		private string _title;
		private int _typeid;
		private string _type;
		private string _htmlurl;
		private int _orderid;
        private int _pageAddress;
        private string _status;
        private string _imgPath;
        private string _descript;
        /// <summary>
        /// 
        /// </summary>
        public string descript
        {
            set { _descript = value; }
            get { return _descript; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string imgPath
        {
            set { _imgPath = value; }
            get { return _imgPath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
		/// 
		/// </summary>
        public int pageAddress
		{
            set { _pageAddress = value; }
            get { return _pageAddress; }
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
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int typeid
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string htmlurl
		{
			set{ _htmlurl=value;}
			get{return _htmlurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int orderid
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		#endregion Model

	}
}

