using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    /// <summary>
    /// °¸Àý
    /// </summary>
    public class CasesInfoTab
    {
       public CasesInfoTab()
		{}
		#region Model
		private long _casesinfoid;
		private long _infoid;
		private string _casestypeid;
		private string _content;
		private string _pic1;
		private string _pic2;
		/// <summary>
		/// 
		/// </summary>
		public long CasesInfoID
		{
			set{ _casesinfoid=value;}
			get{return _casesinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long InfoID
		{
			set{ _infoid=value;}
			get{return _infoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CasesTypeID
		{
			set{ _casestypeid=value;}
			get{return _casestypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pic1
		{
			set{ _pic1=value;}
			get{return _pic1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pic2
		{
			set{ _pic2=value;}
			get{return _pic2;}
		}
		#endregion Model
    }
}
