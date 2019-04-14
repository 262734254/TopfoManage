using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Tz888.Model.ProfessionalManage;
using Tz888.BLL.ProfessionalManage;
using Tz888.IDAL.ProfessionalManage;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web;
using Tz888.DALFactory;
namespace Tz888.BLL.ProfessionalManage
{
    public class ProfessionalPleaseBLL
    {
        ProfessionalPleaseIDAL dal = DataAccess.CreatePleaseInfo();
       
        public ProfessionalPlease GetModel(int ProfessionalID)
        {
            return dal.GetModel(ProfessionalID);
        }
        public bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, ProfessionalPlease viewInfo, ProfessionalLink link)
        {
            return dal.UpdateProFessionlView(mainInfo, viewInfo, link);
        }
        public DataTable GetTop3ModelByProvinceID(int count, string strWhe)
        {
            return dal.GetTop3ModelByProvinceID(count, strWhe);

        }
        /// <summary>
        /// 删除跟主表相关的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelInfoById(int id)
        {
            return dal.DelInfoById(id);
        }
    }
}
