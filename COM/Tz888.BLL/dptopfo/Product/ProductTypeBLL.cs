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
        /// 增加一条数据
        /// </summary>
        public int Add(ProductTypeM model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ProductTypeM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int productTypeid)
        {

            return dal.Delete(productTypeid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string productTypeidlist)
        {
            return dal.DeleteList(productTypeidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProductTypeM GetModel(int productTypeid)
        {

            return dal.GetModel(productTypeid);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ProductTypeM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}
