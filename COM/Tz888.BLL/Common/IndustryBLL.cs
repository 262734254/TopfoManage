using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Common;
using Tz888.IDAL.Common;
using Tz888.DALFactory;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.BLL.Common
{
    /// <summary>
    /// ��ҵ�����Ϣҵ���߼�������
    /// </summary>
    public class IndustryBLL
    {
        private readonly IIndustry dal = DataAccess.CreateIndustry();

        /// <summary>
        /// ��ȡ������ҵ������Ϣ
        /// </summary>
        /// <returns>��ҵ������Ϣ�б�</returns>
        public List<IndustryModel> GetAllList()
        {
            return dal.GetAllList();
        } 


        /// <summary>
        /// ������ҵ�����ȡ��ҵ����
        /// </summary>
        /// <param name="IndustryID">��ҵ����</param>
        /// <returns></returns>
        public string GetNameByID(string IndustryID)
        {
            return dal.GetNameByID(IndustryID);
        }

        /// <summary>
        /// ���������ͱ�
        /// </summary>
        /// <returns></returns>
        public DataView SetAreaTab()
        {
            return dal.SetAreaTab();
        }
        /// <summary>
        /// ������ҳ���ͱ�
        /// </summary>
        /// <returns></returns>
        public DataView SetNewsIndustry()
        {
            return dal.SetNewsIndustry();
        }

        /// <summary>
        /// �޸�ʱ������ҵ�����ȡ��ҵ����
        /// </summary>
        /// <param name="IndustryID">list</param>
        /// <returns></returns>
        public List<IndustryModel> GetIndustryList(string IndustryList)
        {
            return dal.GetIndustryList(IndustryList);
        }


        public DataView SetNewsType()
        {
            return dal.SetNewsType();
        }
        /// <summary>
        /// ��ȡ��ҵ��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataView dvGetAllIndustry()
        {
            return dal.dvGetAllIndustry();
        }
        public string GetSetNewsTypeByID(string NewsId)
        {
            return dal.GetSetNewsTypeByID(NewsId);
        }
        #region IIndustry ��Ա

        /// <summary>
        /// ��Ϣ�ȼ���
        /// </summary>
        /// <returns></returns>
        //��Ϣ�ȼ���
        public DataView SetGradeTab()
        {
            return dal.SetGradeTab();
        }
        /// <summary>
        /// ��Ϣ��ֵ
        /// </summary>
        /// <returns></returns>
        //��Ϣ��ֵ
        public DataView SetFixWorthPointTab()
        {
            return dal.SetFixWorthPointTab();
        }

        #endregion

    }
}
