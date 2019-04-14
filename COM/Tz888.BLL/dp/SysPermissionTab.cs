using System;
using System.Data;
using System.Collections.Generic;
using Tz888.Model.dp;
using Tz888.DALFactory;
using Tz888.IDAL.dp;
namespace Tz888.BLL.dp
{
    /// <summary>
    /// ҵ���߼���SysPermissionTab ��ժҪ˵����
    /// </summary>
    public class SysPermissionTab
    {
        private readonly ISysPermissionTab dal = DataAccess.CreatedpPermissionTab();
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
        public int Add(Tz888.Model.dp.SysPermissionTab model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Tz888.Model.dp.SysPermissionTab model)
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
        public Tz888.Model.dp.SysPermissionTab GetModel(int SPID)
        {

            return dal.GetModel(SPID);
        }
        public Tz888.Model.dp.SysPermissionTab GetModel1(int roleid)
        {
            return dal.GetModel1(roleid);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Tz888.Model.dp.SysPermissionTab GetModelByCache(int SPID)
        {

            string CacheKey = "SysPermissionTabModel-" + SPID;
            object objModel = dal.GetModel(SPID);

            return (Tz888.Model.dp.SysPermissionTab)objModel;
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
        public List<Tz888.Model.dp.SysPermissionTab> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Tz888.Model.dp.SysPermissionTab> DataTableToList(DataTable dt)
        {
            List<Tz888.Model.dp.SysPermissionTab> modelList = new List<Tz888.Model.dp.SysPermissionTab>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tz888.Model.dp.SysPermissionTab model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tz888.Model.dp.SysPermissionTab();
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

