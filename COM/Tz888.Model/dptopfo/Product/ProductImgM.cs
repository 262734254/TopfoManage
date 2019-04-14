using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model.Product
{
    [Serializable]
    public class ProductImgM
    {
        #region Model
        private int _imgid;
        private int _productid;
        private string _imgname;
        private string _imgexplain;
        /// <summary>
        /// 
        /// </summary>
        public int Imgid
        {
            set { _imgid = value; }
            get { return _imgid; }
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
        public string imgName
        {
            set { _imgname = value; }
            get { return _imgname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string imgexplain
        {
            set { _imgexplain = value; }
            get { return _imgexplain; }
        }
        #endregion Model
    }
}
