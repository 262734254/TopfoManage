using System;
using System.Data;
namespace Tz888.IDAL.dp
{
    /// <summary>
    /// 接口层ISysRoleTab 的摘要说明。
    /// </summary>
    public interface ISysRoleTab
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int SRoleID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Tz888.Model.dp.SysRoleTab model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(Tz888.Model.dp.SysRoleTab model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int SRoleID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Tz888.Model.dp.SysRoleTab GetModel(int SRoleID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 获取所有角色信息
        /// </summary>
        /// <returns></returns>
        DataSet dvGetAllIndustry();
        /// <summary>
        /// 根据角色代码获取角色名称
        /// </summary>
        /// <param name="IndustryID"></param>
        /// <returns></returns>
        string GetNameByID(string IndustryID);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}
