using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using GZS.Model.Menu;
using GZS.DAL.Menu;

namespace GZS.BLL.Menu
{
    /// <summary>
    /// ҵ���߼���SysMenuTab ��ժҪ˵����
    /// </summary>
    public class SysMenuTab
    {
        private readonly GZS.DAL.Menu.SysMenuTab dal = new GZS.DAL.Menu.SysMenuTab();
        public SysMenuTab()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int sid)
        {
            return dal.Exists(sid);
        }
        /// <summary>
        /// �˵������Ƿ���ͬ
        /// </summary>
        public bool ExistsMenuName(string menuName)
        {
            return dal.ExistsMenuName(menuName);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(GZS.Model.Menu.SysMenuTab model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(GZS.Model.Menu.SysMenuTab model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int sid)
        {
            return dal.Delete(sid);
        }
        public bool Delete1(int sid)
        {
            return dal.Delete1(sid);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public GZS.Model.Menu.SysMenuTab GetModel(int sid)
        {

            return dal.GetModel(sid);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public GZS.Model.Menu.SysMenuTab GetModelByCache(int sid)
        {

            string CacheKey = "SysMenuTabModel-" + sid;

            object objModel = dal.GetModel(sid);

            return (GZS.Model.Menu.SysMenuTab)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�ȡ�������ֶ�
        /// </summary>
        public DataTable GetListSingle(string strWhere)
        {
            DataSet ds = new DataSet();
            ds=dal.GetListSingle(strWhere);
            return ds.Tables[0];
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
        public List<GZS.Model.Menu.SysMenuTab> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<GZS.Model.Menu.SysMenuTab> DataTableToList(DataTable dt)
        {
            List<GZS.Model.Menu.SysMenuTab> modelList = new List<GZS.Model.Menu.SysMenuTab>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GZS.Model.Menu.SysMenuTab model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GZS.Model.Menu.SysMenuTab();
                    if (dt.Rows[n]["sid"].ToString() != "")
                    {
                        model.sid = int.Parse(dt.Rows[n]["sid"].ToString());
                    }
                    model.SName = dt.Rows[n]["SName"].ToString();
                    if (dt.Rows[n]["SCheck"].ToString() != "")
                    {
                        model.SCheck = int.Parse(dt.Rows[n]["SCheck"].ToString());
                    }
                    model.Surl = dt.Rows[n]["Surl"].ToString();
                    if (dt.Rows[n]["SisActive"].ToString() != "")
                    {
                        model.SisActive = int.Parse(dt.Rows[n]["SisActive"].ToString());
                    }
                    if (dt.Rows[n]["SParentCode"].ToString() != "")
                    {
                        model.SParentCode = int.Parse(dt.Rows[n]["SParentCode"].ToString());
                    }
                    model.SCode = dt.Rows[n]["SCode"].ToString();
                    model.Starget = dt.Rows[n]["Starget"].ToString();
                    if (dt.Rows[n]["SDate"].ToString() != "")
                    {
                        model.SDate = DateTime.Parse(dt.Rows[n]["SDate"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        public IList<GZS.Model.Menu.SysMenuTab> GetList(int SParentCode, string sort)
        {
            return dal.GetList(SParentCode, sort);
        }
        public IList<GZS.Model.Menu.SysMenuTab> GetList()
        {
            return dal.GetList();
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

