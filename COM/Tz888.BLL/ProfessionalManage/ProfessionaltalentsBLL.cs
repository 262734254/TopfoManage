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
        /// �޸�һ��רҵ�˲�����
        /// </summary>
        /// <returns></returns>
        public bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionaltalents viewInfo, ProfessionalLink link)
        {
            return dal.UpdateProFessionlView(mainInfo, viewInfo, link);
        }
        /// <summary>
        /// �õ�һ������ʵ��
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
        /// ɾ����������ص�����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelInfoById(int id)
        {
            return dal.DelInfoById(id);
        }
    }
}
