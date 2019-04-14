using System;
namespace Tz888.Model.Recomm
{
	/// <summary>
	/// recommResourceM:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public  class recommResourceM
	{
		public recommResourceM()
		{}
		#region Model
		private int _recommid;
		private long _resourceid;
		private string _resourcetitle;
		private int _resourcetypeid;
		private string _resourceurl;
		private string _recommname;
		private string _recommtouser;
		private DateTime _recommdate;
		/// <summary>
		/// 
		/// </summary>
		public int RecommID
		{
			set{ _recommid=value;}
			get{return _recommid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long ResourceId
		{
			set{ _resourceid=value;}
			get{return _resourceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResourceTitle
		{
			set{ _resourcetitle=value;}
			get{return _resourcetitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ResourceTypeId
		{
			set{ _resourcetypeid=value;}
			get{return _resourcetypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResourceUrl
		{
			set{ _resourceurl=value;}
			get{return _resourceurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecommName
		{
			set{ _recommname=value;}
			get{return _recommname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecommToUser
		{
			set{ _recommtouser=value;}
			get{return _recommtouser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime RecommDate
		{
			set{ _recommdate=value;}
			get{return _recommdate;}
		}
		#endregion Model

	}
}

