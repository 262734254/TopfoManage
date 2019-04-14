using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model
{
   /// <summary>
	/// 实体类M_EnvironmentImg 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class EnvironmentImgM
	{
        public EnvironmentImgM()
		{}
		#region Model
		private int _environmentid;
		private int? _environmenttabid;
		private string _imgpath;
		private string _imgexplain;
		/// <summary>
		/// 
		/// </summary>
		public int Environmentid
		{
			set{ _environmentid=value;}
			get{return _environmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Environmenttabid
		{
			set{ _environmenttabid=value;}
			get{return _environmenttabid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgpath
		{
			set{ _imgpath=value;}
			get{return _imgpath;}
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

