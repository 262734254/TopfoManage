using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.ProfessionalManage;
using Tz888.Model.ProfessionalManage;
using System.Data;
using Tz888.DALFactory;
namespace Tz888.BLL.ProfessionalManage
{
    public class ProfessionalviewBLL
    {
        ProfessionalviewIDAL dal = DataAccess.CreateviewInfo();
        /// <summary>
        /// 用视图查询专业服务信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria">条件</param>
        /// <param name="Sort">排序</param>
        /// <param name="Page">每页显示多少条</param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount">总数</param>
        /// <returns></returns>
        public DataSet GetProViewInfoAll(string SelectStr, string Criteria, string Sort, long Page, long CurrentPageRow, out long TotalCount)

        {
            long lgTotalCount = 0;
            DataSet ds = dal.GetProViewInfoAll(SelectStr, Criteria, Sort, Page, CurrentPageRow, ref lgTotalCount);
            TotalCount = lgTotalCount;
            return ds;
        }
        /// <summary>
        /// 修改一条专业服务数据
        /// </summary>
        /// <returns></returns>
        public bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionalview viewInfo, ProfessionalLink link)
        {
            return dal.UpdateProFessionlView(mainInfo, viewInfo, link);
        }
         /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Professionalview GetModel(int pvid)
        {
           return dal.GetModel(pvid);
        }
        public DataTable GetTop3ModelByProvinceID(int count,string strWhe )
        {
            return dal.GetTop3ModelByProvinceID(count,strWhe);
        }
    }
}
