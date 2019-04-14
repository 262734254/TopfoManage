using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.Common;

namespace Tz888.IDAL.Common
{
    /// <summary>
    /// ��ҵ������ݿ�����߼��ӿڶ���
    /// </summary>
    public interface IIndustry
    {
        /// <summary>
        /// ȡ����ҵ����������б�
        /// </summary>
        /// <returns>��ҵ�����б�</returns>
        List<IndustryModel> GetAllList();


        /// <summary>
        /// ������ҵ�����ȡ��ҵ����
        /// </summary>
        /// <param name="IndustryID">��ҵ����</param>
        /// <returns></returns>
        string GetNameByID(string IndustryID);

        /// <summary>
        /// �޸�ʱ������ҵ�����ȡ��ҵ����
        /// </summary>
        /// <param name="IndustryID">list</param>
        /// <returns></returns>
        List<IndustryModel> GetIndustryList(string IndustryList);

          /// <summary>
        /// ����ID��ȡ��Ѷ����
        /// </summary>
        /// <param name="IndustryID">ID</param>
        /// <returns></returns>
        string GetSetNewsTypeByID(string NewsId);
        /// <summary>
        /// ��ȡ��������������Ϣ
        /// </summary>
        /// <returns></returns>
        DataView SetNewsType();
        /// <summary>
        /// ��ȡ������ҵ��Ϣ
        /// </summary>
        /// <returns></returns>
        DataView dvGetAllIndustry();
        /// <summary>
        /// ���������ͱ�
        /// </summary>
        /// <returns></returns>
        DataView SetAreaTab();
        /// <summary>
        /// ��Ϣ�ȼ���
        /// </summary>
        /// <returns></returns>
        //��Ϣ�ȼ���
        DataView SetGradeTab();
        /// <summary>
        /// ��Ϣ��ֵ
        /// </summary>
        /// <returns></returns>
        //��Ϣ��ֵ
        DataView SetFixWorthPointTab();
        /// <summary>
        /// ������ҳ���ͱ�
        /// </summary>
        /// <returns></returns>
        DataView SetNewsIndustry();
    }
}
