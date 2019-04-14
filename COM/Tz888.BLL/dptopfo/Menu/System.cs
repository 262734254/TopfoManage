using System;
using System.Data;
using System.Collections.Generic;
using GZS.Model.Menu;
using GZS.DAL.Menu;

namespace GZS.BLL.Menu
{
    /// <summary>
    /// ҵ���߼���System ��ժҪ˵����
    /// </summary>
    public class System
    {
        private readonly GZS.DAL.Menu.System dal = new GZS.DAL.Menu.System();
        public System()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string EmployeeID)
        {
            return dal.Exists(EmployeeID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(GZS.Model.Menu.System model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(GZS.Model.Menu.System model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string EmployeeID)
        {

            dal.Delete(EmployeeID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public GZS.Model.Menu.System GetModel(string EmployeeID)
        {

            return dal.GetModel(EmployeeID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public GZS.Model.Menu.System GetModelByCache(string EmployeeID)
        {

            string CacheKey = "SystemModel-" + EmployeeID;
            object objModel = dal.GetModel(EmployeeID);

            return (GZS.Model.Menu.System)objModel;
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
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<GZS.Model.Menu.System> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<GZS.Model.Menu.System> DataTableToList(DataTable dt)
        {
            List<GZS.Model.Menu.System> modelList = new List<GZS.Model.Menu.System>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GZS.Model.Menu.System model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GZS.Model.Menu.System();
                    if (dt.Rows[n]["EmployeeID"].ToString() != "")
                    {
                        model.EmployeeID =dt.Rows[n]["EmployeeID"].ToString();
                    }
                    model.Tem = dt.Rows[n]["Tem"].ToString();
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
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����
    }
}
