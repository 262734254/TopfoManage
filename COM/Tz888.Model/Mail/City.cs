using System;
namespace Tz888.Model.Mail
{
	/// <summary>
	/// ʵ����City ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
