using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model
{
   /// <summary>
	/// 实体类M_VideoSys 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class VideoSysM
	{
        public VideoSysM()
		{}
		#region Model
		private int _videoid;
		private string _loginname;
		private string _videotitle;
		private string _title;
		private string _keywords;
		private string _description;
		private string _htmlurl;
		private int? _paytimes;
		private string _smallimg;
		private string _bigimg;
		private string _introduction;
		private string _path;
		private string _form;
		private int? _hits;
		private int? _audit;
		private int? _sort;
		private string _createdate;
        private string vidoiName;
        private string imageName;

        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }

        public string VidoiName
        {
            get { return vidoiName; }
            set { vidoiName = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int videoid
		{
			set{ _videoid=value;}
			get{return _videoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string loginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string videotitle
		{
			set{ _videotitle=value;}
			get{return _videotitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
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
		public int? Paytimes
		{
			set{ _paytimes=value;}
			get{return _paytimes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string smallimg
		{
			set{ _smallimg=value;}
			get{return _smallimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bigimg
		{
			set{ _bigimg=value;}
			get{return _bigimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string introduction
		{
			set{ _introduction=value;}
			get{return _introduction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string path
		{
			set{ _path=value;}
			get{return _path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string form
		{
			set{ _form=value;}
			get{return _form;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? hits
		{
			set{ _hits=value;}
			get{return _hits;}
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
		public int? sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string createdate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

