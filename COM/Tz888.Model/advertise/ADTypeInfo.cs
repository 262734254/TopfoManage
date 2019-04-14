using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.advertise
{
    [Serializable]
    public class ADTypeInfo
    {
        #region Model
        private int _tid;
        private string _typename;
        private string _tdoc;
        /// <summary>
        /// 
        /// </summary>
        public int TID
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TDoc
        {
            set { _tdoc = value; }
            get { return _tdoc; }
        }
        #endregion Model
    }
}
