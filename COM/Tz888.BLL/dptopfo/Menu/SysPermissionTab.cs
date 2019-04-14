using System;
using System.Data;
using System.Collections.Generic;
using GZS.Model.Menu;
using GZS.DAL.Menu;

namespace GZS.BLL.Menu
{
    /// <summary>
    /// 业务逻辑类SysPermissionTab 的摘要说明。
    /// </summary>
    public class SysPermissionTab
    {
        private readonly GZS.DAL.Menu.SysPermissionTab dal = new GZS.DAL.Menu.SysPermissionTab();
        public SysPermissionTab()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SPID)
        {
            return dal.Exists(SPID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GZS.Model.Menu.SysPermissionTab model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GZS.Model.Menu.SysPermissionTab model)
        {
           return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SPID)
        {

            dal.Delete(SPID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GZS.Model.Menu.SysPermissionTab GetModel(int SPID)
        {

            return dal.GetModel(SPID);
        }
        public GZS.Model.Menu.SysPermissionTab GetModel1(int roleid)
        {
            return dal.GetModel1(roleid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public GZS.Model.Menu.SysPermissionTab GetModelByCache(int SPID)
        {

            string CacheKey = "SysPermissionTabModel-" + SPID;
            object objModel = dal.GetModel(SPID);

            return (GZS.Model.Menu.SysPermissionTab)objModel;
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
        public List<GZS.Model.Menu.SysPermissionTab> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GZS.Model.Menu.SysPermissionTab> DataTableToList(DataTable dt)
        {
            List<GZS.Model.Menu.SysPermissionTab> modelList = new List<GZS.Model.Menu.SysPermissionTab>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GZS.Model.Menu.SysPermissionTab model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GZS.Model.Menu.SysPermissionTab();
                    if (dt.Rows[n]["SPID"].ToString() != "")
                    {
                        model.SPID = int.Parse(dt.Rows[n]["SPID"].ToString());
                    }
                    if (dt.Rows[n]["RoleID"].ToString() != "")
                    {
                        model.RoleID = int.Parse(dt.Rows[n]["RoleID"].ToString());
                    }
                    if (dt.Rows[n]["SysID"].ToString() != "")
                    {
                        model.SysID = int.Parse(dt.Rows[n]["SysID"].ToString());
                    }
                    model.SPCode = dt.Rows[n]["SPCode"].ToString();
                    if (dt.Rows[n]["SPDate"].ToString() != "")
                    {
                        model.SPDate = DateTime.Parse(dt.Rows[n]["SPDate"].ToString());
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
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
    }
}

