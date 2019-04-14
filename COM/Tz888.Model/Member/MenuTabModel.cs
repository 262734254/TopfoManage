using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.ManageSystem
{
    public class MenuTabModel
    {
        public MenuTabModel() { }
        private int _Mid;

        public int Mid
        {
            get { return _Mid; }
            set { _Mid = value; }
        }
        private string sort;

        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }
   
        private string _MName;

        public string MName
        {
            get { return _MName; }
            set { _MName = value; }
        }
        private string _MCheck;

        public string MCheck
        {
            get { return _MCheck; }
            set { _MCheck = value; }
        }
        private string _Murl;

        public string Murl
        {
            get { return _Murl; }
            set { _Murl = value; }
        }
        private int _MIsActive;

        public int MIsActive
        {
            get { return _MIsActive; }
            set { _MIsActive = value; }
        }
        private int _MparentCode;

        public int MparentCode
        {
            get { return _MparentCode; }
            set { _MparentCode = value; }
        }
        private string _target;

        public string Target
        {
            get { return _target; }
            set { _target = value; }
        }
        private DateTime _MDate;

        public DateTime MDate
        {
            get { return _MDate; }
            set { _MDate = value; }
        }
        private string _MCode;

        public string MCode
        {
            get { return _MCode; }
            set { _MCode = value; }
        }



        
    }
}
