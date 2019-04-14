using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.ProfessionalManage;

namespace Tz888.IDAL.ProfessionalManage
{
   public interface ProfessionalPleaseIDAL
    {
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        ProfessionalPlease GetModel(int ProfessionalID);
       bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, ProfessionalPlease viewInfo, ProfessionalLink link);
       DataTable GetTop3ModelByProvinceID(int count, string strWhe);
       /// <summary>
       /// ɾ����������ص�����
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       bool DelInfoById(int id);
    }
}
