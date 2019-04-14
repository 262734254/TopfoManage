//============================================================
// Producnt name:		ExamSystem
// Version: 			1.0
// Coded by:			Eagle Lifeng
// Auto generated at: 	2011-4-6 15:51:58
//============================================================

using System;

namespace Tz888.Model.report
{
    [Serializable]
    public class ReportTab
    {
       	/// <summary>
		/// 主键
		/// </summary>
        private int _reportID;
        //[DataField("reportID")]
        public int ReportID
        {
            get { return _reportID; }
            set { _reportID = value; }
        }
        private string overTime;
        public string OverTime
        {
            get { return overTime; }
            set { overTime = value; }
        } 
        private int clickId;
        public int ClickId
        {
            get { return clickId; }
            set { clickId = value; }
        }
      
        private string _reportname;
        //[DataField("reportname")]
      	/// <summary>
        /// 报告名称
		/// </summary>
        public string Reportname
        {
            get { return _reportname; }
            set { _reportname = value; }
        }
        
        private int _bigtypeid;
        //[DataField("bigtypeid")]
      	/// <summary>
        /// 行业大类
		/// </summary>
        public int Bigtypeid
        {
            get { return _bigtypeid; }
            set { _bigtypeid = value; }
        }
        
        private int _smalltypeid;
        //[DataField("smalltypeid")]
      	/// <summary>
        /// 行业小类
		/// </summary>
        public int Smalltypeid
        {
            get { return _smalltypeid; }
            set { _smalltypeid = value; }
        }
        
        private string _price;
        //[DataField("price")]
      	/// <summary>
        /// 价格
		/// </summary>
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }
        
        private string _explain;
        //[DataField("explain")]
      	/// <summary>
        /// 摘要
		/// </summary>
        public string Explain
        {
            get { return _explain; }
            set { _explain = value; }
        }
        
        private string _effectivedata;
        //[DataField("effectivedata")]
      	/// <summary>
        /// 有效期开始
		/// </summary>
        public string Effectivedata
        {
            get { return _effectivedata; }
            set { _effectivedata = value; }
        }
        
        private string _invaliddata;
        //[DataField("invaliddata")]
      	/// <summary>
        /// 有效期结束
		/// </summary>
        public string Invaliddata
        {
            get { return _invaliddata; }
            set { _invaliddata = value; }
        }
        
        private int _charges;
        //[DataField("charges")]
      	/// <summary>
        /// 是否收费 0不收费  1 收费
		/// </summary>
        public int Charges
        {
            get { return _charges; }
            set { _charges = value; }
        }
        
        private string _createdate;
        //[DataField("createdate")]
      	/// <summary>
        /// 创建日期
		/// </summary>
        public string Createdate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        
        private int _formID;
        //[DataField("FormID")]
      	/// <summary>
        /// 来源:1:业务员2 ：拓富
		/// </summary>
        public int FormID
        {
            get { return _formID; }
            set { _formID = value; }
        }
        
        private string _html;
        //[DataField("html")]
      	/// <summary>
        /// 静态页面
		/// </summary>
        public string Html
        {
            get { return _html; }
            set { _html = value; }
        }
        
        private int _auditid;
        //[DataField("auditid")]
      	/// <summary>
        /// 审核状态 0未审   1已审
		/// </summary>
        public int Auditid
        {
            get { return _auditid; }
            set { _auditid = value; }
        }
        
        private int _recommendID;
        //[DataField("recommendID")]
      	/// <summary>
        /// 是否推荐0:不1：推荐
		/// </summary>
        public int RecommendID
        {
            get { return _recommendID; }
            set { _recommendID = value; }
        }
        
    }
}
