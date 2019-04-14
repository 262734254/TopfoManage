using System;
using System.Collections.Generic;
using System.Text;
 
namespace GZS.Model
{
  /// <summary>
	/// ʵ����M_EnvironmentTab ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class EnvironmentTabM
	{
        public EnvironmentTabM()
		{}
		#region Model
		private int _environmentid;
		private string _loginname;
		private int? _environmenttypeid;
		private string _chineseintroduced;
		private string _englishintroduction;
        private string updatetime;

        public string Updatetime
        {
            get { return updatetime; }
            set { updatetime = value; }
        }
        private string createtime;

        public string Createtime
        {
            get { return createtime; }
            set { createtime = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int Environmentid
		{
			set{ _environmentid=value;}
			get{return _environmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string loginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EnvironmentTypeid
		{
			set{ _environmenttypeid=value;}
			get{return _environmenttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Chineseintroduced
		{
			set{ _chineseintroduced=value;}
			get{return _chineseintroduced;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Englishintroduction
		{
			set{ _englishintroduction=value;}
			get{return _englishintroduction;}
		}
		#endregion Model

	}
}

