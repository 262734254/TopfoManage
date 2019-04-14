using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Brand;
using System.Data;

namespace Tz888.IDAL.Brand
{
    /// <summary>
    /// Ʒ��
    /// </summary>
    public interface BrandIDAL
    {
        /// <summary>
        /// ���Ʒ��
        /// </summary>
        /// <param name="brand">BrandModel</param>
        /// <returns></returns>
        bool AddBrand(BrandModel Brand);

        /// <summary>
        /// �޸�Ʒ��
        /// </summary>
        /// <param name="brand">BrandModel</param>
        /// <returns></returns>
        bool ModfiyBrand(BrandModel Brand);

        /// <summary>
        /// ɾ��Ʒ��
        /// </summary>
        /// <param name="BrnadId">BrnadId</param>
        /// <returns></returns>
        bool DeleteBrand(string BrnadId);

        /// <summary>
        /// ����BrandId��ȡƷ������
        /// </summary>
        /// <param name="BrandId">BrandId</param>
        /// <returns></returns>
        DataTable GetBrandByBrandId(string BrandId);

        /// <summary>
        /// Ʒ���б�
        /// </summary>
        /// <param name="ObjectName">��/��ͼ</param>
        /// <param name="Key">����</param>
        /// <param name="ShowFiled">��ʾ�ֶ�</param>
        /// <param name="Where">����</param>
        /// <param name="OrderFiled">�����ֶ�</param>
        /// <param name="PageCurrent">��ǰҳ</param>
        /// <param name="PageSize">ҳ���С</param>
        /// <param name="TotalCount">������</param>
        /// <returns></returns>
        DataTable GetBrandList(string ObjectName,string Key,string ShowFiled,string Where,string OrderFiled,
            ref int PageCurrent,int PageSize,ref int TotalCount);
    }
}
