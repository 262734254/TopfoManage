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
        /// �޸�һ��רҵ�˲�����
        /// </summary>
        /// <returns></returns>

        bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionaltalents viewInfo, ProfessionalLink link);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Professionaltalents GetModel(int ProfessionalID);
       DataTable GetTop3ModelByProvinceID(int count, string strWhe);
        /// <summary>
        /// ɾ����������ص�����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DelInfoById(int id);
    }
}
