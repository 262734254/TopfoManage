using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model.Park
{
    [Serializable]
    public class ParkImgM
    {
        public ParkImgM()
        { }
        #region Model
        private int _imgid;
        private int _parkid;
        private string _imgname;
        private string _imgexplain;
        /// <summary>
        /// 
        /// </summary>
        public int imgId
        {
            set { _imgid = value; }
            get { return _imgid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int parkId
        {
            set { _parkid = value; }
            get { return _parkid; }
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
