using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Resource
{
    public class Resource
    {
        /// <summary>
        /// ����
        /// </summary>
        private int _DeclarationId;
        public int DeclarationId { get { return _DeclarationId; } set { _DeclarationId = value; } }

        /// <summary>
        ///����  
        /// </summary>
        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }

        /// <summary>
        /// �������(Ͷ�ʷ�|���ʷ�|���̷�)
        /// </summary>
        private int _Identity;
        public int Identity { get { return _Identity; } set { _Identity = value; } }

        /// <summary>
        /// ��ҵ����
        /// </summary>
        private string _Industry;
        public string Industry { get { return _Industry; } set { _Industry = value; } }

        /// <summary>
        ///ʡ��
        /// </summary>
        private int _ProvinceId;
        public int ProvinceId { get { return _ProvinceId; } set { _ProvinceId = value; } }

        /// <summary>
        /// ����
        /// </summary>
        private int _CityId;
        public int CityId { get { return _CityId; } set { _CityId = value; } }

        /// <summary>
        /// ����˵��
        /// </summary>
        private string _Funds;
        public string Funds { get { return _Funds; } set { _Funds = value; } }

        /// <summary>
        /// ˵��
        /// </summary>
        private string _Explain;
        public string Explain { get { return _Explain; } set { _Explain = value; } }

        /// <summary>
        /// ��ϵ��
        /// </summary>
        private string _Contact;
        public string Contact { get { return _Contact; } set { _Contact = value; } }

        /// <summary>
        /// �绰
        /// </summary>
        private string _Phone;
        public string Phone { get { return _Phone; } set { _Phone = value; } }

        /// <summary>
        /// �ʼ�
        /// </summary>
        private string _Email;
        public string Email { get { return _Email; } set { _Email = value; } }

        /// <summary>
        /// ״̬
        /// </summary>
        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        /// <summary>
        /// ��ע
        /// </summary>
        private string _Remarks;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }

        /// <summary>
        /// ҵ��Ա�ʺ�
        /// </summary>
        private string _UserName;
        public string UserName { get { return _UserName; } set { _UserName = value; } }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        private DateTime _DateTimes;
        public DateTime DateTimes { get { return _DateTimes; } set { _DateTimes = value; } }
    }
}
