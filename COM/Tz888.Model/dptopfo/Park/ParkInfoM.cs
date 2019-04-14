using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model.Park
{
    [Serializable]
    public class ParkInfoM
    {

        public ParkInfoM()
        { }
        #region Model
        private int _parkid;
        private string _parkname;
        private int _parktypeid;
        private string _chineseintroduced;
        private string _englishintroduction;
        private DateTime _createdate;
        private string _loginName;
        private string _htmlurl;
        public string htmlurl
        {
            set { _htmlurl = value; }
            get { return _htmlurl; }
        }
        public string loginName
        {
            set { _loginName = value; }
            get { return _loginName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int parkid
        {
            set { _parkid = value; }
            get { return _parkid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string parkName
        {
            set { _parkname = value; }
            get { return _parkname; }
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
        public string Chineseintroduced
        {
            set { _chineseintroduced = value; }
            get { return _chineseintroduced; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Englishintroduction
        {
            set { _englishintroduction = value; }
            get { return _englishintroduction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model
    }
}
