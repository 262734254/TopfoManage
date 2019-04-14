using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model.Park
{
    [Serializable]
    public class ParkTypeM
    {
        public ParkTypeM()
        { }
        #region Model
        private int _parktypeid;
        private string _parktypename;
        private int _tzParId;
        public int tzParId
        {
            set { _tzParId = value; }
            get { return _tzParId; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int parktypeid
        {
            set { _parktypeid = value; }
            get { return _parktypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string parktypename
        {
            set { _parktypename = value; }
            get { return _parktypename; }
        }
        #endregion Model

    }
}
