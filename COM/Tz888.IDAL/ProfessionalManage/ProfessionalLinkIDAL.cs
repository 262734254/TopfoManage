using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.ProfessionalManage;

namespace Tz888.IDAL.ProfessionalManage
{
   public interface ProfessionalLinkIDAL
    {
       ProfessionalLink GetModel(int Lid);
       string GetProvinceNameByCode(string ProvinceId);
    }
}
