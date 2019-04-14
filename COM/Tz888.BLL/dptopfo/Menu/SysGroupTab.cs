using System;
using System.Data;
using System.Collections.Generic;
using GZS.Model.Menu;
using GZS.DAL.Menu;

namespace GZS.BLL.Menu
{
    /// <summary>
    /// ҵ���߼���SysGroupTab ��ժҪ˵����
    /// </summary>
    public class SysGroupTab
    {
        private readonly GZS.DAL.Menu.SysGroupTab dal = new GZS.DAL.Menu.SysGroupTab();
        public SysGroupTab()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int SID)
        {
            return dal.Exists(SID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(GZS.Model.Menu.SysGroupTab model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(GZS.Model.Menu.SysGroupTab model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int SID)
        {

            dal.Delete(SID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public GZS.Model.Menu.SysGroupTab GetModel(int SID)
        {

            return dal.GetModel(SID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public GZS.Model.Menu.SysGroupTab GetModelByCache(int SID)
        {

            string CacheKey = "SysGroupTabModel-" + SID;
            object objModel = dal.GetModel(SID);
                    
            return (GZS.Model.Menu.SysGroupTab)objModel;
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
        public List<GZS.Model.Menu.SysGroupTab> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<GZS.Model.Menu.SysGroupTab> DataTableToList(DataTable dt)
        {
            List<GZS.Model.Menu.SysGroupTab> modelList = new List<GZS.Model.Menu.SysGroupTab>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GZS.Model.Menu.SysGroupTab model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GZS.Model.Menu.SysGroupTab();
                    if (dt.Rows[n]["SGID"].ToString() != "")
                    {
                        model.SID = int.Parse(dt.Rows[n]["SGID"].ToString());
                    }
                    if (dt.Rows[n]["SRoleID"].ToString() != "")
                    {
                        model.SRoleID = dt.Rows[n]["SRoleID"].ToString();
                    }
                    model.SName = dt.Rows[n]["SName"].ToString();
                    if (dt.Rows[n]["SysCheck"].ToString() != "")
                    {
                        model.SysCheck = int.Parse(dt.Rows[n]["SysCheck"].ToString());
                    }
                    if (dt.Rows[n]["SysDate"].ToString() != "")
                    {
                        model.SysDate = DateTime.Parse(dt.Rows[n]["SysDate"].ToString());
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

