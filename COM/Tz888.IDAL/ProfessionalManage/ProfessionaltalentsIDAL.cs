using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.ProfessionalManage;
namespace Tz888.IDAL.ProfessionalManage
{
   public interface ProfessionaltalentsIDAL
    {
        /// <summary>
        /// 修改一条专业人才数据
        /// </summary>
        /// <returns></returns>

        bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionaltalents viewInfo, ProfessionalLink link);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Professionaltalents GetModel(int ProfessionalID);
       DataTable GetTop3ModelByProvinceID(int count, string strWhe);
        /// <summary>
        /// 删除跟主表相关的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DelInfoById(int id);
    }
}
