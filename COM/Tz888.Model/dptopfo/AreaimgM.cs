using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model
{
    /// <summary>
    /// ʵ����M_areaimg ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class Areaimg
    {
        public Areaimg()
        { }
        #region Model
        private int _areaimgid;
        private int? _areaid;
        private string _imagename;
        private string _imgageexplain;
        private string imageUrl;

        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int areaimgid
        {
            set { _areaimgid = value; }
            get { return _areaimgid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? areaid
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImageName
        {
            set { _imagename = value; }
            get { return _imagename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string imgageexplain
        {
            set { _imgageexplain = value; }
            get { return _imgageexplain; }
        }
        #endregion Model

    }
}

