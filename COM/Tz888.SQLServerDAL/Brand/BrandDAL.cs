using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Brand;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.Brand
{
    /// <summary>
    /// Ʒ��
    /// </summary>
    public class BrandDAL:BrandIDAL
    {
        #region BrandIDAL ��Ա

        CrmDBHelper crm = new CrmDBHelper();

        /// <summary>
        /// ���Ʒ��
        /// </summary>
        /// <param name="brand">BrandModel</param>
        /// <returns></returns>
        public bool AddBrand(Tz888.Model.Brand.BrandModel Brand)
        {
            string sql = "insert into BrandInfo(Title,ImgPath,Url,ShowPosition,Sort,Remarks) values(@Title,@ImgPath,@Url,@ShowPosition,@Sort,@Remarks)";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Title",SqlDbType.VarChar,200),
                new SqlParameter("@ImgPath",SqlDbType.VarChar,200),
                new SqlParameter("@Url",SqlDbType.VarChar,200),
                new SqlParameter("ShowPosition",SqlDbType.VarChar,200),
                new SqlParameter("Sort",SqlDbType.Int,4),
                new SqlParameter("Remarks",SqlDbType.VarChar,500)
            };
            Paras[0].Value = Brand.Title;
            Paras[1].Value = Brand.ImgPath;
            Paras[2].Value = Brand.Url;
            Paras[3].Value = Brand.ShowPosition;
            Paras[4].Value = Brand.Sort;
            Paras[5].Value = Brand.Remarks;

            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// �޸�Ʒ��
        /// </summary>
        /// <param name="brand">BrandModel</param>
        /// <returns></returns>
        public bool ModfiyBrand(Tz888.Model.Brand.BrandModel Brand)
        {
            //string sql = "insert into BrandInfo(Title,ImgPath,Url,ShowPosition,Sort,Remarks) values(@Title,@ImgPath,@Url,@ShowPosition,@Sort,@Remarks)";
            string sql = "update BrandInfo set Title=@Title,Url=@Url,ShowPosition=@ShowPosition,Sort=@Sort,Remarks=@Remarks where BrandId=@BrandId";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@BrandId",SqlDbType.Int,4),
                new SqlParameter("@Title",SqlDbType.VarChar,200),
                new SqlParameter("@ImgPath",SqlDbType.VarChar,200),
                new SqlParameter("@Url",SqlDbType.VarChar,200),
                new SqlParameter("ShowPosition",SqlDbType.VarChar,200),
                new SqlParameter("Sort",SqlDbType.Int,4),
                new SqlParameter("Remarks",SqlDbType.VarChar,500)
            };
            Paras[0].Value = Brand.BrandId;
            Paras[1].Value = Brand.Title;
            Paras[2].Value = Brand.ImgPath;
            Paras[3].Value = Brand.Url;
            Paras[4].Value = Brand.ShowPosition;
            Paras[5].Value = Brand.Sort;
            Paras[6].Value = Brand.Remarks;

            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// ɾ��Ʒ��
        /// </summary>
        /// <param name="BrnadId">BrnadId</param>
        /// <returns></returns>
        public bool DeleteBrand(string BrnadId)
        {
            string sql = "delete BrandInfo where BrandId=@BrandId";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@BrandId",SqlDbType.Int,4)
            };
            Paras[0].Value = BrnadId;
            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// ����BrandId��ȡƷ������
        /// </summary>
        /// <param name="BrandId">BrandId</param>
        /// <returns></returns>
        public DataTable GetBrandByBrandId(string BrandId)
        {
            string sql = "select * from BrandInfo where BrandId=@BrandId";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@BrandId",BrandId)
            };
            return crm.GetDataSet(sql, Paras);
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
        public DataTable GetBrandList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
											new SqlParameter("@Key",SqlDbType.VarChar,50),
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
											new SqlParameter("@Page",SqlDbType.BigInt),
											new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt)
										};

            parameters[0].Value = ObjectName;
            parameters[1].Value = Key;
            parameters[2].Value = ShowFiled;
            parameters[3].Value = Where;
            parameters[4].Value = OrderFiled;
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = PageCurrent;
            parameters[6].Value = PageSize;
            parameters[7].Direction = ParameterDirection.InputOutput;

            DataSet ds = crm.RunProcedure("GetDataList", parameters, "ds");

            if (ds == null)
                return null;
            dt = ds.Tables["ds"];
            if (dt != null)
            {
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt32(parameters[7].Value);
                    PageCurrent = Convert.ToInt32(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt32(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        PageCurrent = 1;
                    }
                    else
                    {
                        PageCurrent = 0;
                    }
                }
            }
            return dt;
        }

        #endregion
    }
}
