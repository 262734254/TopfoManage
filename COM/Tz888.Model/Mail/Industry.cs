using System;
namespace Tz888.Model.Mail
{
	/// <summary>
	/// ʵ����M_Industry ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Industry
	{
		public Industry()
		{}
		#region Model
		private int _id;
		private string _name;
        private int _isShow;//�Ƿ���ʾ

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

