using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.BLL.CatialManage
{
    public class CatialInfoBLL
    {
        private readonly Tz888.SQLServerDAL.CatialManage.CatialInfoDAL dal = new Tz888.SQLServerDAL.CatialManage.CatialInfoDAL();
        //��ȡ��ҵ����
        public string GetInduyName(string Induy)
        {
            return dal.GetInduyName(Induy);
        }

        //��ȡ��ҵID
        public string GetIndustryBID(string Induy)
        {
            return dal.GetIndustryBID(Induy);
        }

        /// <summary>
        /// ��ȡ��ҳ��
        /// </summary>
        /// <param name="PageCount">������</param>
        /// <param name="PageSize">ÿҳ������</param>
        /// <returns>��ҳ��</returns>
        public int GetPageCount(int Count, int PageSize)
        {
            return dal.GetPageCount(Count, PageSize);
        }

        /// <summary>
        /// ������ҵ��ȡ������
        /// </summary>
        /// <param name="Induy">��ҵ</param>
        /// <returns></returns>
        public int GetCountByIndustryBID(string IndustryBID)
        {
            return dal.GetCountByIndustryBID(IndustryBID);
        }


        /// <summary>
        /// ������ҵ�������ȡ������
        /// </summary>
        /// <param name="IndustryBID">��ҵ</param>
        /// <param name="Province">����</param>
        /// <returns></returns>
        public int GetCountByIndustryBIDAndProvinceID(string IndustryBID, string ProvinceID)
        {
            return dal.GetCountByIndustryBIDAndProvinceID(IndustryBID, ProvinceID);
        }

        /// <summary>
        /// ���������ȡ������
        /// </summary>
        /// <param name="Induy">����</param>
        /// <returns></returns>
        public int GetCountByProvinceID(string ProvinceID)
        {
            return dal.GetCountByProvinceID(ProvinceID);
        }

        /// <summary>
        /// ������ҵID��ȡͶ����Ϣ
        /// </summary>
        /// <param name="PageCurrent">��ǰҳ</param>
        /// <param name="IndustryBID">��ҵID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCatialInfoIndustryBID(int PageCurrent, string IndustryBID)
        {
            return dal.GetCatialInfoIndustryBID(PageCurrent, IndustryBID);
        }

        /// <summary>
        /// ��������ID��ȡͶ����Ϣ
        /// </summary>
        /// <param name="PageCurrent">��ǰҳ</param>
        /// <param name="ProvinceID">����ID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCatialInfoByProvinceID(int PageCurrent, string ProvinceID)
        {
            return dal.GetCatialInfoByProvinceID(PageCurrent, ProvinceID);
        }

        /// <summary>
        /// ������ҵID������ID��ȡͶ����Ϣ
        /// </summary>
        /// <param name="PageCurrent">��ǰҳ</param>
        /// <param name="IndustryBID">��ҵID</param>
        /// <param name="ProvinceID">����ID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCatialInfoByIndustryBIDAndProvinceID(int PageCurrent, string IndustryBID, string ProvinceID)
        {
            return dal.GetCatialInfoByIndustryBIDAndProvinceID(PageCurrent, IndustryBID, ProvinceID);
        }
    }
}
