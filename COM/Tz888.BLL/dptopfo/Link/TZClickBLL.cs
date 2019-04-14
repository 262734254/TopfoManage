using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Link;
using GZS.DAL.Link;
using System.Data;
using System.Data.SqlClient;
namespace GZS.BLL.Link
{
    public class TZClickBLL
    {
        private readonly TZClickDAL dal = new TZClickDAL();

        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TZClickM model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(TZClickM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TZClickM GetModel(int id)
        {

            return dal.GetModel(id);
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
        public int ModfiyHit(string name, int pageId)
        {
            return dal.ModfiyHit(name, pageId);
        }
        public bool ExistsIsUserName(string loginName, int pageId)
        {
            return dal.ExistsIsUserName(loginName, pageId);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TZClickM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TZClickM> DataTableToList(DataTable dt)
        {
            List<TZClickM> modelList = new List<TZClickM>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TZClickM model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TZClickM();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.loginName = dt.Rows[n]["loginName"].ToString();
                    if (dt.Rows[n]["createTime"].ToString() != "")
                    {
                        model.createTime = DateTime.Parse(dt.Rows[n]["createTime"].ToString());
                    }
                    if (dt.Rows[n]["ClickId"].ToString() != "")
                    {
                        model.ClickId = int.Parse(dt.Rows[n]["ClickId"].ToString());
                    }
                    if (dt.Rows[n]["PageId"].ToString() != "")
                    {
                        model.PageId = int.Parse(dt.Rows[n]["PageId"].ToString());
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
        /// 获得今日,昨天，历史用户访问量
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="pageId">页面ID</param>
        /// <param name="day">0,表是历史，1,表示今天 2，表是昨天</param>
        /// <returns></returns>
        public int GetTodayCount(string loginName, int pageId, int day)
        {
            return dal.GetTodayCount(loginName, pageId, day);
        }
               /// <summary>
        /// 获得今日,昨天，历史用户访问量
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="day">0,表是历史，1,表示今天 2，表是昨天</param>
        /// <returns></returns>
        public int GetTodayCount(string loginName, int day)
        {
            return dal.GetTodayCount(loginName, day);
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
