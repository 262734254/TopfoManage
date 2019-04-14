using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Express;
using System.Data;
namespace Tz888.IDAL.Express
{
   public interface ExpressIDAL
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ExpressModel model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(ExpressModel model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int expressID);
        bool DeleteList(string expressIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ExpressModel GetModel(int expressID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
       DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
          ref long CurrentPage, long PageSize, ref long TotalCount);
        #endregion  成员方法
    }
}
