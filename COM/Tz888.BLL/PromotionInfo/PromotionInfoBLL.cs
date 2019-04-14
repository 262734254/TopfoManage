using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.BLL.PromotionInfo
{
    public  class PromotionInfoBLL
    {
        PromotionInfoTab pr = new PromotionInfoTab();
        public int AddPromotion(int id, string name, string remark)
        {
            return pr.AddPromotion(id,name,remark);
        }
        public DataView SelPromotion() 
        {
            return pr.SelPromotion();
        }
    }
}
