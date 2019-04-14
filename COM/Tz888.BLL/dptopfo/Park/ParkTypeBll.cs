using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Park;
using GZS.DAL.Park;
using System.Data;
namespace GZS.BLL.Park
{
    public class ParkTypeBll
    {
        ParkTypeDal dal = new ParkTypeDal();
        #region  Method
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ParkTypeM model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(ParkTypeM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int parktypeid)
        {

            return dal.Delete(parktypeid);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string parktypeidlist)
        {
            return dal.DeleteList(parktypeidlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ParkTypeM GetModel(int parktypeid)
        {

            return dal.GetModel(parktypeid);
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
        public List<ParkTypeM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<ParkTypeM> DataTableToList(DataTable dt)
        {
            List<ParkTypeM> modelList = new List<ParkTypeM>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ParkTypeM model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ParkTypeM();
                    if (dt.Rows[n]["parktypeid"].ToString() != "")
                    {
                        model.parktypeid = int.Parse(dt.Rows[n]["parktypeid"].ToString());
                    }
                    model.parktypename = dt.Rows[n]["parktypename"].ToString();
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
