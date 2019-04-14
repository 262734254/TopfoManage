using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Product;
using GZS.DAL.product;
using System.Data;
namespace GZS.BLL.Product
{
    public class ProductImgBLL
    {
        ProductImgDAL dal = new ProductImgDAL();
        #region  Method
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ProductImgM model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(ProductImgM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int Imgid)
        {

            return dal.Delete(Imgid);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string Imgidlist)
        {
            return dal.DeleteList(Imgidlist);
        }
        public bool DeleteByProductId(int ProcductId)
        {
            return dal.DeleteByProductId(ProcductId);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ProductImgM GetModel(int Imgid)
        {

            return dal.GetModel(Imgid);
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
        public List<ProductImgM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<ProductImgM> DataTableToList(DataTable dt)
        {
            List<ProductImgM> modelList = new List<ProductImgM>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ProductImgM model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ProductImgM();
                    if (dt.Rows[n]["Imgid"].ToString() != "")
                    {
                        model.Imgid = int.Parse(dt.Rows[n]["Imgid"].ToString());
                    }
                    if (dt.Rows[n]["productid"].ToString() != "")
                    {
                        model.productid = int.Parse(dt.Rows[n]["productid"].ToString());
                    }
                    model.imgName = dt.Rows[n]["imgName"].ToString();
                    model.imgexplain = dt.Rows[n]["imgexplain"].ToString();
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
        #endregion  Method
    }
}
