using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.wyzs
{
    public class DetailTab
    {
        /// <summary>
        /// ����
        /// </summary>
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        private string _TelePhone;
        public string TelePhone { get { return _TelePhone; } set { _TelePhone = value; } }

        /// <summary>
        /// ����
        /// </summary>
        private string _Email;
        public string Email { get { return _Email; } set { _Email = value; } }

        /// <summary>
        /// ��ϵ��
        /// </summary>
        private string _LinkMan;
        public string LinkMan { get { return _LinkMan; } set { _LinkMan = value; } }

        /// <summary>
        /// ��Դ(1->ҵ��,2->����)
        /// </summary>
        private int _Source;
        public int Source { get { return _Source; } set { _Source = value; } }

        /// <summary>
        /// ��;(1->����,2->�칫,3->��ס����)
        /// </summary>
        private int _Purpose;
        public int Purpose { get { return _Purpose; } set { _Purpose = value; } }

        /// <summary>
        /// ¥��(1->1-5¥,2->5-8¥,3->8¥����)
        /// </summary>
        private int _Floor;
        public int Floor { get { return _Floor; } set { _Floor = value; } }

        /// <summary>
        /// ���(1->40-60Ԫ/ƽ����,2->60-80Ԫ/ƽ����,3->80Ԫ����)
        /// </summary>
        private int _Hire;
        public int Hire { get { return _Hire; } set { _Hire = value; } }

        /// <summary>
        /// ���(1->100ƽ������,2->100-200ƽ��,3->200ƽ������)
        /// </summary>
        private int _Area;
        public int Area { get { return _Area; } set { _Area = value; } }

        /// <summary>
        /// װ��(1->��װ,2->��,3->��װ)
        /// </summary>
        private int _Fitment;
        public int Fitment { get { return _Fitment; } set { _Fitment = value; } }

        /// <summary>
        /// ����(1->��,2->��)
        /// </summary>
        private int _Elevator;
        public int Elevator { get { return _Elevator; } set { _Elevator = value; } }

        /// <summary>
        /// ����ID
        /// </summary>
        private int _MainId;
        public int MainId { get { return _MainId; } set { _MainId = value; } }
    }
}
