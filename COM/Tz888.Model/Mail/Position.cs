using System;
namespace Tz888.Model.Mail
{
	/// <summary>
	/// ʵ����M_Position ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Position
	{
		public Position()
		{}
		#region Model
		private int _id;
		private string _name;
        private int _audit;

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
        public int Audit
        {
            get { return _audit; }
            set { _audit = value; }
        }
		#endregion Model

	}
}

