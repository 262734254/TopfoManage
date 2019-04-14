using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.Model
{
    /// <summary>
    /// ʵ����M_areaTab ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class AreaTab
    {
        public AreaTab()
        { }
        #region Model
        private int _areaid;
        private string _loginname;
        private string _chineseintroduced;
        private string _englishintroduction;
        private string _createdates;
        private string _updatetimes;
        private string htmlurl;

        public string Htmlurl
        {
            get { return htmlurl; }
            set { htmlurl = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int areaid
        {
            set { _areaid = value; }
            get { return _areaid; }
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
        public string createdates
        {
            set { _createdates = value; }
            get { return _createdates; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Updatetimes
        {
            set { _updatetimes = value; }
            get { return _updatetimes; }
        }
        #endregion Model

    }
}

