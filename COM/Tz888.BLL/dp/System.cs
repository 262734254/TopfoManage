using System;
using System.Data;
using System.Collections.Generic;
using Tz888.Model.dp;
using Tz888.DALFactory;
using Tz888.IDAL.dp;
namespace Tz888.BLL.dp
{
    /// <summary>
    /// 业务逻辑类System 的摘要说明。
    /// </summary>
    public class System
    {
        private readonly ISystem dal = DataAccess.CreatedpSystem();
        public System()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string EmployeeID)
        {
            return dal.Exists(EmployeeID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tz888.Model.dp.System model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Tz888.Model.dp.System model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string EmployeeID)
        {

            dal.Delete(EmployeeID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.dp.System GetModel(string EmployeeID)
        {

            return dal.GetModel(EmployeeID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Tz888.Model.dp.System GetModelByCache(string EmployeeID)
        {

            string CacheKey = "SystemModel-" + EmployeeID;
            object objModel = dal.GetModel(EmployeeID);

            return (Tz888.Model.dp.System)objModel;
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
        public List<Tz888.Model.dp.System> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tz888.Model.dp.System> DataTableToList(DataTable dt)
        {
            List<Tz888.Model.dp.System> modelList = new List<Tz888.Model.dp.System>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tz888.Model.dp.System model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tz888.Model.dp.System();
                    if (dt.Rows[n]["EmployeeID"].ToString() != "")
                    {
                        model.EmployeeID =dt.Rows[n]["EmployeeID"].ToString();
                    }
                    model.Tem = dt.Rows[n]["Tem"].ToString();
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
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
    }
}

