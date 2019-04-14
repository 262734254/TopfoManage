using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model.Product
{
    [Serializable]
    public class ProductTypeM
    {
        #region Model
        private int _producttypeid;
        private string _productname;
        private int _orderId;
        public int orderId
        {
            set { _orderId = value; }
            get { return _orderId; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int productTypeid
        {
            set { _producttypeid = value; }
            get { return _producttypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        #endregion Model
    }
}
