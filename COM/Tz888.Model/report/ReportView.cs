//============================================================
// Producnt name:		ExamSystem
// Version: 			1.0
// Coded by:			Eagle Lifeng
// Auto generated at: 	2011-4-6 15:52:35
//============================================================

using System;

namespace Tz888.Model.report
{
    [Serializable]
    public class ReportView
    {
       	/// <summary>
		/// 主键
		/// </summary>
        private int _reportviewid;
        //[DataField("Reportviewid")]
        public int Reportviewid
        {
            get { return _reportviewid; }
            set { _reportviewid = value; }
        }
        
       	/// <summary>
		/// 外键
		/// </summary>
        private int _reportID;
        //[DataField("reportID")]
        public int ReportID
        {
            get { return _reportID; }
            set { _reportID = value; }
        }
        

        private string _paytype;
        //[DataField("paytype")]
      	/// <summary>
        /// 支付方式
		/// </summary>
        public string Paytype
        {
            get { return _paytype; }
            set { _paytype = value; }
        }
        
        private int _chartcount;
        //[DataField("Chartcount")]
      	/// <summary>
        /// 图表数量
		/// </summary>
        public int Chartcount
        {
            get { return _chartcount; }
            set { _chartcount = value; }
        }
        
        private int _pagecount;
        //[DataField("pagecount")]
      	/// <summary>
        /// 页数
		/// </summary>
        public int Pagecount
        {
            get { return _pagecount; }
            set { _pagecount = value; }
        }
        
        private string _writing;
        //[DataField("writing")]
      	/// <summary>
        /// 撰写单位
		/// </summary>
        public string Writing
        {
            get { return _writing; }
            set { _writing = value; }
        }
        
        private string _publishingdate;
        //[DataField("Publishingdate")]
      	/// <summary>
        /// 出版日期
		/// </summary>
        public string Publishingdate
        {
            get { return _publishingdate; }
            set { _publishingdate = value; }
        }
        
        private string _message;
        //[DataField("message")]
      	/// <summary>
        /// 内容
		/// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        
        private string _title;
        //[DataField("Title")]
      	/// <summary>
        /// Title
		/// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        
        private string _keywords;
        //[DataField("keywords")]
      	/// <summary>
        /// Keywords
		/// </summary>
        public string Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }
        
        private string _description;
        //[DataField("description")]
      	/// <summary>
        /// Description
		/// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        
    }
}
