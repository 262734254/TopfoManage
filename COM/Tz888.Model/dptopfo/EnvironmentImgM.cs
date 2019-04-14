using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model
{
   /// <summary>
	/// ʵ����M_EnvironmentImg ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

