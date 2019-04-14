using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Product;
using GZS.DAL.product;
using System.Data;
namespace GZS.BLL.Product
{
    public class ProductDominBLL
    {
        ProductDominDAL dal = new ProductDominDAL();
        CommStatic comm = new CommStatic();
        public string GetPolicyListUIByLoginName(string loginName)
        {
            return comm.GetPolicyListUIByLoginName(loginName);
        }

        #region  Method
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ProductDominM model)
        {
            return dal.Add(model);
        }
        public int ExistsByProductTypeId(int typeId, string loginName)
        {
            return dal.ExistsByProductTypeId(typeId, loginName);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(ProductDominM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int productid)
        {

            return dal.Delete(productid);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string productidlist)
        {
            return dal.DeleteList(productidlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ProductDominM GetModel(int productid)
        {

            return dal.GetModel(productid);
        }
        public ProductDominM GetProductByName( string loginName)
        {
            return dal.GetProductByName(loginName);
        }
        public ProductDominM GetModel(int productTypeId, string loginName)
        {
            return dal.GetModel(productTypeId, loginName);
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
        public List<ProductDominM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<ProductDominM> DataTableToList(DataTable dt)
        {
            List<ProductDominM> modelList = new List<ProductDominM>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ProductDominM model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ProductDominM();
                    if (dt.Rows[n]["productid"].ToString() != "")
                    {
                        model.productid = int.Parse(dt.Rows[n]["productid"].ToString());
                    }
                    model.loginName = dt.Rows[n]["loginName"].ToString();
                    model.Chineseintroduced = dt.Rows[n]["Chineseintroduced"].ToString();
                    model.Englishintroduction = dt.Rows[n]["Englishintroduction"].ToString();
                    if (dt.Rows[n]["createdate"].ToString() != "")
                    {
                        model.createdate = DateTime.Parse(dt.Rows[n]["createdate"].ToString());
                    }
                    model.htmlurl = dt.Rows[n]["htmlurl"].ToString();
                    if (dt.Rows[n]["clicks"].ToString() != "")
                    {
                        model.clicks = int.Parse(dt.Rows[n]["clicks"].ToString());
                    }
                    if (dt.Rows[n]["productTypeId"].ToString() != "")
                    {
                        model.productTypeId = int.Parse(dt.Rows[n]["productTypeId"].ToString());
                    }
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
        /// <summary>
        /// ��test���ݿ�
        /// </summary>
        /// <param name="TableViewName">����</param>
        /// <param name="Key">����</param>
        /// <param name="SelectStr">��ѯ�ֶ�</param>
        /// <param name="Criteria">����</param>
        /// <param name="Sort">�����ֶ�</param>
        /// <param name="CurrentPage">��ǰҳ</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">�ܼ�¼</param>
        /// <returns></returns>
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetListT(TableViewName, Key, SelectStr, Criteria, Sort, ref CurrentPage, PageSize, ref TotalCount);
        }
    }
}
