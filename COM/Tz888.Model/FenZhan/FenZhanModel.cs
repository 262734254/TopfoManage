
using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.FenZhan
{
    //分站
    public class FenZhanModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        /// <summary>
        /// 分站名称
        /// </summary>
        private string _FenZhanName;
        public string FenZhanName { get { return _FenZhanName; } set { _FenZhanName = value; } }

        /// <summary>
        /// 分站地址
        /// </summary>
        private string _Address;
        public string Address { get { return _Address; } set { _Address = value; } }

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _CreateTime;
        public DateTime CreateTime { get { return _CreateTime; } set { _CreateTime = value; } }

        /// <summary>
        /// 分站状态(0->关闭,1->开启)
        /// </summary>
        public int _IsEnabled;
        public int IsEnabled { get { return _IsEnabled; } set { _IsEnabled = value; } }

        //城市ID
        private int _ProvinceID;
        public int ProvinceID { get { return _ProvinceID; } set { _ProvinceID = value; } }
    }
}
