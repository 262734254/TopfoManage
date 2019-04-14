using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model
{
  /// <summary>
    /// 实体类ImageTabM 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ImageTabM
	{
        public ImageTabM()
		{}
		#region Model
		private int _imageid;
		private string _loginname;
		private string _imagename;
		private string _remark;
        private string createdatetime;
        private string htmlurllist;

        public string Htmlurllist
        {
            get { return htmlurllist; }
            set { htmlurllist = value; }
        }
        public string Createdatetime
        {
            get { return createdatetime; }
            set { createdatetime = value; }
        }
        private string Updatetime;

        public string Updatetime1
        {
            get { return Updatetime; }
            set { Updatetime = value; }
        }
        private string htmlurl;

        public string Htmlurl
        {
            get { return htmlurl; }
            set { htmlurl = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int imageid
		{
			set{ _imageid=value;}
			get{return _imageid;}
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
		public string imageName
		{
			set{ _imagename=value;}
			get{return _imagename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

