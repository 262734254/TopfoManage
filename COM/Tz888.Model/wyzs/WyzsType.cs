using System;
namespace Tz888.Model.wyzs
{
	/// <summary>
	/// WyzsType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WyzsType
	{
		public WyzsType()
		{}
		#region Model
		private int _id;
		private string _typename;
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
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		#endregion Model

	}
}

