using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model.Product
{
    [Serializable]
    public class ProductDominM
    {
        #region Model
        private int _productid;
        private string _loginname;
        private string _chineseintroduced;
        private string _englishintroduction;
        private DateTime _createdate;
        private string _htmlurl;
        private int _clicks;
        private int _producttypeid;
        private string _productName;
        public string productName
        {
            set { _productName = value; }
            get { return _productName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int productid
        {
            set { _productid = value; }
            get { return _productid; }
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
        public DateTime createdate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string htmlurl
        {
            set { _htmlurl = value; }
            get { return _htmlurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int clicks
        {
            set { _clicks = value; }
            get { return _clicks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int productTypeId
        {
            set { _producttypeid = value; }
            get { return _producttypeid; }
        }
        #endregion Model
    }
}
