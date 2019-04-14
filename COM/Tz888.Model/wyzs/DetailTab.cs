using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.wyzs
{
    public class DetailTab
    {
        /// <summary>
        /// 主键
        /// </summary>
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        /// <summary>
        /// 联系电话
        /// </summary>
        private string _TelePhone;
        public string TelePhone { get { return _TelePhone; } set { _TelePhone = value; } }

        /// <summary>
        /// 邮箱
        /// </summary>
        private string _Email;
        public string Email { get { return _Email; } set { _Email = value; } }

        /// <summary>
        /// 联系人
        /// </summary>
        private string _LinkMan;
        public string LinkMan { get { return _LinkMan; } set { _LinkMan = value; } }

        /// <summary>
        /// 来源(1->业主,2->需求)
        /// </summary>
        private int _Source;
        public int Source { get { return _Source; } set { _Source = value; } }

        /// <summary>
        /// 用途(1->门面,2->办公,3->商住两用)
        /// </summary>
        private int _Purpose;
        public int Purpose { get { return _Purpose; } set { _Purpose = value; } }

        /// <summary>
        /// 楼层(1->1-5楼,2->5-8楼,3->8楼以上)
        /// </summary>
        private int _Floor;
        public int Floor { get { return _Floor; } set { _Floor = value; } }

        /// <summary>
        /// 租金(1->40-60元/平方米,2->60-80元/平方米,3->80元以上)
        /// </summary>
        private int _Hire;
        public int Hire { get { return _Hire; } set { _Hire = value; } }

        /// <summary>
        /// 面积(1->100平米以内,2->100-200平米,3->200平米以上)
        /// </summary>
        private int _Area;
        public int Area { get { return _Area; } set { _Area = value; } }

        /// <summary>
        /// 装修(1->简装,2->无,3->豪装)
        /// </summary>
        private int _Fitment;
        public int Fitment { get { return _Fitment; } set { _Fitment = value; } }

        /// <summary>
        /// 电梯(1->有,2->无)
        /// </summary>
        private int _Elevator;
        public int Elevator { get { return _Elevator; } set { _Elevator = value; } }

        /// <summary>
        /// 主表ID
        /// </summary>
        private int _MainId;
        public int MainId { get { return _MainId; } set { _MainId = value; } }
    }
}
