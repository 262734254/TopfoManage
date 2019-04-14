using System;
using System.Data;
using System.Collections.Generic;
using GZS.Model.Menu;
using GZS.DAL.Menu;

namespace GZS.BLL.Menu
{
    /// <summary>
    /// ҵ���߼���SysPermissionTab ��ժҪ˵����
    /// </summary>
    public class SysPermissionTab
    {
        private readonly GZS.DAL.Menu.SysPermissionTab dal = new GZS.DAL.Menu.SysPermissionTab();
        public SysPermissionTab()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int SPID)
        {
            return dal.Exists(SPID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(GZS.Model.Menu.SysPermissionTab model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(GZS.Model.Menu.SysPermissionTab model)
        {
           return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int SPID)
        {

            dal.Delete(SPID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public GZS.Model.Menu.SysPermissionTab GetModel(int SPID)
        {

            return dal.GetModel(SPID);
        }
        public GZS.Model.Menu.SysPermissionTab GetModel1(int roleid)
        {
            return dal.GetModel1(roleid);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public GZS.Model.Menu.SysPermissionTab GetModelByCache(int SPID)
        {

            string CacheKey = "SysPermissionTabModel-" + SPID;
            object objModel = dal.GetModel(SPID);

            return (GZS.Model.Menu.SysPermissionTab)objModel;
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
        public List<GZS.Model.Menu.SysPermissionTab> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<GZS.Model.Menu.SysPermissionTab> DataTableToList(DataTable dt)
        {
            List<GZS.Model.Menu.SysPermissionTab> modelList = new List<GZS.Model.Menu.SysPermissionTab>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GZS.Model.Menu.SysPermissionTab model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GZS.Model.Menu.SysPermissionTab();
                    if (dt.Rows[n]["SPID"].ToString() != "")
                    {
                        model.SPID = int.Parse(dt.Rows[n]["SPID"].ToString());
                    }
                    if (dt.Rows[n]["RoleID"].ToString() != "")
                    {
                        model.RoleID = int.Parse(dt.Rows[n]["RoleID"].ToString());
                    }
                    if (dt.Rows[n]["SysID"].ToString() != "")
                    {
                        model.SysID = int.Parse(dt.Rows[n]["SysID"].ToString());
                    }
                    model.SPCode = dt.Rows[n]["SPCode"].ToString();
                    if (dt.Rows[n]["SPDate"].ToString() != "")
                    {
                        model.SPDate = DateTime.Parse(dt.Rows[n]["SPDate"].ToString());
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
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����
    }
}

