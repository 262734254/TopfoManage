using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.zstft
{
    //’–…ÃÕÿ∏£Õ®
    public class zstftModel
    {
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }

        private string _Category;
        public string Category { get { return _Category; } set { _Category = value; } }

        private int _Sort;
        public int Sort { get { return _Sort; } set { _Sort = value; } }

        private string _Address;
        public string Address { get { return _Address; } set { _Address = value; } }

        private string _LogName;
        public string LogName { get { return _LogName; } set { _LogName = value; } }

        private DateTime _PublishTime;
        public DateTime PublishTime { get { return _PublishTime; } set { _PublishTime = value; } }

        private string _Picture;
        public string Picture { get { return _Picture; } set { _Picture = value; } }

        private string _ProvinceName;
        public string ProvinceName { get { return _ProvinceName; } set { _ProvinceName = value; } }

        private string _Remark;
        public string Remark { get { return _Remark; } set { _Remark = value; } }
    }
}
