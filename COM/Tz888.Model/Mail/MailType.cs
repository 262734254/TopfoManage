using System;
namespace Tz888.Model.Mail
{
	/// <summary>
	/// 实体类M_MailType 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class MailType
	{
		public MailType()
		{}
		#region Model
		private int _typeid;
		private string _typename;
		private string _typeremark;
        private int audit;

        public int Audit
        {
            get { return audit; }
            set { audit = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int typeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeRemark
		{
			set{ _typeremark=value;}
			get{return _typeremark;}
		}
		#endregion Model

	}
}

