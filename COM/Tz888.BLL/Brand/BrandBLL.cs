using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Brand;
using Tz888.SQLServerDAL.Brand;
using System.Data;

namespace Tz888.BLL.Brand
{
    /// <summary>
    /// Ʒ��
    /// </summary>
    public class BrandBLL
    {
        private readonly BrandDAL dal = new BrandDAL();

        public bool AddBrand(Tz888.Model.Brand.BrandModel Brand)
        {
            return dal.AddBrand(Brand);
        }

        /// <summary>
        /// �޸�Ʒ��
        /// </summary>
        /// <param name="brand">BrandModel</param>
        /// <returns></returns>
        public bool ModfiyBrand(Tz888.Model.Brand.BrandModel Brand)
        {
            return dal.ModfiyBrand(Brand);
        }

        /// <summary>
        /// ɾ��Ʒ��
        /// </summary>
        /// <param name="BrnadId">BrnadId</param>
        /// <returns></returns>
        public bool DeleteBrand(string BrnadId)
        {
            return dal.DeleteBrand(BrnadId);
        }

        /// <summary>
        /// ����BrandId��ȡƷ������
        /// </summary>
        /// <param name="BrandId">BrandId</param>
        /// <returns></returns>
        public DataTable GetBrandByBrandId(string BrandId)
        {
            return dal.GetBrandByBrandId(BrandId);
        }

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
        public System.Data.DataTable GetBrandList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
        {
            return dal.GetBrandList(ObjectName, Key, ShowFiled, Where, OrderFiled, ref PageCurrent, PageSize, ref TotalCount);
        }
    }
}
