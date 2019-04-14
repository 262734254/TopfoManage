using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GZS.DAL.Invest;
using GZS.Model.Invest;
namespace GZS.BLL.Invest
{
  public  class TzbigTypeBLL
    {
      TzbigTypeDAL dal = new TzbigTypeDAL();
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TzbigTypeM model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(TzbigTypeM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int tztypeid)
        {

            return dal.Delete(tztypeid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string tztypeidlist)
        {
            return dal.DeleteList(tztypeidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TzbigTypeM GetModel(int tztypeid)
        {

            return dal.GetModel(tztypeid);
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
        public List<TzbigTypeM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TzbigTypeM> DataTableToList(DataTable dt)
        {
            List<TzbigTypeM> modelList = new List<TzbigTypeM>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TzbigTypeM model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TzbigTypeM();
                    if (dt.Rows[n]["tztypeid"].ToString() != "")
                    {
                        model.tztypeid = int.Parse(dt.Rows[n]["tztypeid"].ToString());
                    }
                    model.tztypeName = dt.Rows[n]["tztypeName"].ToString();
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
