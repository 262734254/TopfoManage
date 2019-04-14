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
        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ExpressModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(ExpressModel model) 
        {
            return dal.Update(model);
        }
        /// <summary>
        /// ɾ��һ������
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
        /// �õ�һ������ʵ��
        /// </summary>
        public ExpressModel GetModel(int expressID)
        {
            return dal.GetModel(expressID);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere) 
        {

            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
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
        #endregion  ��Ա����
    }
}
