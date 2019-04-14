using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Express
{
    [Serializable]
    public class ExpressModel
    {


        public ExpressModel()
        { }
        #region Model
        private int _expressid;
        private string _express;
        private DateTime? _expressdata;
        private int? _recommend;
        /// <summary>
        /// 
        /// </summary>
        public int expressID
        {
            set { _expressid = value; }
            get { return _expressid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string express
        {
            set { _express = value; }
            get { return _express; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Expressdata
        {
            set { _expressdata = value; }
            get { return _expressdata; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? recommend
        {
            set { _recommend = value; }
            get { return _recommend; }
        }
        #endregion Model
    }
}
