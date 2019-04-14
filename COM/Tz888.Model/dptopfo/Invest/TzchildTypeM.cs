using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model.Invest
{
    [Serializable]
   public  class TzchildTypeM
    {
        #region Model
        private int _typeid;
        private string _loginname;
        private int _tztypeid;
        private decimal _typeprice;
        private string _tzchildname;
       private DateTime _createTime;
       public DateTime createTime
       {
           set { _createTime = value; }
           get { return _createTime; }
       }
        /// <summary>
        /// 
        /// </summary>
        public int typeid
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string loginName
        {
            set { _loginname = value; }
            get { return _loginname; }
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
        public decimal typeprice
        {
            set { _typeprice = value; }
            get { return _typeprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tzchildName
        {
            set { _tzchildname = value; }
            get { return _tzchildname; }
        }
        #endregion Model
    }
}
