using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Park;
using GZS.DAL.Park;
using System.Data;
namespace GZS.BLL.Park
{
   public class ParkInfoBLL
    {
       ParkInfoDAL dal = new ParkInfoDAL();
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ParkInfoM model)
        {
            return dal.Add(model);
        }
       public int ExistsByParkTypeId(int typeId)
       {
           return dal.ExistsByParkTypeId(typeId);
       }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ParkInfoM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int parkid)
        {

            return dal.Delete(parkid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string parkidlist)
        {
            return dal.DeleteList(parkidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ParkInfoM GetModel(int parkid)
        {

            return dal.GetModel(parkid);
        }
       public ParkInfoM GetModel(int parktypeid, string loginName)
       {
           return dal.GetModel(parktypeid, loginName);
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
        public List<ParkInfoM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ParkInfoM> DataTableToList(DataTable dt)
        {
            List<ParkInfoM> modelList = new List<ParkInfoM>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ParkInfoM model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ParkInfoM();
                    if (dt.Rows[n]["parkid"].ToString() != "")
                    {
                        model.parkid = int.Parse(dt.Rows[n]["parkid"].ToString());
                    }
                    model.parkName = dt.Rows[n]["parkName"].ToString();
                    if (dt.Rows[n]["parktypeid"].ToString() != "")
                    {
                        model.parktypeid = int.Parse(dt.Rows[n]["parktypeid"].ToString());
                    }
                    model.Chineseintroduced = dt.Rows[n]["Chineseintroduced"].ToString();
                    model.Englishintroduction = dt.Rows[n]["Englishintroduction"].ToString();
                    if (dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
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
