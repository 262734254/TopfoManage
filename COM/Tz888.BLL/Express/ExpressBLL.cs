using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Express;
using Tz888.IDAL.Express;
using Tz888.DALFactory;
using System.Data;
namespace Tz888.BLL.Express
{
    public class ExpressBLL
    {
        private readonly ExpressIDAL dal = DataAccess.CreateIExpress();
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ExpressModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ExpressModel model) 
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int expressID)
        {
            return dal.Delete(expressID);
        }
        public bool DeleteList(string expressIDlist) 
        {
            return dal.DeleteList(expressIDlist);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ExpressModel GetModel(int expressID)
        {
            return dal.GetModel(expressID);
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
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
           ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetListT(TableViewName, Key, SelectStr, Criteria, Sort,
            ref CurrentPage, PageSize, ref TotalCount);
        } 
        #endregion  成员方法
    }
}
