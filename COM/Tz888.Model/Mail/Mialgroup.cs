using System;
namespace Tz888.Model.Mail
{
	/// <summary>
	/// ʵ����M_Mialgroup ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

