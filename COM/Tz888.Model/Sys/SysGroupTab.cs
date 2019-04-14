using System;
namespace Tz888.Model.Sys
{
    /// <summary>
    /// ʵ����SysGroupTab ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class SysGroupTab
    {
        public SysGroupTab()
        { }
        
        private string _SRoleID;
        private string _EmployeeID;
        private  string _SName;
        private string _SDescribe;
        private int  _SysCheck;
        private DateTime _SysDate;

        private int _SGID;
        public int SGID
        {
            set { _SGID = value; }
            get { return _SGID; }
        }


        public string SRoleID
        {
            set { _SRoleID = value; }
            get { return _SRoleID; }
        }
        public string EmployeeID
        {
            set { _EmployeeID = value; }
            get { return _EmployeeID; }
        }
        public string SName
        {
            set { _SName = value; }
            get { return _SName; }
        }
        public string SDescribe
        {
            set { _SDescribe = value; }
            get { return _SDescribe; }
        }
        public int SysCheck
        {
            set { _SysCheck = value; }
            get { return _SysCheck; }
        }
        public DateTime SysDate
        {
            set { _SysDate= value; }
            get { return _SysDate; }
        }

        //�����
        private int _RoleID;

        public int RoleID
        {
            set { _RoleID = value; }
            get { return _RoleID; }
        
        }

        private int _SID;
        public int SID
        {

            set { _SID = value; }
            get { return _SID; }
        }


    }
}

