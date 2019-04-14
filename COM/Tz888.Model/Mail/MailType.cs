using System;
namespace Tz888.Model.Mail
{
	/// <summary>
	/// ʵ����M_MailType ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

