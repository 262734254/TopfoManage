using System;
namespace Tz888.Model.dp
{
    /// <summary>
    /// 实体类SysMenuTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class SysMenuTab
    {
        public SysMenuTab()
        { }
        #region Model
        private int _sid;
        private string _sname;
        private int _scheck;
        private string _surl;
        private int _sisactive;
        private int _sparentcode;
        private string _scode;
        private string _starget;
        private DateTime _sdate;
        private int _sorder;
        private int _sparentsid;

        public int Sparentsid
        {
            get { return _sparentsid; }
            set { _sparentsid = value; }
        }

        public int Sorder
        {
            get { return _sorder; }
            set { _sorder = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SName
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SCheck
        {
            set { _scheck = value; }
            get { return _scheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Surl
        {
            set { _surl = value; }
            get { return _surl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SisActive
        {
            set { _sisactive = value; }
            get { return _sisactive; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SParentCode
        {
            set { _sparentcode = value; }
            get { return _sparentcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SCode
        {
            set { _scode = value; }
            get { return _scode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Starget
        {
            set { _starget = value; }
            get { return _starget; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime SDate
        {
            set { _sdate = value; }
            get { return _sdate; }
        }
        #endregion Model

    }
}

