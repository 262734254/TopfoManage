using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Link;
using GZS.DAL.Link;
using System.Data;
using System.Data.SqlClient;
namespace GZS.BLL.Link
{
    public class TZClickBLL
    {
        private readonly TZClickDAL dal = new TZClickDAL();

        #region  Method
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(TZClickM model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(TZClickM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public TZClickM GetModel(int id)
        {

            return dal.GetModel(id);
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
        public int ModfiyHit(string name, int pageId)
        {
            return dal.ModfiyHit(name, pageId);
        }
        public bool ExistsIsUserName(string loginName, int pageId)
        {
            return dal.ExistsIsUserName(loginName, pageId);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<TZClickM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<TZClickM> DataTableToList(DataTable dt)
        {
            List<TZClickM> modelList = new List<TZClickM>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TZClickM model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TZClickM();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.loginName = dt.Rows[n]["loginName"].ToString();
                    if (dt.Rows[n]["createTime"].ToString() != "")
                    {
                        model.createTime = DateTime.Parse(dt.Rows[n]["createTime"].ToString());
                    }
                    if (dt.Rows[n]["ClickId"].ToString() != "")
                    {
                        model.ClickId = int.Parse(dt.Rows[n]["ClickId"].ToString());
                    }
                    if (dt.Rows[n]["PageId"].ToString() != "")
                    {
                        model.PageId = int.Parse(dt.Rows[n]["PageId"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        /// <summary>
        /// ��ý���,���죬��ʷ�û�������
        /// </summary>
        /// <param name="loginName">��¼��</param>
        /// <param name="pageId">ҳ��ID</param>
        /// <param name="day">0,������ʷ��1,��ʾ���� 2����������</param>
        /// <returns></returns>
        public int GetTodayCount(string loginName, int pageId, int day)
        {
            return dal.GetTodayCount(loginName, pageId, day);
        }
               /// <summary>
        /// ��ý���,���죬��ʷ�û�������
        /// </summary>
        /// <param name="loginName">��¼��</param>
        /// <param name="day">0,������ʷ��1,��ʾ���� 2����������</param>
        /// <returns></returns>
        public int GetTodayCount(string loginName, int day)
        {
            return dal.GetTodayCount(loginName, day);
        }
        /// <summary>
        /// ��ҳ��ȡ�����б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}
