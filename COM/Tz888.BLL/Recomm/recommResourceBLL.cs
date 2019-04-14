using System;
using System.Data;
using System.Collections.Generic;
using Tz888.Model.Recomm;
using Tz888.DALFactory;
using Tz888.IDAL.Recomm;
using Tz888.Model.Info;
using Tz888.SQLServerDAL.Recomm;
namespace Tz888.BLL.Recomm
{
    /// <summary>
    /// recommResourceBLL
    /// </summary>
    public partial class recommResourceBLL
    {
        //private readonly recommResourceIDAL dal=DataAccess.CreaterecommResourceDAL();
        private readonly recommResourceDAL dal = new recommResourceDAL();
        public recommResourceBLL()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RecommID)
        {
            return dal.Exists(RecommID);
        }
        #region 分页查询
        /// <summary>
        /// 用topfocrm数据库
        /// </summary>
        /// <param name="TableViewName">表名</param>
        /// <param name="Key">主键</param>
        /// <param name="SelectStr">查询字段</param>
        /// <param name="Criteria">条件</param>
        /// <param name="Sort">排序字段</param>
        /// <param name="CurrentPage">当前页</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="TotalCount">总记录</param>
        /// <returns></returns>
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetListT(TableViewName, Key, SelectStr, Criteria, Sort,
            ref CurrentPage, PageSize, ref TotalCount);
        }
        #endregion
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tz888.Model.Recomm.recommResourceM model)
        {
            return dal.Add(model);
        }
        public string SelCompanyUserName()
        {
            return dal.SelCompanyUserName();
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Tz888.Model.Recomm.recommResourceM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RecommID)
        {

            return dal.Delete(RecommID);
        }
        /// <summary>
        /// 根据条件查询是否存在数据
        /// </summary>
        /// <param name="RecommTypeID">资源类型1,招商、融资、投资2,人才3,机构4, 服务</param>
        /// <param name="RecommToUser">推荐用户</param>
        /// <param name="ResourecId">推荐资源ID</param>
        /// <returns></returns>
        public int ExistsByWhere(int RecommTypeID, string RecommToUser, long ResourecId)
        {
            return dal.ExistsByWhere(RecommTypeID, RecommToUser, ResourecId);
        }
        /// <summary>
        /// 由于数据已经推荐过，只需更新时间
        /// </summary>
        /// <returns></returns>
        public int UpdateTimeByRecommId(int recommId)
        {
            return dal.UpdateTimeByRecommId(recommId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string RecommIDlist)
        {
            return dal.DeleteList(RecommIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Recomm.recommResourceM GetModel(int RecommID)
        {

            return dal.GetModel(RecommID);
        }
        /// <summary>
        /// 推荐 从主表中获取数据 title ,url
        /// 连接的数据库不同
        /// </summary>
        /// <param name="infoid"></param>
        /// <returns></returns>
        public DataSet GetTitleAndUrlByInfoId(string infoid)
        {
            return dal.GetTitleAndUrlByInfoId(infoid);
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
        public DataSet GetList(int Top, string strWhere,string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tz888.Model.Recomm.recommResourceM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tz888.Model.Recomm.recommResourceM> DataTableToList(DataTable dt)
        {
            List<Tz888.Model.Recomm.recommResourceM> modelList = new List<Tz888.Model.Recomm.recommResourceM>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tz888.Model.Recomm.recommResourceM model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tz888.Model.Recomm.recommResourceM();
                    if (dt.Rows[n]["RecommID"].ToString() != "")
                    {
                        model.RecommID = int.Parse(dt.Rows[n]["RecommID"].ToString());
                    }
                    if (dt.Rows[n]["ResourceId"].ToString() != "")
                    {
                        model.ResourceId = long.Parse(dt.Rows[n]["ResourceId"].ToString());
                    }
                    model.ResourceTitle = dt.Rows[n]["ResourceTitle"].ToString();
                    if (dt.Rows[n]["ResourceTypeId"].ToString() != "")
                    {
                        model.ResourceTypeId = int.Parse(dt.Rows[n]["ResourceTypeId"].ToString());
                    }
                    model.ResourceUrl = dt.Rows[n]["ResourceUrl"].ToString();
                    model.RecommName = dt.Rows[n]["RecommName"].ToString();
                    model.RecommToUser = dt.Rows[n]["RecommToUser"].ToString();
                    if (dt.Rows[n]["RecommDate"].ToString() != "")
                    {
                        model.RecommDate = DateTime.Parse(dt.Rows[n]["RecommDate"].ToString());
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

