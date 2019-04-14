using System;
using System.Data;
namespace Tz888.IDAL.Sys
{
    /// <summary>
    /// 接口层ISysPermissionTab 的摘要说明。
    /// </summary>
    public interface ISysPermissionTab
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int SPID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Tz888.Model.Sys.SysPermissionTab model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Tz888.Model.Sys.SysPermissionTab model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int SPID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Tz888.Model.Sys.SysPermissionTab GetModel(int SPID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        Tz888.Model.Sys.SysPermissionTab GetModel1(int roleid);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}
