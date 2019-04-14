using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.ProfessionalManage;
using Tz888.Model.ProfessionalManage;
using System.Data;
using Tz888.DALFactory;
namespace Tz888.BLL.ProfessionalManage
{
   public class ProfessionalLinkBLL
    {
       ProfessionalLinkIDAL dal = DataAccess.CreateLinkInfo();
       public ProfessionalLink GetModel(int Lid)
       {
           return dal.GetModel(Lid);
       }
       /// <summary>
       /// 通过省代码查找省名称
       /// </summary>
       /// <param name="ProvinceId"></param>
       /// <returns></returns>
       public string GetProvinceNameByCode(string ProvinceId)
       {
           return dal.GetProvinceNameByCode(ProvinceId);
       }
    }
}
