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
        /// ����ͼ��ѯרҵ������Ϣ
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria">����</param>
        /// <param name="Sort">����</param>
        /// <param name="Page">ÿҳ��ʾ������</param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount">����</param>
        /// <returns></returns>
        public DataSet GetProViewInfoAll(string SelectStr, string Criteria, string Sort, long Page, long CurrentPageRow, out long TotalCount)

        {
            long lgTotalCount = 0;
            DataSet ds = dal.GetProViewInfoAll(SelectStr, Criteria, Sort, Page, CurrentPageRow, ref lgTotalCount);
            TotalCount = lgTotalCount;
            return ds;
        }
        /// <summary>
        /// �޸�һ��רҵ��������
        /// </summary>
        /// <returns></returns>
        public bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionalview viewInfo, ProfessionalLink link)
        {
            return dal.UpdateProFessionlView(mainInfo, viewInfo, link);
        }
         /// <summary>
        /// �õ�һ������ʵ��
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
