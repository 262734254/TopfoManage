using System;
namespace GZS.Model.Menu
{
	/// <summary>
	/// SystemTemTab:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class SystemTemTabM
	{
		public SystemTemTabM()
		{}
		#region Model
		private int _userid;
		private string _levelname;
		private string _menucode;
		/// <summary>
		/// 
		/// </summary>
		public int userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string levelName
		{
			set{ _levelname=value;}
			get{return _levelname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string menuCode
		{
			set{ _menucode=value;}
			get{return _menucode;}
		}
		#endregion Model

	}
}

