using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.ProfessionalManage;
namespace Tz888.IDAL.ProfessionalManage
{
    public interface ProfessionalinfoIDAL
    {
        /// <summary>
        /// ɾ����������ص�����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DelInfoById(int id);
        ProfessionalinfoTab GetModel(int id);
        /// <summary>
        /// �жϾ�̬ҳ���Ƿ����
        /// </summary>
        /// <param name="infoId"></param>
        string PaperExeists(int ProfessionalID);
/// <summary>
        /// ������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int ModfiyHit(int id);
        

    }
}
