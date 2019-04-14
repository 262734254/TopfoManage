using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.wyzs
{
    //主表
    public class MainInfoTab
    {
        /// <summary>
        /// 主键
        /// </summary>
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        /// <summary>
        /// 标题
        /// </summary>
        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }

        /// <summary>
        /// 会员ID
        /// </summary>
        private string _MemberId;
        public string MemberId { get { return _MemberId; } set { _MemberId = value; } }

        /// <summary>
        /// 类型(1->求租,2->购买,3->出租,4->出售)
        /// </summary>
        private int _Types;
        public int Types { get { return _Types; } set { _Types = value; } }

        /// <summary>
        /// 状态(1->可用,2->不可用)
        /// </summary>
        private int _State;
        public int State { get { return _State; } set { _State = value; } }

        /// <summary>
        /// 静态页面地址
        /// </summary>
        private string _Htmlurl;
        public string Htmlurl { get { return _Htmlurl; } set { _Htmlurl = value; } }

        /// <summary>
        /// 发布时间
        /// </summary>
        private DateTime _PublishTime;
        public DateTime PublishTime { get { return _PublishTime; } set { _PublishTime = value; } }
    }
}
