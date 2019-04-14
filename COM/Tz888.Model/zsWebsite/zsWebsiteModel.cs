using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.zsWebsite
{
    public class zsWebsiteModel
    {
        private string siteContent;

        public string SiteContent
        {
            get { return siteContent; }
            set { siteContent = value; }
        }
        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        private string _WebsiteName;
        public string WebsiteName { get { return _WebsiteName; } set { _WebsiteName = value; } }

        private string _LogName;
        public string LogName { get { return _LogName; } set { _LogName = value; } }

        private string _ProvinceName;
        public string ProvinceName { get { return _ProvinceName; } set { _ProvinceName = value; } }

        private DateTime _PublishTime;
        public DateTime PublishTime { get { return _PublishTime; } set { _PublishTime = value; } }

        private string _WebsiteUrl;
        public string WebsiteUrl { get { return _WebsiteUrl; } set { _WebsiteUrl = value; } }
    }
}
