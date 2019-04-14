using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.ProfessionalManage;
using Tz888.Model.ProfessionalManage;
using System.Data;
using Tz888.DALFactory;
namespace Tz888.BLL.ProfessionalManage
{
   public class ProfessionaltalentsBLL
   {
       ProfessionaltalentsIDAL dal = DataAccess.CreatetalentsInfo();
        /// <summary>
        /// 修改一条专业人才数据
        /// </summary>
        /// <returns></returns>
        public bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionaltalents viewInfo, ProfessionalLink link)
        {
            return dal.UpdateProFessionlView(mainInfo, viewInfo, link);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Professionaltalents GetModel(int ProfessionalID)
        {
            return dal.GetModel(ProfessionalID);
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
