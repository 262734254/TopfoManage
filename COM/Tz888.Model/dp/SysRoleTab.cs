using System;
namespace Tz888.Model.dp
{
    /// <summary>
    /// 实体类SysRoleTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class SysRoleTab
    {
        public SysRoleTab()
        { }
        #region Model
        private int _sroleid;
        private string _srname;
        private string _srdoc;
        private string _syscode;
        private DateTime _srdate;
        /// <summary>
        /// 
        /// </summary>
        public int SRoleID
        {
            set { _sroleid = value; }
            get { return _sroleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SRName
        {
            set { _srname = value; }
            get { return _srname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SRDoc
        {
            set { _srdoc = value; }
            get { return _srdoc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SysCode
        {
            set { _syscode = value; }
            get { return _syscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime SRDate
        {
            set { _srdate = value; }
            get { return _srdate; }
        }
        #endregion Model

    }
}

