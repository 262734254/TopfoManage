using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Park;
using GZS.DAL.Park;
using System.Data;
namespace GZS.BLL.Park
{
    public class ParkTypeBll
    {
        ParkTypeDal dal = new ParkTypeDal();
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ParkTypeM model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ParkTypeM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int parktypeid)
        {

            return dal.Delete(parktypeid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string parktypeidlist)
        {
            return dal.DeleteList(parktypeidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ParkTypeM GetModel(int parktypeid)
        {

            return dal.GetModel(parktypeid);
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
        public List<ParkTypeM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ParkTypeM> DataTableToList(DataTable dt)
        {
            List<ParkTypeM> modelList = new List<ParkTypeM>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ParkTypeM model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ParkTypeM();
                    if (dt.Rows[n]["parktypeid"].ToString() != "")
                    {
                        model.parktypeid = int.Parse(dt.Rows[n]["parktypeid"].ToString());
                    }
                    model.parktypename = dt.Rows[n]["parktypename"].ToString();
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
