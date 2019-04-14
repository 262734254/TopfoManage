using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GZS.Model.Product;
using GZS.DAL.product;
namespace GZS.BLL.Product
{
    public class ProductTypeBLL
    {
        ProductTypeDAL dal = new ProductTypeDAL();
        #region  Method
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ProductTypeM model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(ProductTypeM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int productTypeid)
        {

            return dal.Delete(productTypeid);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string productTypeidlist)
        {
            return dal.DeleteList(productTypeidlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ProductTypeM GetModel(int productTypeid)
        {

            return dal.GetModel(productTypeid);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<ProductTypeM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<ProductTypeM> DataTableToList(DataTable dt)
        {
            List<ProductTypeM> modelList = new List<ProductTypeM>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ProductTypeM model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ProductTypeM();
                    if (dt.Rows[n]["productTypeid"].ToString() != "")
                    {
                        model.productTypeid = int.Parse(dt.Rows[n]["productTypeid"].ToString());
                    }
                    model.productName = dt.Rows[n]["productName"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��ҳ��ȡ�����б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}
