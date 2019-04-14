using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Visit
{
    public class VisitInfoModel
    {
        #region Model
        private int _visitid;
        private string _loginname;//�û���      
        private int? _valid;//�Ƿ���Ч  
        private string _mobile;//�ֻ�����
        private string _email;//��������
        private string _disposition;//��������
        private string _caption;//����˵��
        private string _remark;//�طñ�ע
        private int? _visitnew;//�Ƿ�ط�   
        private DateTime? _visittime;//�ط�ʱ��
        /// <summary>
        /// 
        /// </summary>
        public int VisitID
        {
            set { _visitid = value; }
            get { return _visitid; }
        }
        /// <summary>
        /// �û���
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Valid
        {
            set { _valid = value; }
            get { return _valid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Disposition
        {
            set { _disposition = value; }
            get { return _disposition; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Caption
        {
            set { _caption = value; }
            get { return _caption; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? VisitNew
        {
            set { _visitnew = value; }
            get { return _visitnew; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? VisitTime
        {
            set { _visittime = value; }
            get { return _visittime; }
        }
        #endregion Model
    }
}
