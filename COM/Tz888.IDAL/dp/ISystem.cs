using System;
using System.Data;
namespace Tz888.IDAL.dp
{
    /// <summary>
    /// 接口层ISystem 的摘要说明。
    /// </summary>
    public interface ISystem
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string EmployeeID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Tz888.Model.dp.System model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Tz888.Model.dp.System model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(string EmployeeID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Tz888.Model.dp.System GetModel(string EmployeeID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
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
