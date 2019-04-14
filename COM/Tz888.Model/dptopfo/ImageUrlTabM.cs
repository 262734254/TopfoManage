using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model
{
    /// <summary>
    /// 实体类ImageUrlTabM 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ImageUrlTabM
	{
        public ImageUrlTabM()
		{}
		#region Model
		private int _parktypeid;
		private int? _imageid;
		private string _imagepath;
		private string _imgexplain;
		/// <summary>
		/// 
		/// </summary>
		public int parktypeid
		{
			set{ _parktypeid=value;}
			get{return _parktypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Imageid
		{
			set{ _imageid=value;}
			get{return _imageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Imagepath
		{
			set{ _imagepath=value;}
			get{return _imagepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgexplain
		{
			set{ _imgexplain=value;}
			get{return _imgexplain;}
		}
		#endregion Model

	}
}

