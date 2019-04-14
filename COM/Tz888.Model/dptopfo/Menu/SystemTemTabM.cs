using System;
namespace GZS.Model.Menu
{
	/// <summary>
	/// SystemTemTab:实体类(属性说明自动提取数据库字段的描述信息)
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

