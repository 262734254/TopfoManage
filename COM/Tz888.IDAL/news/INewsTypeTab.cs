using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.news
{
    public interface INewsTypeTab
    {
        List<Tz888.Model.NewsTypeTab> GetAllNewsType();
        Tz888.Model.NewsTypeTab GetNewsTypeByTypeId(int typeId);
        int InsertNewTypeTab(Tz888.Model.NewsTypeTab newstypetab);
        int UpdateNewTypeTab(Tz888.Model.NewsTypeTab newstypetab);
    }
}
