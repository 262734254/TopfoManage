using System;
namespace Tz888.Model.Mail
{
	/// <summary>
	/// 实体类City 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class City
	{
		public City()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _provinceid;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
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
		public int? provinceId
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		#endregion Model

	}
}

