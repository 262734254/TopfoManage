using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model.Invest
{
    [Serializable]
    public class TzbigTypeM
    {
        #region Model
        private int _tztypeid;
        private string _tztypename;
        private int _tzParId;
        public int tzParId
        {
            set { _tzParId = value; }
            get { return _tzParId; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tztypeid
        {
            set { _tztypeid = value; }
            get { return _tztypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tztypeName
        {
            set { _tztypename = value; }
            get { return _tztypename; }
        }
        #endregion Model
    }
}
