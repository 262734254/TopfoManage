using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
namespace Tz888.IDAL.dp
{
    /// <summary>
    /// 接口层ISysMenuTab 的摘要说明。
    /// </summary>
    public interface ISysMenuTab
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int sid);
        /// <summary>
        /// 菜单名称是否相同
        /// </summary>
        bool ExistsMenuName(string menuName);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Tz888.Model.dp.SysMenuTab model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Tz888.Model.dp.SysMenuTab model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int sid);
        bool Delete1(int sid);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Tz888.Model.dp.SysMenuTab GetModel(int sid);
        IList<Tz888.Model.dp.SysMenuTab> GetList(int SParentCode, string sort);
        IList<Tz888.Model.dp.SysMenuTab> GetList();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得数据列表(取出有限字段)
        /// </summary>
        DataSet GetListSingle(string strWhere);
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
