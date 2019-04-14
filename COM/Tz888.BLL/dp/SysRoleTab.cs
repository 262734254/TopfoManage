using System;
using System.Data;
using System.Collections.Generic;
using Tz888.Model.dp;
using Tz888.DALFactory;
using Tz888.IDAL.dp;
namespace Tz888.BLL.dp
{
    /// <summary>
    /// ҵ���߼���SysRoleTab ��ժҪ˵����
    /// </summary>
    public class SysRoleTab
    {
        private readonly ISysRoleTab dal = DataAccess.CreatedpRoleTab();
        public SysRoleTab()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int SRoleID)
        {
            return dal.Exists(SRoleID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Tz888.Model.dp.SysRoleTab model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Tz888.Model.dp.SysRoleTab model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int SRoleID)
        {

            dal.Delete(SRoleID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tz888.Model.dp.SysRoleTab GetModel(int SRoleID)
        {

            return dal.GetModel(SRoleID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Tz888.Model.dp.SysRoleTab GetModelByCache(int SRoleID)
        {

            string CacheKey = "SysRoleTabModel-" + SRoleID;
            object objModel = dal.GetModel(SRoleID);
            return (Tz888.Model.dp.SysRoleTab)objModel;
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
        public List<Tz888.Model.dp.SysRoleTab> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Tz888.Model.dp.SysRoleTab> DataTableToList(DataTable dt)
        {
            List<Tz888.Model.dp.SysRoleTab> modelList = new List<Tz888.Model.dp.SysRoleTab>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tz888.Model.dp.SysRoleTab model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tz888.Model.dp.SysRoleTab();
                    if (dt.Rows[n]["SRoleID"].ToString() != "")
                    {
                        model.SRoleID = int.Parse(dt.Rows[n]["SRoleID"].ToString());
                    }
                    model.SRName = dt.Rows[n]["SRName"].ToString();
                    model.SRDoc = dt.Rows[n]["SRDoc"].ToString();
                    model.SysCode = dt.Rows[n]["SysCode"].ToString();
                    if (dt.Rows[n]["SRDate"].ToString() != "")
                    {
                        model.SRDate = DateTime.Parse(dt.Rows[n]["SRDate"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        /// <summary>
        /// ���ݽ�ɫ�����ȡ��ɫ����
        /// </summary>
        /// <param name="IndustryID"></param>
        /// <returns></returns>
        public string GetNameByID(string IndustryID)
        {
            return dal.GetNameByID(IndustryID);
        }
        /// <summary>
        /// ��ȡ���н�ɫ��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataSet dvGetAllIndustry()
        {
            return dal.dvGetAllIndustry();
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

