using System;
namespace Tz888.Model.wyzs
{
	/// <summary>
	/// WyzsType:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

