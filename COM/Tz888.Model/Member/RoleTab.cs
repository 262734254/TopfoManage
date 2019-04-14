using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.ManageSystem
{
    public class RoleTab
    {
        public RoleTab() { }
        private string  manageTypeID;

        public string ManageTypeID
        {
            get { return manageTypeID; }
            set { manageTypeID = value; }
        }
        private string manageTypeName;

        public string ManageTypeName
        {
            get { return manageTypeName; }
            set { manageTypeName = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private DateTime rDate;

        public DateTime RDate
        {
            get { return rDate; }
            set { rDate = value; }
        }

        private int isCheck;

        public int IsCheck
        {
            get { return isCheck; }
            set { isCheck = value; }
        }

        private string _RName;

        public string RName
        {
            get { return _RName; }
            set { _RName = value; }
        }

        private int _RoleID;

        public int RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }

        private string _RDoc;

        public string RDoc
        {
            get { return _RDoc; }
            set { _RDoc = value; }
        }
    }
}
