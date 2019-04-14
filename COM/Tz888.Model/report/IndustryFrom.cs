using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.report
{
    [Serializable]
    public class IndustryFrom
    {
        public IndustryFrom()
        { }
        private int _industryid;
        //private int _fromid;
        private string _industryname;
        private string _linkman;
        private string _tel;
        private string _email;
        private string _phone;
        private string _fax;
        private string _company;
        private string _address;
        private string _qq;
        private string _site;
        private string _meo;
        public string meo
        {
            set { _meo = value; }
            get { return _meo; }
        }
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        public string site
        {
            set { _site = value; }
            get { return _site; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int industryId
        {
            set { _industryid = value; }
            get { return _industryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        //public int fromId
        //{
        //    set { _fromid = value; }
        //    get { return _fromid; }
        //}
        /// <summary>
        /// 
        /// </summary>
        public string industryName
        {
            set { _industryname = value; }
            get { return _industryname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkMan
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }

    }
}
