using System;
namespace GZS.Model.Link
{
	/// <summary>
	/// CommentM:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class CommentM
	{
		public CommentM()
		{}
		#region Model
		private int _commentid;
		private string _description;
		private DateTime _commdate;
		private string _sendname;
		private string _linkmode;
        private string _linkName;
        public string LinkName
        {
            set { _linkName = value; }
            get { return _linkName; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int CommentId
		{
			set{ _commentid=value;}
			get{return _commentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CommDate
		{
			set{ _commdate=value;}
			get{return _commdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SendName
		{
			set{ _sendname=value;}
			get{return _sendname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LinkMode
		{
			set{ _linkmode=value;}
			get{return _linkmode;}
		}
		#endregion Model

	}
}

