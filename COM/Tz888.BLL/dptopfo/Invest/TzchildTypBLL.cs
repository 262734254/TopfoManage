using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GZS.DAL.Invest;
using GZS.Model.Invest;
namespace GZS.BLL.Invest
{
    public class TzchildTypBLL
    {
        TzchildTypDAL dal = new TzchildTypDAL();
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TzchildTypeM model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(TzchildTypeM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int typeid)
        {

            return dal.Delete(typeid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string typeidlist)
        {
            return dal.DeleteList(typeidlist);
        }
        public TzchildTypeM GetModels(int typeid)
        {
            return dal.GetModels(typeid);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TzchildTypeM GetModel(int typeid)
        {

            return dal.GetModel(typeid);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TzchildTypeM GetModel(int tztypeid, string loginName)
        {

            return dal.GetModel(tztypeid, loginName);
        }
        public int ExistsByInvestTypeId(int tzTypeId, string loginName)
        {
            return dal.ExistsByInvestTypeId(tzTypeId, loginName);
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
        public List<TzchildTypeM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TzchildTypeM> DataTableToList(DataTable dt)
        {
            List<TzchildTypeM> modelList = new List<TzchildTypeM>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TzchildTypeM model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TzchildTypeM();
                    if (dt.Rows[n]["typeid"].ToString() != "")
                    {
                        model.typeid = int.Parse(dt.Rows[n]["typeid"].ToString());
                    }
                    model.loginName = dt.Rows[n]["loginName"].ToString();
                    if (dt.Rows[n]["tztypeid"].ToString() != "")
                    {
                        model.tztypeid = int.Parse(dt.Rows[n]["tztypeid"].ToString());
                    }
                    if (dt.Rows[n]["typeprice"].ToString() != "")
                    {
                        model.typeprice = decimal.Parse(dt.Rows[n]["typeprice"].ToString());
                    }
                    model.tzchildName = dt.Rows[n]["tzchildName"].ToString();
                    if (dt.Rows[n]["createTime"].ToString() != "")
                    {
                        model.createTime = DateTime.Parse(dt.Rows[n]["createTime"].ToString());
                    }
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
