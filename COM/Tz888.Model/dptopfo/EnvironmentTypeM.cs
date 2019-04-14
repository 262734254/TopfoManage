using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model
{
   /// <summary>
	/// 实体类M_EnvironmentType 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class EnvironmentTypeM
	{
        public EnvironmentTypeM()
		{}
		#region Model
		private int _environmenttypeid;
		private string _environmenttypename;
		/// <summary>
		/// 
		/// </summary>
		public int EnvironmentTypeID
		{
			set{ _environmenttypeid=value;}
			get{return _environmenttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EnvironmentTypeName
		{
			set{ _environmenttypename=value;}
			get{return _environmenttypename;}
		}
		#endregion Model

	}
}

