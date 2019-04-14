
using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.FenZhan
{
    //��վ
    public class FenZhanModel
    {
        /// <summary>
        /// ���
        /// </summary>
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        /// <summary>
        /// ��վ����
        /// </summary>
        private string _FenZhanName;
        public string FenZhanName { get { return _FenZhanName; } set { _FenZhanName = value; } }

        /// <summary>
        /// ��վ��ַ
        /// </summary>
        private string _Address;
        public string Address { get { return _Address; } set { _Address = value; } }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        private DateTime _CreateTime;
        public DateTime CreateTime { get { return _CreateTime; } set { _CreateTime = value; } }

        /// <summary>
        /// ��վ״̬(0->�ر�,1->����)
        /// </summary>
        public int _IsEnabled;
        public int IsEnabled { get { return _IsEnabled; } set { _IsEnabled = value; } }

        //����ID
        private int _ProvinceID;
        public int ProvinceID { get { return _ProvinceID; } set { _ProvinceID = value; } }
    }
}
