using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.ProfessionalManage;
namespace Tz888.IDAL.ProfessionalManage
{
    /// <summary>
    /// 专业服务需求
    /// </summary>
    public interface ProfessionalviewIDAL
    {
        DataSet GetProViewInfoAll(string SelectStr,string Criteria, string Sort,long Page,long CurrentPageRow, ref long TotalCount);
        /// <summary>
        /// 修改一条专业服务数据
        /// </summary>
        /// <returns></returns>
        Professionalview GetModel(int pvid);
        bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionalview viewInfo, ProfessionalLink link);
        DataTable GetTop3ModelByProvinceID(int count, string strWhe);
        
    }
}
