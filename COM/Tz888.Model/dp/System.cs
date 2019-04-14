using System;
namespace Tz888.Model.dp
{
    /// <summary>
    /// 实体类System 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class System
    {
        public System()
        { }
        #region Model
        private string _employeeid;
        private string _tem;
        /// <summary>
        /// 
        /// </summary>
        public string EmployeeID
        {
            set { _employeeid = value; }
            get { return _employeeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tem
        {
            set { _tem = value; }
            get { return _tem; }
        }
        #endregion Model

    }
}

