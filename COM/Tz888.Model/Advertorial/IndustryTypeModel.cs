using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Advertorial
{
    [Serializable]
    public class IndustryTypeModel
    {

        #region Model
        private int _industryid;
        private string _industryname;
        private int _checkid;
        private string _desc;
        private int _classid;
        /// <summary>
        /// 
        /// </summary>
        public int industryID
        {
            set { _industryid = value; }
            get { return _industryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string industryName
        {
            set { _industryname = value; }
            get { return _industryname; }
        }
        public string desc
        {
            set { _desc = value; }
            get { return _desc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CheckiD
        {
            set { _checkid = value; }
            get { return _checkid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int classID
        {
            set { _classid = value; }
            get { return _classid; }
        }
        #endregion Model
    }
}
