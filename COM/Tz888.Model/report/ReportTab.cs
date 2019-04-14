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
		/// ����
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
        /// ��������
		/// </summary>
        public string Reportname
        {
            get { return _reportname; }
            set { _reportname = value; }
        }
        
        private int _bigtypeid;
        //[DataField("bigtypeid")]
      	/// <summary>
        /// ��ҵ����
		/// </summary>
        public int Bigtypeid
        {
            get { return _bigtypeid; }
            set { _bigtypeid = value; }
        }
        
        private int _smalltypeid;
        //[DataField("smalltypeid")]
      	/// <summary>
        /// ��ҵС��
		/// </summary>
        public int Smalltypeid
        {
            get { return _smalltypeid; }
            set { _smalltypeid = value; }
        }
        
        private string _price;
        //[DataField("price")]
      	/// <summary>
        /// �۸�
		/// </summary>
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }
        
        private string _explain;
        //[DataField("explain")]
      	/// <summary>
        /// ժҪ
		/// </summary>
        public string Explain
        {
            get { return _explain; }
            set { _explain = value; }
        }
        
        private string _effectivedata;
        //[DataField("effectivedata")]
      	/// <summary>
        /// ��Ч�ڿ�ʼ
		/// </summary>
        public string Effectivedata
        {
            get { return _effectivedata; }
            set { _effectivedata = value; }
        }
        
        private string _invaliddata;
        //[DataField("invaliddata")]
      	/// <summary>
        /// ��Ч�ڽ���
		/// </summary>
        public string Invaliddata
        {
            get { return _invaliddata; }
            set { _invaliddata = value; }
        }
        
        private int _charges;
        //[DataField("charges")]
      	/// <summary>
        /// �Ƿ��շ� 0���շ�  1 �շ�
		/// </summary>
        public int Charges
        {
            get { return _charges; }
            set { _charges = value; }
        }
        
        private string _createdate;
        //[DataField("createdate")]
      	/// <summary>
        /// ��������
		/// </summary>
        public string Createdate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        
        private int _formID;
        //[DataField("FormID")]
      	/// <summary>
        /// ��Դ:1:ҵ��Ա2 ���ظ�
		/// </summary>
        public int FormID
        {
            get { return _formID; }
            set { _formID = value; }
        }
        
        private string _html;
        //[DataField("html")]
      	/// <summary>
        /// ��̬ҳ��
		/// </summary>
        public string Html
        {
            get { return _html; }
            set { _html = value; }
        }
        
        private int _auditid;
        //[DataField("auditid")]
      	/// <summary>
        /// ���״̬ 0δ��   1����
		/// </summary>
        public int Auditid
        {
            get { return _auditid; }
            set { _auditid = value; }
        }
        
        private int _recommendID;
        //[DataField("recommendID")]
      	/// <summary>
        /// �Ƿ��Ƽ�0:��1���Ƽ�
		/// </summary>
        public int RecommendID
        {
            get { return _recommendID; }
            set { _recommendID = value; }
        }
        
    }
}
