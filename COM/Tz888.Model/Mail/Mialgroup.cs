using System;
namespace Tz888.Model.Mail
{
	/// <summary>
	/// 实体类M_Mialgroup 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Mialgroup
	{
		public Mialgroup()
		{}
		#region Model
		private int _groupid;
		private string _groupname;
		private string _groupremark;
        private int audit;

        public int Audit
        {
            get { return audit; }
            set { audit = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int groupID
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string groupname
		{
			set{ _groupname=value;}
			get{return _groupname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string groupremark
		{
			set{ _groupremark=value;}
			get{return _groupremark;}
		}
		#endregion Model

	}
}

