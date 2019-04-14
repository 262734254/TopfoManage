using System;
using System.Data;
using System.Collections.Generic;
using Tz888.Model.Recomm;
using Tz888.DALFactory;
using Tz888.IDAL.Recomm;
using Tz888.Model.Info;
using Tz888.SQLServerDAL.Recomm;
namespace Tz888.BLL.Recomm
{
    /// <summary>
    /// recommResourceBLL
    /// </summary>
    public partial class recommResourceBLL
    {
        //private readonly recommResourceIDAL dal=DataAccess.CreaterecommResourceDAL();
        private readonly recommResourceDAL dal = new recommResourceDAL();
        public recommResourceBLL()
        { }
        #region  Method
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int RecommID)
        {
            return dal.Exists(RecommID);
        }
        #region ��ҳ��ѯ
        /// <summary>
        /// ��topfocrm���ݿ�
        /// </summary>
        /// <param name="TableViewName">����</param>
        /// <param name="Key">����</param>
        /// <param name="SelectStr">��ѯ�ֶ�</param>
        /// <param name="Criteria">����</param>
        /// <param name="Sort">�����ֶ�</param>
        /// <param name="CurrentPage">��ǰҳ</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">�ܼ�¼</param>
        /// <returns></returns>
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetListT(TableViewName, Key, SelectStr, Criteria, Sort,
            ref CurrentPage, PageSize, ref TotalCount);
        }
        #endregion
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Tz888.Model.Recomm.recommResourceM model)
        {
            return dal.Add(model);
        }
        public string SelCompanyUserName()
        {
            return dal.SelCompanyUserName();
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Tz888.Model.Recomm.recommResourceM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int RecommID)
        {

            return dal.Delete(RecommID);
        }
        /// <summary>
        /// ����������ѯ�Ƿ��������
        /// </summary>
        /// <param name="RecommTypeID">��Դ����1,���̡����ʡ�Ͷ��2,�˲�3,����4, ����</param>
        /// <param name="RecommToUser">�Ƽ��û�</param>
        /// <param name="ResourecId">�Ƽ���ԴID</param>
        /// <returns></returns>
        public int ExistsByWhere(int RecommTypeID, string RecommToUser, long ResourecId)
        {
            return dal.ExistsByWhere(RecommTypeID, RecommToUser, ResourecId);
        }
        /// <summary>
        /// ���������Ѿ��Ƽ�����ֻ�����ʱ��
        /// </summary>
        /// <returns></returns>
        public int UpdateTimeByRecommId(int recommId)
        {
            return dal.UpdateTimeByRecommId(recommId);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string RecommIDlist)
        {
            return dal.DeleteList(RecommIDlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tz888.Model.Recomm.recommResourceM GetModel(int RecommID)
        {

            return dal.GetModel(RecommID);
        }
        /// <summary>
        /// �Ƽ� �������л�ȡ���� title ,url
        /// ���ӵ����ݿⲻͬ
        /// </summary>
        /// <param name="infoid"></param>
        /// <returns></returns>
        public DataSet GetTitleAndUrlByInfoId(string infoid)
        {
            return dal.GetTitleAndUrlByInfoId(infoid);
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
        public DataSet GetList(int Top, string strWhere,string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Tz888.Model.Recomm.recommResourceM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Tz888.Model.Recomm.recommResourceM> DataTableToList(DataTable dt)
        {
            List<Tz888.Model.Recomm.recommResourceM> modelList = new List<Tz888.Model.Recomm.recommResourceM>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tz888.Model.Recomm.recommResourceM model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tz888.Model.Recomm.recommResourceM();
                    if (dt.Rows[n]["RecommID"].ToString() != "")
                    {
                        model.RecommID = int.Parse(dt.Rows[n]["RecommID"].ToString());
                    }
                    if (dt.Rows[n]["ResourceId"].ToString() != "")
                    {
                        model.ResourceId = long.Parse(dt.Rows[n]["ResourceId"].ToString());
                    }
                    model.ResourceTitle = dt.Rows[n]["ResourceTitle"].ToString();
                    if (dt.Rows[n]["ResourceTypeId"].ToString() != "")
                    {
                        model.ResourceTypeId = int.Parse(dt.Rows[n]["ResourceTypeId"].ToString());
                    }
                    model.ResourceUrl = dt.Rows[n]["ResourceUrl"].ToString();
                    model.RecommName = dt.Rows[n]["RecommName"].ToString();
                    model.RecommToUser = dt.Rows[n]["RecommToUser"].ToString();
                    if (dt.Rows[n]["RecommDate"].ToString() != "")
                    {
                        model.RecommDate = DateTime.Parse(dt.Rows[n]["RecommDate"].ToString());
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
        /// ��ҳ��ȡ�����б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}

