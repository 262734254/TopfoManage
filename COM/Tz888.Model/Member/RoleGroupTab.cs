using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.ManageSystem
{
    public class RoleGroupTab
    {
        public RoleGroupTab() { }
        private string memberGradeID;

        public string MemberGradeID
        {
            get { return memberGradeID; }
            set { memberGradeID = value; }
        }
        private string manageTypeID;

        public string ManageTypeID
        {
            get { return manageTypeID; }
            set { manageTypeID = value; }
        }
        private string memberGradeName;

        public string MemberGradeName
        {
            get { return memberGradeName; }
            set { memberGradeName = value; }
        }
        private int sCheck;

        public int SCheck
        {
            get { return sCheck; }
            set { sCheck = value; }
        }
        private DateTime sDate;

        public DateTime SDate
        {
            get { return sDate; }
            set { sDate = value; }
        }

        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private int isVip;

        public int IsVip
        {
            get { return isVip; }
            set { isVip = value; }
        }

        private int _RoleID;

        public int RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }
        private string _SName;

        public string SName
        {
            get { return _SName; }
            set { _SName = value; }
        }
    }
}
