using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.TradeShow
{
    public class TradeShowModel
    {
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }

        private int _Types;
        public int Types { get { return _Types; } set { _Types = value; } }

        private string _Img;
        public string Img { get { return _Img; } set { _Img = value; } }

        private string _UserName;
        public string UserName { get { return _UserName; } set { _UserName = value; } }

        private string _Job;
        public string Job { get { return _Job; } set { _Job = value; } }

        private int _Sort;
        public int Sort { get { return _Sort; } set { _Sort = value; } }

        private DateTime _PublishTime;
        public DateTime PublishTime { get { return _PublishTime; } set { _PublishTime = value; } }

        private string _Remark;
        public string Remark { get { return _Remark; } set { _Remark = value; } }
    }
}
