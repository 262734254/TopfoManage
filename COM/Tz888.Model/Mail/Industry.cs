using System;
namespace Tz888.Model.Mail
{
	/// <summary>
	/// 实体类M_Industry 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Industry
	{
		public Industry()
		{}
		#region Model
		private int _id;
		private string _name;
        private int _isShow;//是否显示

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
        public int IsShow
        {
            get { return _isShow; }
            set { _isShow = value; }
        }
		#endregion Model

	}
}

