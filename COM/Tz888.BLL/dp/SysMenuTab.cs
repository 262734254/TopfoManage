using System;
using System.Data;
using System.Collections.Generic;
using Tz888.Model.dp;
using System.Collections;
using Tz888.DALFactory;
using Tz888.IDAL.dp;
namespace Tz888.BLL.dp
{
    /// <summary>
    /// 业务逻辑类SysMenuTab 的摘要说明。
    /// </summary>
    public class SysMenuTab
    {
        private readonly ISysMenuTab dal = DataAccess.CreatedpMenuTab();
        public SysMenuTab()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sid)
        {
            return dal.Exists(sid);
        }
        /// <summary>
        /// 菜单名称是否相同
        /// </summary>
        public bool ExistsMenuName(string menuName)
        {
            return dal.ExistsMenuName(menuName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tz888.Model.dp.SysMenuTab model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Tz888.Model.dp.SysMenuTab model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int sid)
        {
            return dal.Delete(sid);
        }
        public bool Delete1(int sid)
        {
            return dal.Delete1(sid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.dp.SysMenuTab GetModel(int sid)
        {

            return dal.GetModel(sid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Tz888.Model.dp.SysMenuTab GetModelByCache(int sid)
        {

            string CacheKey = "SysMenuTabModel-" + sid;

            object objModel = dal.GetModel(sid);

            return (Tz888.Model.dp.SysMenuTab)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表取出有限字段
        /// </summary>
        public DataTable GetListSingle(string strWhere)
        {
            DataSet ds = new DataSet();
            ds=dal.GetListSingle(strWhere);
            return ds.Tables[0];
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
        public List<Tz888.Model.dp.SysMenuTab> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tz888.Model.dp.SysMenuTab> DataTableToList(DataTable dt)
        {
            List<Tz888.Model.dp.SysMenuTab> modelList = new List<Tz888.Model.dp.SysMenuTab>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tz888.Model.dp.SysMenuTab model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tz888.Model.dp.SysMenuTab();
                    if (dt.Rows[n]["sid"].ToString() != "")
                    {
                        model.sid = int.Parse(dt.Rows[n]["sid"].ToString());
                    }
                    model.SName = dt.Rows[n]["SName"].ToString();
                    if (dt.Rows[n]["SCheck"].ToString() != "")
                    {
                        model.SCheck = int.Parse(dt.Rows[n]["SCheck"].ToString());
                    }
                    model.Surl = dt.Rows[n]["Surl"].ToString();
                    if (dt.Rows[n]["SisActive"].ToString() != "")
                    {
                        model.SisActive = int.Parse(dt.Rows[n]["SisActive"].ToString());
                    }
                    if (dt.Rows[n]["SParentCode"].ToString() != "")
                    {
                        model.SParentCode = int.Parse(dt.Rows[n]["SParentCode"].ToString());
                    }
                    model.SCode = dt.Rows[n]["SCode"].ToString();
                    model.Starget = dt.Rows[n]["Starget"].ToString();
                    if (dt.Rows[n]["SDate"].ToString() != "")
                    {
                        model.SDate = DateTime.Parse(dt.Rows[n]["SDate"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        public IList<Tz888.Model.dp.SysMenuTab> GetList(int SParentCode, string sort)
        {
            return dal.GetList(SParentCode, sort);
        }
        public IList<Tz888.Model.dp.SysMenuTab> GetList()
        {
            return dal.GetList();
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

