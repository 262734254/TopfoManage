using System;
namespace Tz888.Model.dp
{
    /// <summary>
    /// 实体类SysPermissionTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class SysPermissionTab
    {
        public SysPermissionTab()
        { }
        #region Model
        private int _spid;
        private int _roleid;
        private int _sysid;
        private string _spcode;
        private DateTime _spdate;
        /// <summary>
        /// 
        /// </summary>
        public int SPID
        {
            set { _spid = value; }
            get { return _spid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SysID
        {
            set { _sysid = value; }
            get { return _sysid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPCode
        {
            set { _spcode = value; }
            get { return _spcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime SPDate
        {
            set { _spdate = value; }
            get { return _spdate; }
        }
        #endregion Model

    }
}

