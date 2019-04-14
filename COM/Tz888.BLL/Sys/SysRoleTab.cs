using System;
using System.Data;
using System.Collections.Generic;
using Tz888.Model.Sys;
using Tz888.DALFactory;
using Tz888.IDAL.Sys;
namespace Tz888.BLL.Sys
{
    /// <summary>
    /// 业务逻辑类SysRoleTab 的摘要说明。
    /// </summary>
    public class SysRoleTab
    {
        private readonly ISysRoleTab dal = DataAccess.CreateSysRoleTab();
        public SysRoleTab()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SRoleID)
        {
            return dal.Exists(SRoleID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tz888.Model.Sys.SysRoleTab model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Tz888.Model.Sys.SysRoleTab model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SRoleID)
        {

            dal.Delete(SRoleID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Sys.SysRoleTab GetModel(int SRoleID)
        {

            return dal.GetModel(SRoleID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Tz888.Model.Sys.SysRoleTab GetModelByCache(int SRoleID)
        {

            string CacheKey = "SysRoleTabModel-" + SRoleID;
            object objModel = dal.GetModel(SRoleID);
            return (Tz888.Model.Sys.SysRoleTab)objModel;
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
        public List<Tz888.Model.Sys.SysRoleTab> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tz888.Model.Sys.SysRoleTab> DataTableToList(DataTable dt)
        {
            List<Tz888.Model.Sys.SysRoleTab> modelList = new List<Tz888.Model.Sys.SysRoleTab>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tz888.Model.Sys.SysRoleTab model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tz888.Model.Sys.SysRoleTab();
                    if (dt.Rows[n]["SRoleID"].ToString() != "")
                    {
                        model.SRoleID = int.Parse(dt.Rows[n]["SRoleID"].ToString());
                    }
                    model.SRName = dt.Rows[n]["SRName"].ToString();
                    model.SRDoc = dt.Rows[n]["SRDoc"].ToString();
                    model.SysCode = dt.Rows[n]["SysCode"].ToString();
                    if (dt.Rows[n]["SRDate"].ToString() != "")
                    {
                        model.SRDate = DateTime.Parse(dt.Rows[n]["SRDate"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        /// <summary>
        /// 根据角色代码获取角色名称
        /// </summary>
        /// <param name="IndustryID"></param>
        /// <returns></returns>
        public string GetNameByID(string IndustryID)
        {
            return dal.GetNameByID(IndustryID);
        }
        /// <summary>
        /// 获取所有角色信息
        /// </summary>
        /// <returns></returns>
        public DataSet dvGetAllIndustry()
        {
            return dal.dvGetAllIndustry();
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

